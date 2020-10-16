using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using TT.Abp.Mall.Events.Products;
using TT.Abp.Shops;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Guids;
using Volo.Abp.MultiTenancy;

namespace TT.Abp.Mall.Domain.Products
{
    public class ProductSku : FullAuditedAggregateRoot<Guid>, ISkuData, IMultiTenant, IMultiShop
    {
        protected ProductSku()
        {
        }

        public ProductSku(string name)
        {
            Name = name;
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

        public virtual Guid SpuId { get; protected set; }
        public virtual string Name { get; protected set; }
        public virtual string Code { get; protected set; }
        public virtual decimal Price { get; protected set; }
        public virtual string Desc { get; set; }
        public virtual string PurchaseNotes { get; set; }
        public virtual decimal? OriginPrice { get; protected set; }
        public virtual decimal? VipPrice { get; protected set; }
        public virtual List<string> CoverImageUrls { get; set; }
        public virtual DateTimeOffset? DateTimeStart { get; set; }
        public virtual DateTimeOffset? DateTimeEnd { get; set; }
        public virtual int? StockCount { get; protected set; }

        public virtual int SoldCount { get; protected set; }

        public virtual int? LimitBuyCount { get; protected set; }
        public virtual string Unit { get; set; }
        public virtual Guid? TenantId { get; protected set; }
        public virtual Guid? ShopId { get; protected set; }

        #region 佣金字段
        public virtual decimal? CommissionPrice { get; protected set; }
        public virtual bool CommissionEnable { get; protected set; }

        #endregion

        #endregion

        public void SetAndEnableCommission(decimal price)
        {
            CommissionEnable = true;
            CommissionPrice = price;
            AddLocalEvent(new CommissionChangeEvent(this));
        }

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


        public void SetTenant(Guid? tenantId)
        {
            TenantId = tenantId;
        }

        public void NewId(IGuidGenerator guidGenerator)
        {
            Id = guidGenerator.Create();
        }

        [ForeignKey("SpuId")] public virtual ProductSpu Spu { get; set; }
    }
}