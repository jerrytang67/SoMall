using Microsoft.EntityFrameworkCore;
using TT.Abp.AppManagement.Domain;
using Volo.Abp.EntityFrameworkCore;

namespace TT.Abp.AppManagement.EntityFrameworkCore
{
    public class AppManagementDbContext :
        AbpDbContext<AppManagementDbContext>,
        IAppManagementDbContext
    {
        public virtual DbSet<App> Apps { get; set; }

        public AppManagementDbContext(DbContextOptions<AppManagementDbContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureAppManagement();
        }
    }
}