using System.Threading.Tasks;
using DotNetCore.CAP;
using Newtonsoft.Json;
using Serilog;
using TT.Abp.Weixin.Domain;
using TT.HttpClient.Weixin.WeixiinResult;
using Volo.Abp.DependencyInjection;

namespace TT.Abp.Weixin.Events.Caps
{
    public class WexinCapSubscriberService : ICapSubscribe, ITransientDependency
    {
        private readonly WeixinManager _weixinManager;

        public WexinCapSubscriberService(WeixinManager weixinManager)
        {
            _weixinManager = weixinManager;
        }

        [CapSubscribe("weixin.services.mini.getuserinfo")]
        public async Task Subscriber(MiniUserInfoResult userInfo)
        {
            Log.Logger.Warning("Cap");
            Log.Logger.Warning(JsonConvert.SerializeObject(userInfo));
            await _weixinManager.CreateOrUpdate(userInfo);
        }
    }
}