using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using TT.Abp.Shops.Domain;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;

namespace TT.Abp.Shops
{
    public abstract class ShopLookupService<TShop, TShopRepository> : IShopLookupService<TShop>, ITransientDependency
        where TShop : class, IShop
        where TShopRepository : IShopRepository<TShop>
    {
        protected bool SkipExternalLookupIfLocalUserExists { get; set; } = true;

        public IExternalShopLookupServiceProvider ExternalShopLookupServiceProvider { get; set; }
        public ILogger<ShopLookupService<TShop, TShopRepository>> Logger { get; set; }

        private readonly TShopRepository _shopRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        protected ShopLookupService(
            TShopRepository shopRepository,
            IUnitOfWorkManager unitOfWorkManager)

        {
            _shopRepository = shopRepository;
            _unitOfWorkManager = unitOfWorkManager;
            Logger = NullLogger<ShopLookupService<TShop, TShopRepository>>.Instance;
        }

        public async Task<TShop> FindByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var localShop = await _shopRepository.FindAsync(id, cancellationToken: cancellationToken);

            if (ExternalShopLookupServiceProvider == null)
            {
                return localShop;
            }

            if (SkipExternalLookupIfLocalUserExists && localShop != null)
            {
                return localShop;
            }

            IShopData externalShop;

            try
            {
                externalShop = await ExternalShopLookupServiceProvider.FindByIdAsync(id, cancellationToken);
                if (externalShop == null)
                {
                    if (localShop != null)
                    {
                        //TODO: Instead of deleting, should be make it inactive or something like that?
                        await WithNewUowAsync(() => _shopRepository.DeleteAsync(localShop, cancellationToken: cancellationToken));
                    }

                    return null;
                }
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
                return localShop;
            }

            if (localShop == null)
            {
                var create = CreateShop(externalShop);
                await WithNewUowAsync(() => _shopRepository.InsertAsync(create, cancellationToken: cancellationToken));
                return await _shopRepository.FindAsync(id, cancellationToken: cancellationToken);
            }

            if (localShop is IUpdateShopData && ((IUpdateShopData) localShop).Update(externalShop))
            {
                await WithNewUowAsync(() => _shopRepository.UpdateAsync(localShop, cancellationToken: cancellationToken));
            }
            else
            {
                return localShop;
            }

            return await _shopRepository.FindAsync(id, cancellationToken: cancellationToken);
        }


        protected abstract TShop CreateShop(IShopData externalShop);

        private async Task WithNewUowAsync(Func<Task> func)
        {
            using (var uow = _unitOfWorkManager.Begin(requiresNew: true))
            {
                await func();
                await uow.SaveChangesAsync();
            }
        }
    }
}