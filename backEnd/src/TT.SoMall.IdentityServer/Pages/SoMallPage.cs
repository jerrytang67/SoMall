using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using TT.SoMall.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace TT.SoMall.Pages
{
    public abstract class SoMallPage : AbpPage
    {
        [RazorInject] public IHtmlLocalizer<SoMallResource> L { get; set; }
    }
}