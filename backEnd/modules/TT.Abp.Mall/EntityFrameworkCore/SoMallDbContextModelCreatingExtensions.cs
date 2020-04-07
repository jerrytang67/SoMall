using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TT.Abp.Mall.Domain.Comments;
using TT.Abp.Mall.Domain.Orders;
using TT.Abp.Mall.Domain.Partners;
using TT.Abp.Mall.Domain.Products;
using TT.Abp.Mall.Domain.Shops;
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
                b.Property(x => x.Unit).HasMaxLength(MallConsts.MaxShortNameLength);
                b.Property(x => x.Price).HasColumnType("decimal(18,2)");
                b.Property(x => x.OriginPrice).HasColumnType("decimal(18,2)");
                b.Property(x => x.VipPrice).HasColumnType("decimal(18,2)");

                b.Property(x => x.CoverImageUrls).HasConversion(
                    v => JsonConvert.SerializeObject(v,
                        new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore}),
                    v => JsonConvert.DeserializeObject<List<string>>(v,
                        new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore}));


                // Many-To-One
                b.HasOne(x => x.Spu).WithMany(x => x.Skus).HasForeignKey(qt => qt.SpuId);
            });

            // 支付订单
            builder.Entity<PayOrder>(b =>
            {
                b.ToTable(MallConsts.DbTablePrefix + "PayOrders", MallConsts.DbSchema);
                b.ConfigureFullAuditedAggregateRoot();
                b.Property(x => x.Body).IsRequired().HasMaxLength(128);
                b.Property(x => x.BillNo).HasMaxLength(48);
                b.Property(x => x.OpenId).HasMaxLength(32);
                b.Property(x => x.MchId).HasMaxLength(32);
            });

            // 商品订单
            builder.Entity<ProductOrder>(b =>
            {
                b.ToTable(MallConsts.DbTablePrefix + "ProductOrders", MallConsts.DbSchema);
                b.ConfigureFullAuditedAggregateRoot();
                b.Property(x => x.PricePaidIn).HasColumnType("decimal(18,2)");
                b.Property(x => x.PriceOriginal).HasColumnType("decimal(18,2)");
                b.Property(x => x.Comment).HasMaxLength(MallConsts.MaxOrderComentLength);
                b.Property(x => x.AddressRealName).HasMaxLength(MallConsts.MaxNameLength);
                b.Property(x => x.AddressNickName).HasMaxLength(MallConsts.MaxNameLength);
                b.Property(x => x.AddressPhone).HasMaxLength(MallConsts.MaxNameLength);
                b.Property(x => x.AddressLocationLable).HasMaxLength(MallConsts.MaxOrderComentLength);

                b.HasMany(x => x.OrderItems).WithOne(x => x.Order);
            });

            // 商品订单项
            builder.Entity<ProductOrderItem>(b =>
            {
                b.ToTable(MallConsts.DbTablePrefix + "ProductOrderItems", MallConsts.DbSchema);
                b.ConfigureFullAudited();
                b.Property(x => x.SpuName).IsRequired().HasMaxLength(MallConsts.MaxNameLength);
                b.Property(x => x.SkuName).IsRequired().HasMaxLength(MallConsts.MaxNameLength);
                b.Property(x => x.SkuPrice).HasColumnType("decimal(18,2)");
                b.Property(x => x.SkuUnit).HasMaxLength(MallConsts.MaxShortNameLength);
                b.Property(x => x.Comment).HasMaxLength(MallConsts.MaxOrderComentLength);

                // Many-To-One
                b.HasOne(x => x.Order).WithMany(x => x.OrderItems).HasForeignKey(qt => qt.OrderId);
            });

            // 用户地址
            builder.Entity<Address>(b =>
            {
                b.ToTable(MallConsts.DbTablePrefix + "Addresses", MallConsts.DbSchema);
                b.ConfigureFullAudited();
                b.Property(x => x.RealName).IsRequired().HasMaxLength(MallConsts.MaxNameLength);
                b.Property(x => x.Phone).IsRequired().HasMaxLength(MallConsts.MaxNameLength);
                b.Property(x => x.LocationLable).IsRequired().HasMaxLength(MallConsts.MaxComentLength);
                b.Property(x => x.NickName).HasMaxLength(MallConsts.MaxNameLength);
            });

            // 评论
            builder.Entity<Comment>(b =>
            {
                b.ToTable(MallConsts.DbTablePrefix + "Comment", MallConsts.DbSchema);
                b.ConfigureFullAudited();
                b.Property(x => x.BuyerName).HasMaxLength(MallConsts.MaxNameLength);
                b.Property(x => x.BuyerAvatar).HasMaxLength(MallConsts.MaxImageLength);
                b.Property(x => x.Content).IsRequired().HasMaxLength(MallConsts.MaxComentLength);
            });

            // 分销员
            builder.Entity<Partner>(b =>
            {
                b.ToTable(MallConsts.DbTablePrefix + "Partners", MallConsts.DbSchema);
                b.ConfigureFullAudited();
                b.Property(x => x.RealName).IsRequired().HasMaxLength(MallConsts.MaxNameLength);
                b.Property(x => x.Phone).IsRequired().HasMaxLength(MallConsts.MaxNameLength);
                b.Property(x => x.Nickname).HasMaxLength(MallConsts.MaxNameLength);
                b.Property(x => x.HeadImageUrl).HasMaxLength(MallConsts.MaxImageLength);

                b.Property(x => x.LocationLabel).HasMaxLength(MallConsts.MaxImageLength);
                b.Property(x => x.LocationAddress).HasMaxLength(MallConsts.MaxImageLength);

                b.OwnsOne(p => p.Detail,
                    ob => ob.ToTable(MallConsts.DbTablePrefix + "PartnerDetails", MallConsts.DbSchema));
            });
            
            
            // 实名信息
            builder.Entity<RealNameInfo>(b =>
            {
                b.ToTable(MallConsts.DbTablePrefix + "RealNameInfos", MallConsts.DbSchema);
                b.ConfigureFullAudited();

                b.Property(x => x.RealName).IsRequired().HasMaxLength(MallConsts.MaxNameLength);
                b.Property(x => x.Phone).IsRequired().HasMaxLength(MallConsts.MaxNameLength);
                b.Property(x => x.PhoneBackup).HasMaxLength(MallConsts.MaxNameLength);
                
                b.Property(x => x.IDCardFrontUrl).IsRequired().HasMaxLength(MallConsts.MaxNameLength);
                b.Property(x => x.IDCardBackUrl).IsRequired().HasMaxLength(MallConsts.MaxNameLength);
                b.Property(x => x.IDCardHandUrl).IsRequired().HasMaxLength(MallConsts.MaxNameLength);
                b.Property(x => x.BusinessLicenseUrl).HasMaxLength(MallConsts.MaxNameLength);
            });
        }
    }
}