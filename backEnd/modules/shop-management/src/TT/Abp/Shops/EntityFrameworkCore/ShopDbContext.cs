using Microsoft.EntityFrameworkCore;
using TT.Abp.Shops.Domain;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace TT.Abp.Shops.EntityFrameworkCore
{
    [ConnectionStringName("Shop")]
    public class ShopDbContext : AbpDbContext<ShopDbContext>, IShopDbContext
    {
        public DbSet<Shop> Shops { get; set; }

        public ShopDbContext(DbContextOptions<ShopDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureShop();
        }
    }
}