using Microsoft.Extensions.DependencyInjection;
using TT.Abp.VisitorManagement;
using Volo.Abp.Modularity;

namespace TT.SoMall.EntityFrameworkCore
{
    [DependsOn(
        typeof(SoMallEntityFrameworkCoreModule),
        typeof(VisitorManagementModule)
    )]
    public class SoMallEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<SoMallMigrationsDbContext>();
            
        }
    }
}