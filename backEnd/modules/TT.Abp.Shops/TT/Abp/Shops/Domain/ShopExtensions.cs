namespace TT.Abp.Shops.Domain
{
    public static class ShopExtensions
    {
        public static IShopData ToShopData(this IShop shop)
        {
            return new ShopData(
                id: shop.Id,
                tenantId: shop.TenantId,
                name: shop.Name,
                shortName: shop.ShortName,
                logoImage: shop.LogoImage,
                coverImage: shop.CoverImage,
                description: shop.Description
            );
        }
    }
}