using Microsoft.EntityFrameworkCore;
using TT.Abp.AppManagement.Domain;
using Volo.Abp.EntityFrameworkCore;

namespace TT.Abp.AppManagement.EntityFrameworkCore
{
    public class AppManagementDbContext :
        AbpDbContext<AppManagementDbContext>,
        IAppManagementDbContext
    {
        public AppManagementDbContext(DbContextOptions<AppManagementDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<App> Apps { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureAppManagement();
        }
    }
}