using TT.SoMall.Localization.SoMall;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace TT.SoMall.Pages
{
    public abstract class SoMallPageModelBase : AbpPageModel
    {
        protected SoMallPageModelBase()
        {
            LocalizationResourceType = typeof(SoMallResource);
        }
    }
}