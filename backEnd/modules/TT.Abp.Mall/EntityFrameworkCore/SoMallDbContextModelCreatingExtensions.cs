using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TT.Abp.Core.EntityFrameworkCore;
using TT.Abp.Mall.Definitions;
using TT.Abp.Mall.Domain;
using TT.Abp.Mall.Domain.Addresses;
using TT.Abp.Mall.Domain.Comments;
using TT.Abp.Mall.Domain.News;
using TT.Abp.Mall.Domain.Orders;
using TT.Abp.Mall.Domain.Partners;
using TT.Abp.Mall.Domain.Pays;
using TT.Abp.Mall.Domain.Products;
using TT.Abp.Mall.Domain.Shares;
using TT.Abp.Mall.Domain.Shops;
using TT.Abp.Mall.Domain.Swipers;
using TT.Abp.Mall.Domain.Users;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace TT.Abp.Mall.EntityFrameworkCore
{
    public static class SoMallDbContextModelCreatingExtensions
    {
        public static void ConfigureMall(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            builder.Entity<MallUser>(b =>
            {
                b.ToTable(MallConsts.DbTablePrefix + "Users", MallConsts.DbSchema);
                b.ConfigureAbpUser();
                b.ConfigureExtraProperties();
            });


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
                b.Property(x => x.RedirectUrl).HasMaxLength(MallConsts.MaxImageLength);

                b.HasMany(x => x.SpuList).WithOne(x => x.Category);

                b.HasMany(x => x.AppProductCategories).WithOne(x => x.ProductCategory);
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
                    .OnDelete(DeleteBehavior.Restrict); //删除限制
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
                b.Property(x => x.BillNo).IsRequired().HasMaxLength(48);
                b.Property(x => x.OpenId).IsRequired().HasMaxLength(32);
                b.Property(x => x.MchId).IsRequired().HasMaxLength(32);
                b.Property(x => x.AppName).IsRequired().HasMaxLength(MallConsts.MaxNameLength);
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
                b.Property(x => x.AddressLocationLabel).HasMaxLength(MallConsts.MaxOrderComentLength);
                b.Property(x => x.AddressLocationAddress).HasMaxLength(MallConsts.MaxOrderComentLength);

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
                b.Property(x => x.Discount).HasColumnType("decimal(18,2)");
                b.Property(x => x.SkuUnit).HasMaxLength(MallConsts.MaxShortNameLength);
                b.Property(x => x.SkuCoverImageUrl).HasMaxLength(MallConsts.MaxImageLength);
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
                b.Property(x => x.LocationLabel).IsRequired().HasMaxLength(MallConsts.MaxImageLength);
                b.Property(x => x.LocationAddress).HasMaxLength(MallConsts.MaxImageLength);
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
                b.HasKey(x => x.UserId);

                b.ConfigureFullAudited();
                b.Property(x => x.RealName).IsRequired().HasMaxLength(MallConsts.MaxNameLength);
                b.Property(x => x.Phone).IsRequired().HasMaxLength(MallConsts.MaxPhoneLength);
                b.Property(x => x.PhoneBackup).HasMaxLength(MallConsts.MaxPhoneLength);
                b.Property(x => x.HeadImgUrl).HasMaxLength(MallConsts.MaxImageLength);

                b.Property(x => x.LocationLabel).HasMaxLength(MallConsts.MaxNameLength);
                b.Property(x => x.LocationAddress).HasMaxLength(MallConsts.MaxNameLength);

                b.OwnsOne(p => p.Detail,
                    ob => ob.ToTable(MallConsts.DbTablePrefix + "PartnerDetails", MallConsts.DbSchema));
            });

            // 分销员 产品
            builder.Entity<PartnerProduct>(b =>
            {
                b.ToTable(MallConsts.DbTablePrefix + "PartnerProducts", MallConsts.DbSchema);
                b.ConfigureCreationAudited();

                b.Property(x => x.State).HasDefaultValue(1);

                // b.Property(x => x.Price).HasColumnType("decimal(18,2)");

                b.HasKey(x => new {x.PartnerId, x.SpuId});

                // many to many 
                b.HasOne(bc => bc.Partner)
                    .WithMany(b => b.PartnerProducts)
                    .HasForeignKey(bc => bc.PartnerId);
            });


            // 优惠券
            builder.Entity<Coupon>(b =>
            {
                b.ToTable(MallConsts.DbTablePrefix + "Coupons", MallConsts.DbSchema);
                b.ConfigureFullAuditedAggregateRoot();

                b.Property(x => x.Name).IsRequired().HasMaxLength(MallConsts.MaxNameLength);
                b.Property(x => x.Code).IsRequired().HasMaxLength(MallConsts.MaxCodeLength);
                b.Property(x => x.Desc).IsRequired().HasMaxLength(MallConsts.MaxShortDescLength);
            });

            // 优惠券
            builder.Entity<UserCoupon>(b =>
            {
                b.ToTable(MallConsts.DbTablePrefix + "UserCoupons", MallConsts.DbSchema);
                b.ConfigureFullAuditedAggregateRoot();

                b.Property(x => x.CouponName).IsRequired().HasMaxLength(MallConsts.MaxNameLength);
            });


            // Pays

            builder.Entity<TenPayNotify>(b =>
            {
                b.ToTable(MallConsts.DbTablePrefix + "TenPayNotify", MallConsts.DbSchema);
                b.ConfigureCreationAuditedAggregateRoot();

                b.Property(x => x.out_trade_no).HasMaxLength(MallConsts.MaxNameLength);
                b.Property(x => x.result_code).HasMaxLength(MallConsts.MaxNameLength);
                b.Property(x => x.fee_type).HasMaxLength(MallConsts.MaxNameLength);
                b.Property(x => x.return_code).HasMaxLength(MallConsts.MaxNameLength);
                b.Property(x => x.total_fee).HasMaxLength(MallConsts.MaxNameLength);
                b.Property(x => x.mch_id).HasMaxLength(MallConsts.MaxNameLength);
                b.Property(x => x.cash_fee).HasMaxLength(MallConsts.MaxNameLength);
                b.Property(x => x.openid).HasMaxLength(MallConsts.MaxNameLength);
                b.Property(x => x.transaction_id).HasMaxLength(MallConsts.MaxNameLength);
                b.Property(x => x.sign).HasMaxLength(MallConsts.MaxNameLength);
                b.Property(x => x.bank_type).HasMaxLength(MallConsts.MaxNameLength);
                b.Property(x => x.appid).HasMaxLength(MallConsts.MaxNameLength);
                b.Property(x => x.time_end).HasMaxLength(MallConsts.MaxNameLength);
                b.Property(x => x.trade_type).HasMaxLength(MallConsts.MaxNameLength);
                b.Property(x => x.nonce_str).HasMaxLength(MallConsts.MaxNameLength);
                b.Property(x => x.is_subscribe).HasMaxLength(MallConsts.MaxNameLength);
            });


            // APPCategory

            builder.Entity<AppProductCategory>(b =>
            {
                b.ToTable(MallConsts.DbTablePrefix + "AppProductCategory", MallConsts.DbSchema);
                b.ConfigureCreationAudited();
                b.HasKey(x => new {x.AppName, x.ProductCategoryId});
                b.Property(x => x.AppName).HasMaxLength(MallConsts.MaxNameLength);

                // Many-To-One
                b.HasOne(x => x.ProductCategory).WithMany(x => x.AppProductCategories).HasForeignKey(x => x.ProductCategoryId)
                    .OnDelete(DeleteBehavior.Cascade); //级联删除
            });

            builder.Entity<AppProductSpu>(b =>
            {
                b.ToTable(MallConsts.DbTablePrefix + "AppProductSpus", MallConsts.DbSchema);
                b.ConfigureCreationAudited();
                b.HasKey(x => new {x.AppName, x.ProductSpuId});
                b.Property(x => x.AppName).HasMaxLength(MallConsts.MaxNameLength);

                // Many-To-One
                b.HasOne(x => x.ProductSpu).WithMany(x => x.AppProductSpus).HasForeignKey(x => x.ProductSpuId)
                    .OnDelete(DeleteBehavior.Cascade); //级联删除
            });


            builder.Entity<Swiper>(b =>
            {
                b.ToTable(MallConsts.DbTablePrefix + "Swipers", MallConsts.DbSchema);
                b.ConfigureFullAuditedAggregateRoot();

                b.Property(x => x.GroupName).IsRequired().HasMaxLength(MallConsts.MaxNameLength);
                b.Property(x => x.AppName).IsRequired().HasMaxLength(MallConsts.MaxNameLength);
                b.Property(x => x.CoverImageUrl).IsRequired().HasMaxLength(MallConsts.MaxImageLength);
                b.Property(x => x.Name).HasMaxLength(MallConsts.MaxNameLength);
                b.Property(x => x.RedirectUrl).HasMaxLength(MallConsts.MaxImageLength);
                b.Property(x => x.State).HasDefaultValue(1);
            });

            builder.Entity<NewsCategory>(b =>
            {
                b.ToTable(MallConsts.DbTablePrefix + "NewsCategories", MallConsts.DbSchema);
                b.ConfigureFullAuditedAggregateRoot();
                b.Property(x => x.Name).IsRequired().HasMaxLength(MallConsts.MaxNameLength);

                b.HasMany(x => x.Contents).WithOne(x => x.Category);
            });

            builder.Entity<NewsContent>(b =>
            {
                b.ToTable(MallConsts.DbTablePrefix + "NewsContents", MallConsts.DbSchema);
                b.ConfigureFullAuditedAggregateRoot();
                b.Property(x => x.Title).IsRequired().HasMaxLength(MallConsts.MaxNameLength);
                b.Property(x => x.CoverImageUrl).HasMaxLength(MallConsts.MaxImageLength);

                // Many-To-One
                b.HasOne(x => x.Category).WithMany(x => x.Contents).HasForeignKey(x => x.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<QrDetail>(b =>
                {
                    b.ToTable(MallConsts.DbTablePrefix + "QrDetails", MallConsts.DbSchema);
                    b.ConfigureCreationAudited();
                    b.Property(x => x.AppName).IsRequired().HasMaxLength(MallConsts.MaxNameLength);
                    b.Property(x => x.EventName).IsRequired().HasMaxLength(MallConsts.MaxNameLength);
                    b.Property(x => x.EventKey).HasMaxLength(MallConsts.MaxImageLength);
                    b.Property(x => x.Path).HasMaxLength(MallConsts.MaxImageLength);
                    b.Property(x => x.QrImageUrl).HasMaxLength(MallConsts.MaxImageLength);

                    b.Property(x => x.Params).HasConversion(
                        v => JsonConvert.SerializeObject(v,
                            new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore}),
                        v => JsonConvert.DeserializeObject<Dictionary<string, string>>(v,
                            new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore}));
                }
            );
        }
    }
}