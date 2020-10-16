namespace TT.Abp.Shops.Domain
{
    public static class ShopExtensions
    {
        public static IShopData ToShopData(this IShop shop)
        {
            return new ShopData(
                shop.Id,
                shop.TenantId,
                shop.Name,
                shop.ShortName,
                shop.LogoImage,
                shop.CoverImage,
                shop.Description
            );
        }
    }
}