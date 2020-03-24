using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using TT.Abp.MallManagement.Domain.Products;
using TT.Abp.MallManagement.Domain.Shops;

namespace TT.Abp.MallManagement.EntityFrameworkCore
{
    [ConnectionStringName("MallManagement")]
    public class MallManagementDbContext : AbpDbContext<MallManagementDbContext>, IMallManagementDbContext
    {
        public DbSet<MallShop> MallShops { get; set; }

        public DbSet<ProductSpu> ProductSpu { get; set; }
        public DbSet<ProductSku> ProductSku { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }


        public MallManagementDbContext(DbContextOptions<MallManagementDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureMallManagement();
        }
    }


    public static class MallConsts
    {
        public const string DbTablePrefix = "Mall_";

        public const string DbSchema = null;
    }
}