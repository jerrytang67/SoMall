using Microsoft.EntityFrameworkCore;
using TT.Abp.AccountManagement.Domain;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace TT.Abp.AccountManagement.EntityFrameworkCore
{
    public static class AccountManagementDbExtensions
    {
        public static void ConfigureAccountManagement(this ModelBuilder builder)
        {
            // 实名信息
            builder.Entity<RealNameInfo>(b =>
            {
                b.ToTable(AccountManagementConsts.DbTablePrefix + "RealNameInfos", AccountManagementConsts.DbSchema);
                
                b.HasKey(x => x.UserId);
                
                b.ConfigureFullAudited();

                b.Property(x => x.RealName).IsRequired().HasMaxLength(AccountManagementConsts.MaxNameLength);
                b.Property(x => x.Phone).IsRequired().HasMaxLength(AccountManagementConsts.MaxNameLength);
                b.Property(x => x.PhoneBackup).HasMaxLength(AccountManagementConsts.MaxNameLength);

                b.Property(x => x.IDCardFrontUrl).IsRequired().HasMaxLength(AccountManagementConsts.MaxNameLength);
                b.Property(x => x.IDCardBackUrl).IsRequired().HasMaxLength(AccountManagementConsts.MaxNameLength);
                b.Property(x => x.IDCardHandUrl).IsRequired().HasMaxLength(AccountManagementConsts.MaxNameLength);
                b.Property(x => x.BusinessLicenseUrl).HasMaxLength(AccountManagementConsts.MaxNameLength);
            });
        }
    }
}