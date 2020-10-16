using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TT.SoMall.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace TT.SoMall.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class SoMallController : AbpController
    {
        protected SoMallController()
        {
            LocalizationResource = typeof(SoMallResource);
        }

        [Authorize]
        private async Task<ActionResult> LoginCheck()
        {
            return await Task.FromResult(Content("ok"));
        }
    }
}