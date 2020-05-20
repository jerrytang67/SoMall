using Microsoft.EntityFrameworkCore;
using TT.Abp.AuditManagement.Domain;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace TT.Abp.AuditManagement.EntityFrameworkCore
{
    public static class AuditManagementDbExtensions
    {
        public static void ConfigureAuditManagement(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            builder.Entity<AuditFlow>(b =>
            {
                b.ToTable(AuditConsts.DbTablePrefix + "AuditFlows", AuditConsts.DbSchema);
                b.ConfigureFullAuditedAggregateRoot();

                b.Property(x => x.AuditName).IsRequired().HasMaxLength(AuditConsts.MaxNameLength);
                b.Property(x => x.ProviderName).IsRequired().HasMaxLength(AuditConsts.ProviderNameLength);
                b.Property(x => x.AuditName).HasMaxLength(AuditConsts.ProviderKeyLength);
            });

            builder.Entity<AuditNode>(b =>
            {
                b.ToTable(AuditConsts.DbTablePrefix + "AuditNodes", AuditConsts.DbSchema);
                b.ConfigureCreationAudited();

                b.Property(x => x.Desc).HasMaxLength(AuditConsts.ShortDescLenght);
            });
        }
    }
}