using Microsoft.EntityFrameworkCore;
using TT.Abp.Shops.Domain;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace TT.Abp.Shops.EntityFrameworkCore
{
    [ConnectionStringName("Shop")]
    public interface IShopDbContext : IEfCoreDbContext
    {
        DbSet<Shop> Shops { get; set; }
    }
}