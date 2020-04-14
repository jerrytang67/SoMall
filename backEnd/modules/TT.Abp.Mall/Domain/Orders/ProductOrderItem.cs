using System;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace TT.Abp.Mall.Domain.Products
{
    public class ProductOrderItem : FullAuditedEntity<Guid>, IMultiTenant
    {
        protected ProductOrderItem(Guid? tenantId)
        {
            TenantId = tenantId;
        }

        public ProductOrderItem(
            Guid id,
            Guid orderId,
            Guid spuId,
            Guid skuId,
            decimal skuPrice
            , double num,
            Guid? tenantId = null) : base(id)
        {
            OrderId = orderId;
            SpuId = spuId;
            SkuId = skuId;
            SkuPrice = skuPrice;
            Num = num;
            TenantId = tenantId;
        }

        public Guid OrderId { get; protected set; }

        public Guid SpuId { get; protected set; }

        public Guid SkuId { get; protected set; }

        public double Num { get; protected set; }

        public decimal SkuPrice { get; protected set; }

        public string SpuName { get; set; }
        public string SkuName { get; set; }
        public string SkuUnit { get; set; }

        public string SkuCoverImageUrl { get; set; }
        public decimal Discount { get; set; }
        public string Comment { get; set; }

        [ForeignKey("OrderId")] public virtual ProductOrder Order { get; set; }

        public Guid? TenantId { get; protected set; }
    }
}