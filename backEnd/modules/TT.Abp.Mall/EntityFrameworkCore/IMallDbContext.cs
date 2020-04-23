using Microsoft.EntityFrameworkCore;
using TT.Abp.Mall.Domain;
using TT.Abp.Mall.Domain.Addresses;
using TT.Abp.Mall.Domain.Comments;
using TT.Abp.Mall.Domain.Orders;
using TT.Abp.Mall.Domain.Partners;
using TT.Abp.Mall.Domain.Pays;
using TT.Abp.Mall.Domain.Products;
using TT.Abp.Mall.Domain.Shops;
using TT.Abp.Mall.Domain.Users;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace TT.Abp.Mall.EntityFrameworkCore
{
    [ConnectionStringName("Mall")]
    public interface IMallDbContext : IEfCoreDbContext
    {
        public DbSet<MallUser> MallUsers { get; set; }
        public DbSet<MallShop> MallShops { get; set; }

        DbSet<ProductSpu> ProductSpu { get; set; }

        DbSet<ProductSku> ProductSku { get; set; }

        DbSet<ProductCategory> ProductCategory { get; set; }

        DbSet<PayOrder> PayOrders { get; set; }

        DbSet<ProductOrder> ProductOrders { get; set; }

        DbSet<ProductOrderItem> ProductOrderItems { get; set; }

        DbSet<Address> Addresses { get; set; }

        DbSet<Comment> Comments { get; set; }

        DbSet<Partner> Partners { get; set; }

        DbSet<Coupon> Coupons { get; set; }
        DbSet<UserCoupon> UserCoupons { get; set; }

        DbSet<TenPayNotify> TenPayNotify { get; set; }
    }
}