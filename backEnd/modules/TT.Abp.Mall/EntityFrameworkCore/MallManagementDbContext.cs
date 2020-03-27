using Microsoft.EntityFrameworkCore;
using TT.Abp.Mall.Domain.Products;
using TT.Abp.Mall.Domain.Shops;
using TT.Abp.Mall.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace EntityFrameworkCore
{
    [ConnectionStringName("Mall")]
    public class MallDbContext : AbpDbContext<MallDbContext>, IMallDbContext
    {
        public DbSet<MallShop> MallShops { get; set; }

        public DbSet<ProductSpu> ProductSpu { get; set; }
        public DbSet<ProductSku> ProductSku { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }


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