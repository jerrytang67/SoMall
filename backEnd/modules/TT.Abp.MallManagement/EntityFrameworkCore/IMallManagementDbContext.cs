using Microsoft.EntityFrameworkCore;
using TT.Abp.MallManagement.Domain.Products;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace TT.Abp.MallManagement.EntityFrameworkCore
{
    [ConnectionStringName("MallManagement")]
    public interface IMallManagementDbContext: IEfCoreDbContext
    {
        DbSet<ProductSpu> ProductSpu { get; set; }
        DbSet<ProductSku> ProductSku { get; set; }
        DbSet<ProductCategory> ProductCategory { get; set; }
    }
}