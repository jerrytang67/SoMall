using Microsoft.EntityFrameworkCore;
using TT.Abp.AppManagement.Domain;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace TT.Abp.AppManagement.EntityFrameworkCore
{
    public static class AppManagementDbExtensions
    {
        public static void ConfigureAppManagement(this ModelBuilder builder)
        {
            builder.Entity<App>(b =>
            {
                b.ToTable(AppManagementConsts.DbTablePrefix + "Apps", AppManagementConsts.DbSchema);

                b.ConfigureFullAuditedAggregateRoot();

                b.Property(x => x.Name).IsRequired().HasMaxLength(AppManagementConsts.MaxNameLength);
                b.Property(x => x.ClientName).IsRequired().HasMaxLength(AppManagementConsts.MaxNameLength);
            });
        }
    }
}