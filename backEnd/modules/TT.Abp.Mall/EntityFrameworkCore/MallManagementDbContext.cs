using Microsoft.EntityFrameworkCore;
using TT.Abp.Mall.Domain.Addresses;
using TT.Abp.Mall.Domain.Comments;
using TT.Abp.Mall.Domain.Orders;
using TT.Abp.Mall.Domain.Partners;
using TT.Abp.Mall.Domain.Products;
using TT.Abp.Mall.Domain.Shops;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace TT.Abp.Mall.EntityFrameworkCore
{
    [ConnectionStringName("Mall")]
    public class MallDbContext : AbpDbContext<MallDbContext>, IMallDbContext
    {
        public DbSet<MallShop> MallShops { get; set; }

        public DbSet<ProductSpu> ProductSpu { get; set; }
        
        public DbSet<ProductSku> ProductSku { get; set; }
        
        public DbSet<ProductCategory> ProductCategory { get; set; }
        
        public DbSet<PayOrder> PayOrders { get; set; }
        
        public DbSet<ProductOrder> ProductOrders { get; set; }
        
        public DbSet<ProductOrderItem> ProductOrderItems { get; set; }
        
        public DbSet<Address> Addresses { get; set; }
        
        public DbSet<Comment> Comments { get; set; }
        
        public DbSet<Partner> Partners { get; set; }
        
        public DbSet<RealNameInfo> RealNameInfos { get; set; }
        
        public MallDbContext(DbContextOptions<MallDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureMall();
        }
    }
}