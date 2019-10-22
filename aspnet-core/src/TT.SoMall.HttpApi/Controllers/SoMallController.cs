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
    }
}