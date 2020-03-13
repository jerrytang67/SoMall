using System;

namespace TT.Abp.ShopManagement
{
    public interface IMayHaveShop
    {
        public Guid? ShopId { get; set; }
    }
}