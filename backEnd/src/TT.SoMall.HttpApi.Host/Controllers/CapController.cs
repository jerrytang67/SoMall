using System.Threading.Tasks;
using DotNetCore.CAP;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Serilog;
using TT.HttpClient.Weixin;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Uow;

namespace TT.SoMall.Controllers
{
    // public class CapController : AbpController
    // {
    //     private readonly WeixinManager _weixinManager;
    //
    //     public CapController(WeixinManager weixinManager)
    //     {
    //         _weixinManager = weixinManager;
    //     }
    //
    //     [NonAction]
    //     [CapSubscribe("weixin.services.mini.getuserinfo")]
    //     public async Task Subscriber(MiniUserInfoResult userInfo)
    //     {
    //         Log.Logger.Warning("Cap");
    //         Log.Logger.Warning(JsonConvert.SerializeObject(userInfo));
    //
    //         await _weixinManager.CreateOrUpdate(userInfo);
    //     }
    // }
}