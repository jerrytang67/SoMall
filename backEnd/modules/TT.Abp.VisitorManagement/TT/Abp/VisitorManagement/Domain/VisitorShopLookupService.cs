using TT.Abp.Shops;
using TT.Abp.Shops.Domain;
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
}