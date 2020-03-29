using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using TT.Abp.Shops;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace TT.Abp.Mall.Domain.Products
{
    public class ProductSku : FullAuditedAggregateRoot<Guid>, ISkuData, IMultiTenant, IMultiShop
    {
        public ProductSku()
        {
        }

        public ProductSku(Guid spuId, string name, string code, decimal price, Guid? shopId, Guid? tenantId)
        {
            SpuId = spuId;
            Name = name;
            Price = price;
            ShopId = shopId;
            TenantId = tenantId;
        }

        #region ISkuData

        public Guid SpuId { get; protected set; }
        public string Name { get; protected set; }
        public string Code { get; protected set; }
        public decimal Price { get; protected set; }
        public string Desc { get; set; }
        public string PurchaseNotes { get; set; }
        public decimal? OriginPrice { get; protected set; }
        public decimal? VipPrice { get; protected set; }
        public List<string> CoverImageUrls { get; set; }
        public DateTimeOffset? DateTimeStart { get; set; }
        public DateTimeOffset? DateTimeEnd { get; set; }
        public int? StockCount { get; protected set; }
        public int SoldCount { get; protected set; }
        public int? LimitBuyCount { get; protected set; }
        
        public Guid? TenantId { get; protected set; }
        
        public Guid? ShopId { get; protected set; }

        #endregion

        public bool CanBuy()
        {
            if (IsSoldOut())
            {
                return false;
            }

            if (DateTimeOffset.Now < DateTimeStart)
            {
                return false;
            }

            if (DateTimeOffset.Now > DateTimeEnd)
            {
                return false;
            }

            return true;
        }

        public bool IsSoldOut()
        {
            if (StockCount == 0)
                return true;
            return false;
        }

        [ForeignKey("SpuId")] public virtual ProductSpu Spu { get; set; }
    }
}