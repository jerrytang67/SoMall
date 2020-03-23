using Microsoft.EntityFrameworkCore;
using TT.Abp.MallManagement.Domain.Products;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace TT.Abp.MallManagement.EntityFrameworkCore
{
    public static class SoMallDbContextModelCreatingExtensions
    {
        public static void ConfigureManagement(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            builder.Entity<ProductCategory>(b =>
            {
                b.ToTable(MallConsts.DbTablePrefix + "ProductCategory", MallConsts.DbSchema);
                b.ConfigureFullAuditedAggregateRoot();
                b.Property(x => x.Name).IsRequired().HasMaxLength(64);
                b.Property(x => x.Code).HasMaxLength(32);
            });

            builder.Entity<ProductSpu>(b =>
            {
                b.ToTable(MallConsts.DbTablePrefix + "ProductSpu", MallConsts.DbSchema);
                b.ConfigureFullAuditedAggregateRoot();
                b.Property(x => x.Name).IsRequired().HasMaxLength(64);
                b.Property(x => x.Code).HasMaxLength(32);
            });

            builder.Entity<ProductSku>(b =>
            {
                b.ToTable(MallConsts.DbTablePrefix + "ProductSku", MallConsts.DbSchema);
                b.ConfigureFullAuditedAggregateRoot();
                b.Property(x => x.Name).IsRequired().HasMaxLength(64);
                b.Property(x => x.Code).HasMaxLength(32);
            });
        }
    }
}