using TT.SoMall;
using Volo.Abp.Modularity;

namespace TT.Abp.Modules.Tests
{
    [DependsOn(
        typeof(SoMallApplicationModule),
        typeof(SoMallDomainTestModule)
    )]
    public class SoMallModulesTestModule : AbpModule
    {
    }
}