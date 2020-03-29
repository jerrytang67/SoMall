using EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TT.Abp.Mall.Domain.Products;
using TT.Abp.Mall.Domain.Shops;
using TT.Abp.Shops;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace TT.Abp.Mall.EntityFrameworkCore
{
    public static class SoMallDbContextModelCreatingExtensions
    {
        public static void ConfigureMall(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            builder.Entity<MallShop>(b =>
            {
                b.ToTable(MallConsts.DbTablePrefix + "MallShops", MallConsts.DbSchema);
                b.ConfigureExtraProperties();
                b.Property(x => x.Name).IsRequired().HasMaxLength(ShopConsts.MaxNameLength);
                b.Property(x => x.ShortName).IsRequired().HasMaxLength(ShopConsts.MaxShortNameLength);
                b.Property(x => x.LogoImage).IsRequired().HasMaxLength(ShopConsts.MaxImageLength);
                b.Property(x => x.CoverImage).IsRequired().HasMaxLength(ShopConsts.MaxImageLength);
            });

            builder.Entity<ProductCategory>(b =>
            {
                b.ToTable(MallConsts.DbTablePrefix + "ProductCategory", MallConsts.DbSchema);
                b.ConfigureFullAuditedAggregateRoot();
                b.Property(x => x.Name).IsRequired().HasMaxLength(64);
                b.Property(x => x.Code).HasMaxLength(32);

                b.HasMany(x => x.SpuList).WithOne(x => x.Category);
            });

            builder.Entity<ProductSpu>(b =>
            {
                b.ToTable(MallConsts.DbTablePrefix + "ProductSpu", MallConsts.DbSchema);
                b.ConfigureFullAuditedAggregateRoot();
                b.Property(x => x.Name).IsRequired().HasMaxLength(64);
                b.Property(x => x.Code).IsRequired().HasMaxLength(32);
                b.Property(x => x.StockCount).HasDefaultValue(null);
                b.Property(x => x.SoldCount).HasDefaultValue(0);
                b.Property(x => x.LimitBuyCount).HasDefaultValue(null);


                // One-To-Many
                b.HasMany(x => x.Skus).WithOne(x => x.Spu);

                // Many-To-One
                b.HasOne(x => x.Category).WithMany(x => x.SpuList).HasForeignKey(x => x.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<ProductSku>(b =>
            {
                b.ToTable(MallConsts.DbTablePrefix + "ProductSku", MallConsts.DbSchema);
                b.ConfigureFullAuditedAggregateRoot();
                b.Property(x => x.Name).IsRequired().HasMaxLength(64);
                b.Property(x => x.Code).HasMaxLength(32);

                // Many-To-One
                b.HasOne(x => x.Spu).WithMany(x => x.Skus).HasForeignKey(qt => qt.SpuId);
            });
        }
    }
}