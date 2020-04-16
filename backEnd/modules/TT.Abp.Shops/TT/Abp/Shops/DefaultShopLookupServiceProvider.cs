using System;
using System.Threading;
using System.Threading.Tasks;
using TT.Abp.Shops.Domain;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace TT.Abp.Shops
{
    public class DefaultShopLookupServiceProvider : IExternalShopLookupServiceProvider, ITransientDependency
    {
        public readonly IRepository<Shop> ShopRepository;

        public DefaultShopLookupServiceProvider(IRepository<Shop> repository)
        {
            ShopRepository = repository;
        }

        public async Task<IShopData> FindByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return (
                await ShopRepository.FindAsync(
                    z => z.Id == id,
                    false,
                    cancellationToken
                )
            )?.ToShopData();
        }

        public async Task<IShopData> FindByShortNameAsync(string shortName, CancellationToken cancellationToken = default)
        {
            return (
                await ShopRepository.FindAsync(
                    z => z.ShortName == shortName,
                    false,
                    cancellationToken
                )
            )?.ToShopData();
        }
    }
}