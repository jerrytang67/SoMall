using TT.SoMall.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace TT.SoMall
{
    [DependsOn(
        typeof(SoMallEntityFrameworkCoreTestModule)
        )]
    public class SoMallDomainTestModule : AbpModule
    {

    }
}