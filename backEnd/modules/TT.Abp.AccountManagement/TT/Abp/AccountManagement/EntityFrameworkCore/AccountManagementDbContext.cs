using Microsoft.EntityFrameworkCore;
using TT.Abp.AccountManagement.Domain;
using Volo.Abp.EntityFrameworkCore;

namespace TT.Abp.AccountManagement.EntityFrameworkCore
{
    public class AccountManagementDbContext : AbpDbContext<AccountManagementDbContext>, IAccountManagementDbContext
    {
        public virtual DbSet<RealNameInfo> RealNameInfos { get; set; }

        public AccountManagementDbContext(DbContextOptions<AccountManagementDbContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ConfigureAccountManagement();
        }
    }
}