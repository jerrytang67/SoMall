using TT.Abp.AppManagement;
using TT.SoMall;
using Volo.Abp.Modularity;

namespace TT.Abp.Modules.Tests
{
    [DependsOn(
        typeof(SoMallApplicationModule),
        typeof(SoMallDomainTestModule),
        typeof(AppManagementModule)
    )]
    public class SoMallModulesTestModule : AbpModule
    {
    }
}