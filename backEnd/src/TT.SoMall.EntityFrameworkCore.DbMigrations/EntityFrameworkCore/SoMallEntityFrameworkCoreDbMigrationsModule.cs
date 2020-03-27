using Microsoft.Extensions.DependencyInjection;
using TT.Abp.FormManagement;
using TT.Abp.Mall;
using TT.Abp.Shops;
using TT.Abp.VisitorManagement;
using TT.Abp.Weixin;
using Volo.Abp.Modularity;

namespace TT.SoMall.EntityFrameworkCore
{
    [DependsOn(
        typeof(SoMallEntityFrameworkCoreModule)
        , typeof(ShopModule)
        , typeof(MallModule)
        , typeof(VisitorManagementModule)
        , typeof(FormManagementModule)
        , typeof(WeixinModule)
    )]
    public class SoMallEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<SoMallMigrationsDbContext>();
        }
    }
}