using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TT.Abp.Shops;
using Volo.Abp.Domain.Repositories;

namespace TT.Abp.VisitorManagement.Domain
{
    public interface IVisitorShopRepository : IBasicRepository<VisitorShop, Guid>, IShopRepository<VisitorShop>
    {
        Task<List<VisitorShop>> GetShopsAsync(int maxCount, string filter, CancellationToken cancellationToken = default);
    }
}