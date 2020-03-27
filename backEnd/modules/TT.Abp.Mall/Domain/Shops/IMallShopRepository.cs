using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TT.Abp.Shops;
using Volo.Abp.Domain.Repositories;

namespace TT.Abp.Mall.Domain.Shops
{
    public interface IMallShopRepository : IShopRepository<MallShop>
    {
        Task<List<MallShop>> GetShopsAsync(int maxCount, string filter, CancellationToken cancellationToken = default);
    }
}