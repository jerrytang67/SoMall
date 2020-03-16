using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TT.Extensions
{
    public static class HttpEx
    {
        public static async Task<T> GetJsonAsync<T>(string url)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();
                responseBody = responseBody.Replace("\uFEFF", "");

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //if header auth are needed
                //var token = Convert.ToBase64String(Encoding.ASCII.GetBytes(token);
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("token", token);
                return JsonConvert.DeserializeObject<T>(responseBody);
            }
        }


        public static async Task<T> PostAsync<T>(string url, object data) where T : class, new()
        {
            try
            {
                using (var client = new System.Net.Http.HttpClient())
                {
                    string content = JsonConvert.SerializeObject(data);
                    var buffer = Encoding.UTF8.GetBytes(content);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    var response = await client.PostAsync(url, byteContent).ConfigureAwait(false);
                    string result = await response.Content.ReadAsStringAsync();
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        return new T();
                    }

                    return JsonConvert.DeserializeObject<T>(result);
                }
            }
            catch (WebException ex)
            {
                if (ex.Response != null)
                {
                    string responseContent = new StreamReader(ex.Response.GetResponseStream()).ReadToEnd();
                    throw new System.Exception($"response :{responseContent}", ex);
                }

                throw;
            }
        }

        public static byte[] PostGotImageByte(string url, object obj)
        {
            var postData = JsonConvert.SerializeObject(obj);
            var request = (HttpWebRequest) WebRequest.Create(url);
            request.Method = "POST";
            request.Accept = "*/*";
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            request.UserAgent = "Mozilla/5.0 (Windows NT 5.1; rv:2.0.1) Gecko/20100101 Firefox/4.0.1";
            var buffer = Encoding.UTF8.GetBytes(postData);
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            var response = (HttpWebResponse) request.GetResponse();
            var ms = new MemoryStream();
            response.GetResponseStream()?.CopyTo(ms);
            return ms.ToArray();
        }
    }
}