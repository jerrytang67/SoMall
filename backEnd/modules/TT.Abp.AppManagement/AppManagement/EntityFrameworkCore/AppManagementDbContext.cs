using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace TT.Abp.AppManagement.AppManagement.EntityFrameworkCore
{
    public class AppManagementDbContext : AbpDbContext<AppManagementDbContext>, IAppManagementDbContext
    {
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