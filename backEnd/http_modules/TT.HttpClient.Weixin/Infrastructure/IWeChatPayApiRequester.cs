using System.Threading.Tasks;
using System.Xml;

namespace TT.HttpClient.Weixin.Infrastructure
{
    public interface IWeChatPayApiRequester
    {
        Task<XmlDocument> RequestAsync(string url, string body);
    }
}