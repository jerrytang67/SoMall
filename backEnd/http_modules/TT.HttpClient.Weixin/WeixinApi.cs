using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using Serilog;
using TT.Extensions;

namespace TT.HttpClient.Weixin
{
    public class WeixinApi : IWeixinApi
    {
        private readonly System.Net.Http.HttpClient _client;

        public WeixinApi(System.Net.Http.HttpClient client)
        {
            _client = client;
        }

        /// <summary>
        /// <see cref="https://developers.weixin.qq.com/doc/offiaccount/Basic_Information/Get_access_token.html"/>
        /// </summary>
        /// <param name="appid"></param>
        /// <param name="appSecret"></param>
        /// <returns></returns>
        public async Task<WeixinTokenResult> GetToken(string appid, string appSecret)
        {
            var response =
                await _client.GetAsync($"cgi-bin/token?grant_type=client_credential&appid={appid}&secret={appSecret}");

            var jsonResponse = await response.Content.ReadAsStringAsync();

            // ip error: {"errcode":40164,"errmsg":"invalid ip 114.220.209.25 ipv6 ::ffff:114.220.209.25, not in whitelist hint: [eS4JRA00075263]"}
            // secret error :{"errcode":40013,"errmsg":"invalid appid"}
            // success return {"access_token":"ACCESS_TOKEN","expires_in":7200}

            var result = JsonConvert.DeserializeObject<WeixinTokenResult>(jsonResponse);
            return result;
        }

        public async Task<WeixinUserInfoResult> GetUserInfo(string token, string openid)
        {
            var response =
                await _client.GetAsync($"/cgi-bin/user/info?access_token={token}&openid={openid}&lang=zh_CN");
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<WeixinUserInfoResult>(jsonResponse);
            return result;
        }


        public async Task<MiniSessionResult> Mini_Code2Session(string code, string appid, string appSeret)
        {
            var response =
                await _client.GetAsync(
                    $"sns/jscode2session?appid={appid}&secret={appSeret}&grant_type=authorization_code&js_code={code}");

            var jsonResponse = await response.Content.ReadAsStringAsync();

#if DEBUG
            Log.Logger.Debug(JsonConvert.SerializeObject(jsonResponse));
#endif

            var result = JsonConvert.DeserializeObject<MiniSessionResult>(jsonResponse);

            return result;
        }


        /// <summary>
        /// 获取小程序码，适用于需要的码数量较少的业务场景。通过该接口生成的小程序码，永久有效，有数量限制，详见获取二维码。
        /// <see cref="https://developers.weixin.qq.com/miniprogram/dev/api-backend/open-api/qr-code/wxacode.get.html"/>
        /// </summary>
        /// <param name="token">接口调用凭证</param>
        /// <param name="path">扫码进入的小程序页面路径，最大长度 128 字节，不能为空；对于小游戏，可以只传入 query 部分，来实现传参效果，如：传入 "?foo=bar"，即可在 wx.getLaunchOptionsSync 接口中的 query 参数获取到 {foo:"bar"}。</param>
        /// <param name="width">二维码的宽度，单位 px。最小 280px，最大 1280px</param>
        /// <param name="is_hyaline">是否需要透明底色，为 true 时，生成透明底色的小程序码</param>
        /// <returns></returns>
        public async Task<Byte[]> WxacodeGet(string token, string path,
            int width = 430, bool is_hyaline = false)
        {
            var postData = JsonConvert.SerializeObject(new {path, width, is_hyaline});

            HttpContent hc = new StreamContent(new MemoryStream(Encoding.UTF8.GetBytes(postData)));

            var response =
                await _client.PostAsync($"wxa/getwxacode?access_token={token}", hc);

            var jsonResponse = await response.Content.ReadAsByteArrayAsync();

            return jsonResponse;
        }

        /// <summary>
        /// 获取小程序码，适用于需要的码数量极多的业务场景。通过该接口生成的小程序码，永久有效，数量暂无限制。 更多用法详见 获取二维码。
        /// <see cref="https://developers.weixin.qq.com/miniprogram/dev/api-backend/open-api/qr-code/wxacode.getUnlimited.html#HTTPS%20%E8%B0%83%E7%94%A8"/>
        /// </summary>
        /// <param name="token">接口调用凭证</param>
        /// <param name="scene">最大32个可见字符，只支持数字，大小写英文以及部分特殊字符：!#$&'()*+,/:;=?@-._~，其它字符请自行编码为合法字符（因不支持%，中文无法使用 urlencode 处理，请使用其他编码方式）</param>
        /// <param name="page">必须是已经发布的小程序存在的页面（否则报错），例如 pages/index/index, 根路径前不要填加 /,不能携带参数（参数请放在scene字段里），如果不填写这个字段，默认跳主页面</param>
        /// <param name="width">二维码的宽度，单位 px，最小 280px，最大 1280px</param>
        /// <param name="is_hyaline">是否需要透明底色，为 true 时，生成透明底色的小程序</param>
        /// <returns></returns>
        public async Task<Byte[]> WxacodeGetUnlimit(string token, string scene, string page = null,
            int width = 430, bool is_hyaline = false)
        {
            var postData = "";
            if (page.IsNullOrEmptyOrWhiteSpace() || page == "pages/index/index")
            {
                postData = JsonConvert.SerializeObject(new {scene, width, is_hyaline});
            }
            else
            {
                postData = JsonConvert.SerializeObject(new {scene, page, width, is_hyaline});
            }

            HttpContent hc = new StreamContent(new MemoryStream(Encoding.UTF8.GetBytes(postData)));

            var response = await _client.PostAsync($"wxa/getwxacodeunlimit?access_token={token}", hc);
            var result = TryConvert(await response.Content.ReadAsStringAsync());
            if (result != null)
            {
                throw new Exception(result.errmsg);
            }

            var bytes = await response.Content.ReadAsByteArrayAsync();
            return bytes;
        }

        public ErrorResult TryConvert(string input)
        {
            try
            {
                return JsonConvert.DeserializeObject<ErrorResult>(input);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }


    public class ErrorResult
    {
        public int errcode { get; set; }
        public string errmsg { get; set; }
    }
}