using Microsoft.EntityFrameworkCore;
using TT.Abp.AccountManagement.Domain;
using Volo.Abp.EntityFrameworkCore;

namespace TT.Abp.AccountManagement.EntityFrameworkCore
{
    public class AccountManagementDbContext : AbpDbContext<AccountManagementDbContext>, IAccountManagementDbContext
    {
        public AccountManagementDbContext(DbContextOptions<AccountManagementDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<RealNameInfo> RealNameInfos { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ConfigureAccountManagement();
        }
    }
}