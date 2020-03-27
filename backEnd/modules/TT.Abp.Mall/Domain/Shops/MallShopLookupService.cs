using TT.Abp.Shops;
using TT.Abp.Shops.Domain;
using Volo.Abp.Uow;

namespace TT.Abp.Mall.Domain.Shops
{
    public class MallShopLookupService : ShopLookupService<MallShop, IMallShopRepository>,
        IVisitorShopLookupService
    {
        public MallShopLookupService(
            IExternalShopLookupServiceProvider externalShopLookupServiceProvider,
            IMallShopRepository shopRepository,
            IUnitOfWorkManager unitOfWorkManager)
            : base(
                shopRepository,
                unitOfWorkManager)
        {
            ExternalShopLookupServiceProvider = externalShopLookupServiceProvider;
        }


        protected override MallShop CreateShop(IShopData externalShop)
        {
            return new MallShop(externalShop);
        }
    }
}