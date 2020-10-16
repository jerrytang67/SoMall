using Microsoft.EntityFrameworkCore;
using TT.Abp.Shops.Domain;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace TT.Abp.Shops.EntityFrameworkCore
{
    [ConnectionStringName("Shop")]
    public class ShopDbContext : AbpDbContext<ShopDbContext>, IShopDbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options)
            : base(options)
        {
        }

        public DbSet<Shop> Shops { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureShop();
        }
    }
}