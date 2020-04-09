using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata;
using TT.Abp.Shops;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace TT.Abp.Mall.Domain.Products
{
    public class ProductOrder : FullAuditedAggregateRoot<Guid>, IMultiTenant, IMultiShop
    {
        public decimal? PricePaidIn { get; set; } //实收
        public decimal PriceOriginal { get; set; } //原价，应收

        DateTime? DatetimeComplate { get; set; }

        public OrderState State { get; set; } = 0;

        public OrderType Type { get; set; } = OrderType.未标记;

        public PayType PayType { get; set; } = PayType.未付;

        public string Comment { get; set; }

        public Guid? BuyerId { get; set; }

        public Guid? AddressId { get; set; }

        public string AddressRealName { get; set; }

        public string AddressNickName { get; set; }

        public string AddressPhone { get; set; }

        public string AddressLocationLable { get; set; }

        public Guid? ManId { get; set; }

        public int PrintCount { get; set; } = 0; //打印次数统计

        public Guid? TenantId { get; protected set; }

        public Guid? ShopId { get; protected set; }

        public virtual ICollection<ProductOrderItem> OrderItems { get; set; }
    }

    public class ProductOrderItem : FullAuditedEntity<Guid>
    {
        public Guid OrderId { get; set; }

        public Guid SpuId { get; set; }

        public Guid SkuId { get; set; }

        public Double Count { get; set; } = 0;

        public string SpuName { get; set; }

        public string SkuName { get; set; }

        public decimal SkuPrice { get; set; }

        public string SkuUnit { get; set; }

        public string Comment { get; set; }

        [ForeignKey("OrderId")] public virtual ProductOrder Order { get; set; }
    }


    public enum OrderState : int
    {
        已取消 = -1,
        未完成 = 0,
        正在派送 = 2,
        派送完成 = 4,
        完成 = 9
    }

    public enum OrderType : int
    {
        未标记 = 0,
        零售 = 1,
        外送 = 2,
        自提 = 3,
        跑腿 = 4,
        美团 = 5
    }

    public enum PayType : int
    {
        未付 = 0,
        现金 = 1,
        微信 = 2,
        支付宝 = 3,
        会员卡 = 11,
        美团 = 12
    }

    public enum LocationType
    {
        bd09 = 0,
        gcj02 = 1,
        wgs84 = 2
    }
}