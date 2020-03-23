using TT.Abp.ShopManagement.Domain;

namespace TT.Abp.MallManagement.Application.Shops
{
    public class MallShop : IShopData
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string LogoImage { get; set; }
        public string Description { get; set; }
    }
}