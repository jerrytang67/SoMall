using System;
using TT.Abp.Shops;
using Volo.Abp.Uow;

namespace TT.Abp.VisitorManagement.Domain
{
    public class VisitorShopLookupService : ShopLookupService<VisitorShop, IVisitorShopRepository>,
        IVisitorShopLookupService
    {
        public VisitorShopLookupService(
            IVisitorShopRepository shopRepository,
            IUnitOfWorkManager unitOfWorkManager)
            : base(
                shopRepository,
                unitOfWorkManager)
        {
        }

        protected override VisitorShop CreateShop(IShop externalShop)
        {
            return new VisitorShop(externalShop);
        }
    }
}