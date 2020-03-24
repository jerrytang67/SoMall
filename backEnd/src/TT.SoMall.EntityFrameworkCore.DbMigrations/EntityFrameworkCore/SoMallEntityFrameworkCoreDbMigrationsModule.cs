using Microsoft.Extensions.DependencyInjection;
using TT.Abp.MallManagement;
using TT.Abp.Shops;
using TT.Abp.VisitorManagement;
using TT.Abp.WeixinManagement;
using Volo.Abp.Modularity;

namespace TT.SoMall.EntityFrameworkCore
{
    [DependsOn(
        typeof(SoMallEntityFrameworkCoreModule)
        , typeof(ShopModule)
        , typeof(MallManagementModule)
        , typeof(VisitorManagementModule)
        , typeof(WeixinManagementModule)
    )]
    public class SoMallEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<SoMallMigrationsDbContext>();
        }
    }
}