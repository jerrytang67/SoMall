using Volo.Abp.Modularity;

namespace TT.SoMall
{
    [DependsOn(
        typeof(SoMallApplicationModule),
        typeof(SoMallDomainTestModule)
    )]
    public class SoMallApplicationTestModule : AbpModule
    {
    }
}