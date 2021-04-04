using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace TT.SoMall
{
    [Dependency(ReplaceServices = true)]
    public class SoMallBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "SoMall";
    }
}
