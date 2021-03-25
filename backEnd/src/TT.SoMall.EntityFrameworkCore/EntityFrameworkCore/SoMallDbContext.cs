using Microsoft.EntityFrameworkCore;
using TT.Abp.Shops.EntityFrameworkCore;
using TT.Abp.VisitorManagement.Domain;
using TT.Abp.Weixin.Domain;
using TT.Abp.Weixin.EntityFrameworkCore;
using TT.SoMall.Users;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.Identity;
using Volo.Abp.Users.EntityFrameworkCore;

namespace TT.SoMall.EntityFrameworkCore
{
    /* This is your actual DbContext used on runtime.
     * It includes only your entities.
     * It does not include entities of the used modules, because each module has already
     * its own DbContext class. If you want to share some database tables with the used modules,
     * just create a structure like done for AppUser.
     *
     * Don't use this DbContext for database migrations since it does not contain tables of the
     * used modules (as explained above). See SoMallMigrationsDbContext for migrations.
     */
    [ConnectionStringName("Default")]
    public class SoMallDbContext : AbpDbContext<SoMallDbContext>
    {
        public DbSet<AppUser> Users { get; set; }

        /* Add DbSet properties for your Aggregate Roots / Entities here.
         * Also map them inside SoMallDbContextModelCreatingExtensions.ConfigureSoMall
         */

        public DbSet<WechatUserinfo> WechatUserinfos { get; set; }

        public SoMallDbContext(DbContextOptions<SoMallDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /* Configure the shared tables (with included modules) here */

            builder.Entity<AppUser>(b =>
            {
                b.ToTable(AbpIdentityDbProperties.DbTablePrefix + "Users"); //Sharing the same table "AbpUsers" with the IdentityUser
                
                b.ConfigureByConvention();
                b.ConfigureAbpUser();
                //Moved customization to a method so we can share it with the SoMallMigrationsDbContext class
                b.ConfigureCustomUserProperties();
            });

            /* Configure your own tables/entities inside the ConfigureSoMall method */
            
            builder.ConfigureSoMall();
            
            builder.ConfigureWeixinManagement();
            
        }
    }
}