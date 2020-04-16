using System;
using Volo.Abp.EventBus;

namespace TT.Abp.Shops.Domain
{
    [EventName("TT.Abp.Shops.Shop")]
    public class ShopEto : IShopData
    {
        public Guid Id { get; }
        public Guid? TenantId { get; }
        public string Name { get; }
        public string ShortName { get; }
        public string LogoImage { get; }
        public string CoverImage { get; set; }
        public string Description { get; }
    }
}