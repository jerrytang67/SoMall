using System;
using System.Threading;
using System.Threading.Tasks;

namespace TT.Abp.Shops
{
    public interface IShopLookupService<TShop>
        where TShop : class, IShop
    {
        Task<TShop> FindByIdAsync(Guid id, CancellationToken cancellationToken = default);

        //TODO: More...
    }
}