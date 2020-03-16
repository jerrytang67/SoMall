using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace TT.Oss
{
//目录条目类
    public class FolderItem
    {
        public string filename;
        public string filetype;
        public int size;
        public int number;

        public FolderItem(string filename, string filetype, int size, int number)
        {
            this.filename = filename;
            this.filetype = filetype;
            this.size = size;
            this.number = number;
        }
    }

    public class UpYun
    {
        public string Domain;
        private string bucketname;
        private string username;
        private string password;
        private bool upAuth = false;
        private string api_domain = "v0.api.upyun.com";
        private string DL = "/";
        private Hashtable tmp_infos = new Hashtable();
        private string file_secret;
        private string content_md5;
        private bool auto_mkdir = false;

        public string version()
        {
            return "1.0.1";
        }

        /**
        * 初始化 UpYun 存储接口
        * @param $bucketname 空间名称
        * @param $username 操作员名称
        * @param $password 密码
        * return UpYun object
        */
        public UpYun(string bucketname, string username, string password, string domian = "")
        {
            this.bucketname = bucketname;
            this.username = username;
            this.password = password;
            this.Domain = domian;
        }

        /**
        * 切换 API 接口的域名
        * @param $domain {默认 v0.api.upyun.com 自动识别, v1.api.upyun.com 电信, v2.api.upyun.com 联通, v3.api.upyun.com 移动}
        * return null;
        */
        public void setApiDomain(string domain)
        {
            this.api_domain = domain;
        }

        /**
        * 是否启用 又拍签名认证
        * @param upAuth {默认 false 不启用(直接使用basic auth)，true 启用又拍签名认证}
        * return null;
        */
        public void setAuthType(bool upAuth)
        {
            this.upAuth = upAuth;
        }

        private void upyunAuth(Hashtable headers, string method, string uri, HttpWebRequest request)
        {
            DateTime dt = DateTime.UtcNow;
            string date = dt.ToString("ddd, dd MMM yyyy HH':'mm':'ss 'GMT'", CultureInfo.CreateSpecificCulture("en-US"));
            request.Date = dt;
            //headers.Add("Date", date);
            string auth;
            if (request.ContentLength != -1)
                auth = md5(method + '&' + uri + '&' + date + '&' + request.ContentLength + '&' + md5(this.password));
            else
                auth = md5(method + '&' + uri + '&' + date + '&' + 0 + '&' + md5(this.password));
            headers.Add("Authorization", "UpYun " + this.username + ':' + auth);
        }

        private string md5(string str)
        {
            MD5 m = new MD5CryptoServiceProvider();
            byte[] s = m.ComputeHash(UnicodeEncoding.UTF8.GetBytes(str));
            string resule = BitConverter.ToString(s);
            resule = resule.Replace("-", "");
            return resule.ToLower();
        }

        private bool delete(string path, Hashtable headers)
        {
            HttpWebResponse resp;
            byte[] a = null;
            resp = newWorker("DELETE", DL + this.bucketname + path, a, headers);
            if ((int) resp.StatusCode == 200)
            {
                resp.Close();
                return true;
            }
            else
            {
                resp.Close();
                return false;
            }
        }

        private HttpWebResponse newWorker(string method, string Url, byte[] postData, Hashtable headers)
        {
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create("http://" + api_domain + Url);

            request.Method = method;

            if (this.auto_mkdir)
            {
                headers.Add("mkdir", "true");
                this.auto_mkdir = false;
            }

            if (postData != null)
            {
                request.ContentLength = postData.Length;
                request.KeepAlive = true;
                if (this.content_md5 != null)
                {
                    request.Headers.Add("Content-MD5", this.content_md5);
                    this.content_md5 = null;
                }

                if (this.file_secret != null)
                {
                    request.Headers.Add("Content-Secret", this.file_secret);
                    this.file_secret = null;
                }
            }

            if (this.upAuth)
            {
                upyunAuth(headers, method, Url, request);
            }
            else
            {
                request.Headers.Add("Authorization", "Basic " +
                                                     Convert.ToBase64String(new System.Text.ASCIIEncoding().GetBytes(this.username + ":" + this.password)));
            }

            foreach (DictionaryEntry var in headers)
            {
                request.Headers.Add(var.Key.ToString(), var.Value.ToString());
            }

            if (postData != null)
            {
                Stream dataStream = request.GetRequestStream();
                dataStream.Write(postData, 0, postData.Length);
                dataStream.Close();
            }

            HttpWebResponse response;
            try
            {
                response = (HttpWebResponse) request.GetResponse();
                this.tmp_infos = new Hashtable();
                foreach (var hl in response.Headers)
                {
                    string name = (string) hl;
                    if (name.Length > 7 && name.Substring(0, 7) == "x-upyun")
                    {
                        this.tmp_infos.Add(name, response.Headers[name]);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return response;
        }

        /**
        * 获取总体空间的占用信息
        * return 空间占用量，失败返回 null
        */
        public long getFolderUsage(string url)
        {
            Hashtable headers = new Hashtable();
            long size;
            byte[] a = null;
            HttpWebResponse resp = newWorker("GET", DL + this.bucketname + url + "?usage", a, headers);
            try
            {
                StreamReader sr = new StreamReader(resp.GetResponseStream(), Encoding.UTF8);
                string strhtml = sr.ReadToEnd();
                resp.Close();
                size = long.Parse(strhtml);
            }
            catch (Exception)
            {
                size = 0;
            }

            return size;
        }

        /**
           * 获取某个子目录的占用信息
           * @param $path 目标路径
           * return 空间占用量，失败返回 null
           */
        public long getBucketUsage()
        {
            return getFolderUsage("/");
        }

        /**
        * 创建目录
        * @param $path 目录路径
        * return true or false
        */
        public bool mkDir(string path, bool auto_mkdir)
        {
            this.auto_mkdir = auto_mkdir;
            Hashtable headers = new Hashtable();
            headers.Add("folder", "create");
            HttpWebResponse resp;
            byte[] a = new byte[0];
            resp = newWorker("POST", DL + this.bucketname + path, a, headers);
            if ((int) resp.StatusCode == 200)
            {
                resp.Close();
                return true;
            }
            else
            {
                resp.Close();
                return false;
            }
        }

        /**
        * 删除目录
        * @param $path 目录路径
        * return true or false
        */
        public bool rmDir(string path)
        {
            Hashtable headers = new Hashtable();
            return delete(path, headers);
        }

        /**
        * 读取目录列表
        * @param $path 目录路径
        * return array 数组 或 null
        */
        public ArrayList readDir(string url)
        {
            Hashtable headers = new Hashtable();
            byte[] a = null;
            HttpWebResponse resp = newWorker("GET", DL + this.bucketname + url, a, headers);
            StreamReader sr = new StreamReader(resp.GetResponseStream(), Encoding.UTF8);
            string strhtml = sr.ReadToEnd();
            resp.Close();
            strhtml = strhtml.Replace("\t", "\\");
            strhtml = strhtml.Replace("\n", "\\");
            string[] ss = strhtml.Split('\\');
            int i = 0;
            ArrayList AL = new ArrayList();
            while (i < ss.Length)
            {
                FolderItem fi = new FolderItem(ss[i], ss[i + 1], int.Parse(ss[i + 2]), int.Parse(ss[i + 3]));
                AL.Add(fi);
                i += 4;
            }

            return AL;
        }


        /**
        * 上传文件
        * @param $file 文件路径（包含文件名）
        * @param $datas 文件内容 或 文件IO数据流
        * return true or false
        */
        public bool writeFile(string path, byte[] data, bool auto_mkdir)
        {
            Hashtable headers = new Hashtable();
            this.auto_mkdir = auto_mkdir;
            HttpWebResponse resp;
            resp = newWorker("POST", DL + this.bucketname + path, data, headers);
            if ((int) resp.StatusCode == 200)
            {
                resp.Close();
                return true;
            }
            else
            {
                resp.Close();
                return false;
            }
        }

        /**
        * 删除文件
        * @param $file 文件路径（包含文件名）
        * return true or false
        */
        public bool deleteFile(string path)
        {
            Hashtable headers = new Hashtable();
            return delete(path, headers);
        }

        /**
        * 读取文件
        * @param $file 文件路径（包含文件名）
        * @param $output_file 可传递文件IO数据流（默认为 null，结果返回文件内容，如设置文件数据流，将返回 true or false）
        * return 文件内容 或 null
        */
        public byte[] readFile(string path)
        {
            Hashtable headers = new Hashtable();
            byte[] a = null;

            HttpWebResponse resp = newWorker("GET", DL + this.bucketname + path, a, headers);
            StreamReader sr = new StreamReader(resp.GetResponseStream(), Encoding.UTF8);
            BinaryReader br = new BinaryReader(sr.BaseStream);
            byte[] by = br.ReadBytes(1024 * 1024 * 100); /// 又拍云存储最大文件限制 100Mb，对于普通用户可以改写该值，以减少内存消耗
            resp.Close();
            return by;
        }

        /**
        * 设置待上传文件的 Content-MD5 值（如又拍云服务端收到的文件MD5值与用户设置的不一致，将回报 406 Not Acceptable 错误）
        * @param $str （文件 MD5 校验码）
        * return null;
        */
        public void setContentMD5(string str)
        {
            this.content_md5 = str;
        }

        /**
        * 设置待上传文件的 访问密钥（注意：仅支持图片空！，设置密钥后，无法根据原文件URL直接访问，需带 URL 后面加上 （缩略图间隔标志符+密钥） 进行访问）
        * 如缩略图间隔标志符为 ! ，密钥为 bac，上传文件路径为 /folder/test.jpg ，那么该图片的对外访问地址为： http://空间域名/folder/test.jpg!bac
        * @param $str （文件 MD5 校验码）
        * return null;
        */
        public void setFileSecret(string str)
        {
            this.file_secret = str;
        }

        /**
        * 获取文件信息
        * @param $file 文件路径（包含文件名）
        * return array('type'=> file | folder, 'size'=> file size, 'date'=> unix time) 或 null
        */
        public Hashtable getFileInfo(string file)
        {
            Hashtable headers = new Hashtable();
            byte[] a = null;
            HttpWebResponse resp = newWorker("HEAD", DL + this.bucketname + file, a, headers);
            resp.Close();
            Hashtable ht;
            try
            {
                ht = new Hashtable();
                ht.Add("type", this.tmp_infos["x-upyun-file-type"]);
                ht.Add("size", this.tmp_infos["x-upyun-file-size"]);
                ht.Add("date", this.tmp_infos["x-upyun-file-date"]);
            }
            catch (Exception)
            {
                ht = new Hashtable();
            }

            return ht;
        }

        //获取上传后的图片信息（仅图片空间有返回数据）
        public object getWritedFileInfo(string key)
        {
            if (this.tmp_infos == new Hashtable()) return "";
            return this.tmp_infos[key];
        }

        //计算文件的MD5码
        public static string md5_file(string pathName)
        {
            string strResult = "";
            string strHashData = "";

            byte[] arrbytHashValue;
            System.IO.FileStream oFileStream = null;

            System.Security.Cryptography.MD5CryptoServiceProvider oMD5Hasher =
                new System.Security.Cryptography.MD5CryptoServiceProvider();

            try
            {
                oFileStream = new System.IO.FileStream(pathName, System.IO.FileMode.Open,
                    System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite);
                arrbytHashValue = oMD5Hasher.ComputeHash(oFileStream); //计算指定Stream 对象的哈希值
                oFileStream.Close();
                //由以连字符分隔的十六进制对构成的String，其中每一对表示value 中对应的元素；例如“F-2C-4A”
                strHashData = System.BitConverter.ToString(arrbytHashValue);
                //替换-
                strHashData = strHashData.Replace("-", "");
                strResult = strHashData;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

            return strResult.ToLower();
        }
    }
}