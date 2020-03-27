using Microsoft.EntityFrameworkCore;
using TT.Abp.Mall.Domain.Products;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace TT.Abp.Mall.EntityFrameworkCore
{
    [ConnectionStringName("Mall")]
    public interface IMallDbContext : IEfCoreDbContext
    {
        DbSet<ProductSpu> ProductSpu { get; set; }
        DbSet<ProductSku> ProductSku { get; set; }
        DbSet<ProductCategory> ProductCategory { get; set; }
    }
}