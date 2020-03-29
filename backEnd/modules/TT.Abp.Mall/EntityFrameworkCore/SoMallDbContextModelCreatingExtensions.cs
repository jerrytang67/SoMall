using System.Collections.Generic;
using EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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
                b.Property(x => x.Name).IsRequired().HasMaxLength(MallConsts.MaxNameLength);
                b.Property(x => x.ShortName).IsRequired().HasMaxLength(MallConsts.MaxShortNameLength);
                b.Property(x => x.LogoImage).IsRequired().HasMaxLength(MallConsts.MaxImageLength);
                b.Property(x => x.CoverImage).IsRequired().HasMaxLength(MallConsts.MaxImageLength);
            });

            builder.Entity<ProductCategory>(b =>
            {
                b.ToTable(MallConsts.DbTablePrefix + "ProductCategory", MallConsts.DbSchema);
                b.ConfigureFullAuditedAggregateRoot();
                b.Property(x => x.Name).IsRequired().HasMaxLength(MallConsts.MaxNameLength);
                b.Property(x => x.Code).HasMaxLength(MallConsts.MaxCodeLength);
                b.Property(x => x.LogoImageUrl).HasMaxLength(MallConsts.MaxImageLength);

                b.HasMany(x => x.SpuList).WithOne(x => x.Category);
            });

            builder.Entity<ProductSpu>(b =>
            {
                b.ToTable(MallConsts.DbTablePrefix + "ProductSpu", MallConsts.DbSchema);
                b.ConfigureFullAuditedAggregateRoot();
                b.Property(x => x.Name).IsRequired().HasMaxLength(MallConsts.MaxNameLength);
                b.Property(x => x.Code).IsRequired().HasMaxLength(MallConsts.MaxCodeLength);
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
                b.Property(x => x.Name).IsRequired().HasMaxLength(MallConsts.MaxNameLength);
                b.Property(x => x.Code).HasMaxLength(MallConsts.MaxCodeLength);
                
                b.Property(x => x.CoverImageUrls).HasConversion(
                    v => JsonConvert.SerializeObject(v,
                        new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore}),
                    v => JsonConvert.DeserializeObject<List<string>>(v,
                        new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore}));


                // Many-To-One
                b.HasOne(x => x.Spu).WithMany(x => x.Skus).HasForeignKey(qt => qt.SpuId);
            });
        }
    }
}