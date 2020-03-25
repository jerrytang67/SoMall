using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;

namespace TT.Abp.Shops
{
    public abstract class ShopLookupService<TShop, TShopRepository> : IShopLookupService<TShop>, ITransientDependency
        where TShop : class, IShop
        where TShopRepository : IShopRepository<TShop>
    {
        protected bool SkipExternalLookupIfLocalUserExists { get; set; } = true;

        //public IExternalUserLookupServiceProvider ExternalUserLookupServiceProvider { get; set; }
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

            return localShop;


            // if (ExternalUserLookupServiceProvider == null)
            // {
            //     return localUser;
            // }
            //
            // if (SkipExternalLookupIfLocalUserExists && localUser != null)
            // {
            //     return localUser;
            // }
            //
            // IUserData externalUser;
            //
            // try
            // {
            //     externalUser = await ExternalUserLookupServiceProvider.FindByIdAsync(id, cancellationToken);
            //     if (externalUser == null)
            //     {
            //         if (localUser != null)
            //         {
            //             //TODO: Instead of deleting, should be make it inactive or something like that?
            //             await WithNewUowAsync(() => _userRepository.DeleteAsync(localUser, cancellationToken: cancellationToken));
            //         }
            //
            //         return null;
            //     }
            // }
            // catch (Exception ex)
            // {
            //     Logger.LogException(ex);
            //     return localUser;
            // }
            //
            // if (localUser == null)
            // {
            //     await WithNewUowAsync(() => _userRepository.InsertAsync(CreateUser(externalUser), cancellationToken: cancellationToken));
            //     return await _userRepository.FindAsync(id, cancellationToken: cancellationToken);
            // }
            //
            // if (localUser is IUpdateShopData && ((IUpdateShopData) localUser).Update(externalUser))
            // {
            //     await WithNewUowAsync(() => _userRepository.UpdateAsync(localUser, cancellationToken: cancellationToken));
            // }
            // else
            // {
            //     return localUser;
            // }
            //
            // return await _userRepository.FindAsync(id, cancellationToken: cancellationToken);
        }


        protected abstract TShop CreateUser(IShop externalShop);

        private async Task WithNewUowAsync(Func<Task> func)
        {
            using (var uow = _unitOfWorkManager.Begin(requiresNew: true))
            {
                await func();
                await uow.SaveChangesAsync();
            }
        }
    }

    public interface IShopLookupService<TShop>
        where TShop : class, IShop
    {
        Task<TShop> FindByIdAsync(Guid id, CancellationToken cancellationToken = default);

        //TODO: More...
    }
}