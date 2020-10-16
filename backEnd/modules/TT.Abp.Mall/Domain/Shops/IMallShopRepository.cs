using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TT.Abp.Shops;

namespace TT.Abp.Mall.Domain.Shops
{
    public interface IMallShopRepository : IShopRepository<MallShop>
    {
        Task<List<MallShop>> GetShopsAsync(int maxCount, string filter, CancellationToken cancellationToken = default);
        Task<List<MallShop>> GetShopsAsync(List<Guid> ids, CancellationToken cancellationToken = default);
    }
}