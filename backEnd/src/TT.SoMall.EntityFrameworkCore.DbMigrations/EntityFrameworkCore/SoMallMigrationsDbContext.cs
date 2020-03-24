using Microsoft.EntityFrameworkCore;
using TT.Abp.MallManagement.EntityFrameworkCore;
using TT.Abp.Shops.EntityFrameworkCore;
using TT.Abp.VisitorManagement.EntityFrameworkCore;
using TT.Abp.WeixinManagement.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.IdentityServer.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace TT.SoMall.EntityFrameworkCore
{
    /* This DbContext is only used for database migrations.
     * It is not used on runtime. See SoMallDbContext for the runtime DbContext.
     * It is a unified model that includes configuration for
     * all used modules and your application.
     */
    public class SoMallMigrationsDbContext : AbpDbContext<SoMallMigrationsDbContext>
    {
        public SoMallMigrationsDbContext(DbContextOptions<SoMallMigrationsDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /* Include modules to your migration db context */

            builder.ConfigurePermissionManagement();
            builder.ConfigureSettingManagement();
            builder.ConfigureBackgroundJobs();
            builder.ConfigureAuditLogging();
            builder.ConfigureIdentity();
            builder.ConfigureIdentityServer();
            builder.ConfigureFeatureManagement();
            builder.ConfigureTenantManagement();

            /* Configure customizations for entities from the modules included  */

            builder.Entity<IdentityUser>(b => { b.ConfigureCustomUserProperties(); });

            /* Configure your own tables/entities inside the ConfigureSoMall method */

            builder.ConfigureSoMall();

            // 店铺功能模块
            builder.ConfigureShop();

            // 商城模块
            builder.ConfigureMallManagement();
            // visitor 访客模块
            builder.ConfigureVisitorManagement();
            // // 微信模块
            builder.ConfigureWeixinManagement();
        }
    }
}