using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using TT.Abp.Mall.Domain;
using TT.Abp.Mall.Domain.Addresses;
using TT.Abp.Mall.Domain.Comments;
using TT.Abp.Mall.Domain.Orders;
using TT.Abp.Mall.Domain.Partners;
using TT.Abp.Mall.Domain.Pays;
using TT.Abp.Mall.Domain.Products;
using TT.Abp.Mall.Domain.Shops;
using TT.Abp.Mall.Domain.Users;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.Users;

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
                b.Property(x => x.AddressLocationLable).HasMaxLength(MallConsts.MaxOrderComentLength);
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
                b.Property(x => x.LocationLable).IsRequired().HasMaxLength(MallConsts.MaxImageLength);
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
                b.Property(x => x.Phone).IsRequired().HasMaxLength(MallConsts.MaxNameLength);
                b.Property(x => x.Nickname).HasMaxLength(MallConsts.MaxNameLength);
                b.Property(x => x.HeadImageUrl).HasMaxLength(MallConsts.MaxImageLength);

                b.Property(x => x.LocationLabel).HasMaxLength(MallConsts.MaxImageLength);
                b.Property(x => x.LocationAddress).HasMaxLength(MallConsts.MaxImageLength);

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
        }
    }

    public static class AbpUsersDbContextModelCreatingExtensions
    {
        public static void ConfigureAbpUser<TUser>(this EntityTypeBuilder<TUser> b)
            where TUser : class, IUser
        {
            b.Property(u => u.TenantId).HasColumnName(nameof(IUser.TenantId));
            b.Property(u => u.UserName).IsRequired().HasMaxLength(AbpUserConsts.MaxUserNameLength).HasColumnName(nameof(IUser.UserName));
            b.Property(u => u.Email).IsRequired().HasMaxLength(AbpUserConsts.MaxEmailLength).HasColumnName(nameof(IUser.Email));
            b.Property(u => u.Name).HasMaxLength(AbpUserConsts.MaxNameLength).HasColumnName(nameof(IUser.Name));
            b.Property(u => u.Surname).HasMaxLength(AbpUserConsts.MaxSurnameLength).HasColumnName(nameof(IUser.Surname));
            b.Property(u => u.EmailConfirmed).HasDefaultValue(false).HasColumnName(nameof(IUser.EmailConfirmed));
            b.Property(u => u.PhoneNumber).HasMaxLength(AbpUserConsts.MaxPhoneNumberLength).HasColumnName(nameof(IUser.PhoneNumber));
            b.Property(u => u.PhoneNumberConfirmed).HasDefaultValue(false).HasColumnName(nameof(IUser.PhoneNumberConfirmed));
        }
    }
}