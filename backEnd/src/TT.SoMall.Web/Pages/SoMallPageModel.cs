using TT.SoMall.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace TT.SoMall.Web.Pages
{
    public abstract class SoMallPageModel : AbpPageModel
    {
        protected SoMallPageModel()
        {
            LocalizationResourceType = typeof(SoMallResource);
        }
    }
}