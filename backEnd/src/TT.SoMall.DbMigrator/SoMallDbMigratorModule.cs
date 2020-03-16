using TT.SoMall.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace TT.SoMall.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(SoMallEntityFrameworkCoreDbMigrationsModule),
        typeof(SoMallApplicationContractsModule)
    )]
    public class SoMallDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}