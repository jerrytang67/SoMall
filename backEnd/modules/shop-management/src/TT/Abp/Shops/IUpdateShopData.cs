using JetBrains.Annotations;
using TT.Abp.Shops.Domain;

namespace TT.Abp.Shops
{
    public interface IUpdateShopData
    {
        bool Update([NotNull] IShopData user);
    }
}