using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata;
using TT.Abp.Shops;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace TT.Abp.Mall.Domain.Products
{
    public class ProductOrder : FullAuditedAggregateRoot<Guid>, IMultiTenant, IMultiShop
    {
        public ProductOrder(
            Guid id,
            Guid? shopId = null,
            Guid? tenantId = null) : base(id)
        {
            ShopId = shopId;
            TenantId = tenantId;
        }

        public decimal? PricePaidIn { get; set; } //实收
        public decimal PriceOriginal { get; set; } //原价，应收

        DateTime? DatetimeComplate { get; set; }

        public MallEnums.OrderState State { get; set; } = MallEnums.OrderState.未完成;

        public MallEnums.ProductOrderType Type { get; set; } = MallEnums.ProductOrderType.未标记;

        public MallEnums.PayType PayType { get; set; } = MallEnums.PayType.UnPay;

        public string Comment { get; set; }

        public Guid? BuyerId { get; set; }

        public Guid? AddressId { get; set; }

        public string AddressRealName { get; set; }

        public string AddressNickName { get; set; }

        public string AddressPhone { get; set; }

        public string AddressLocationLable { get; set; }

        public string AddressLocationAddress { get; set; }

        public Guid? ManId { get; set; }

        public int PrintCount { get; set; } = 0; //打印次数统计

        public Guid? TenantId { get; protected set; }

        public Guid? ShopId { get; protected set; }

        public virtual ICollection<ProductOrderItem> OrderItems { get; set; }
    }
}