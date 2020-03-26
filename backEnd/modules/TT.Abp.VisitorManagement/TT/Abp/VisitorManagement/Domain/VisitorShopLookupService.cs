using System;
using System.Threading;
using System.Threading.Tasks;
using TT.Abp.Shops;
using TT.Abp.Shops.Domain;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;

namespace TT.Abp.VisitorManagement.Domain
{
    public class VisitorShopLookupService : ShopLookupService<VisitorShop, IVisitorShopRepository>,
        IVisitorShopLookupService
    {
        public VisitorShopLookupService(
            IExternalShopLookupServiceProvider externalShopLookupServiceProvider,
            IVisitorShopRepository shopRepository,
            IUnitOfWorkManager unitOfWorkManager)
            : base(
                shopRepository,
                unitOfWorkManager)
        {
            ExternalShopLookupServiceProvider = externalShopLookupServiceProvider;
        }


        protected override VisitorShop CreateShop(IShopData externalShop)
        {
            return new VisitorShop(externalShop);
        }
    }


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

        public Task<IShopData> FindByShortNameAsync(string shortName, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}