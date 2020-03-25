using JetBrains.Annotations;

namespace TT.Abp.Shops
{
    public interface IUpdateShopData
    {
        bool Update([NotNull] IShop user);
    }
}