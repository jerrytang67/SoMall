using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace TT.Abp.Shops
{
    public interface IShopRepository<TShop> : IBasicRepository<TShop, Guid>
        where TShop : class, IShop, IAggregateRoot<Guid>
    {
        Task<TShop> FindByShortNameAsync(string shortName, CancellationToken cancellationToken = default);

        Task<List<TShop>> GetListAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default);
    }
}