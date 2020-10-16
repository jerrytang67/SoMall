using System;
using System.Threading;
using System.Threading.Tasks;
using TT.Abp.Shops.Domain;

namespace TT.Abp.Shops
{
    public interface IExternalShopLookupServiceProvider
    {
        Task<IShopData> FindByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<IShopData> FindByShortNameAsync(string shortName, CancellationToken cancellationToken = default);
    }
}