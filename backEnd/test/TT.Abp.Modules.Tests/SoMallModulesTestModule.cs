using TT.Abp.AppManagement;
using TT.Abp.Cms;
using TT.SoMall;
using Volo.Abp.Modularity;

namespace TT.Abp.Modules.Tests
{
    [DependsOn(
        typeof(SoMallApplicationModule),
        typeof(SoMallDomainTestModule),
        typeof(AppManagementModule),
        typeof(CmsModule)
    )]
    public class SoMallModulesTestModule : AbpModule
    {
    }
}