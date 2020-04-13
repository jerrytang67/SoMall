using System;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities.Auditing;

namespace TT.Abp.Mall.Domain.Products
{
    public class ProductOrderItem : FullAuditedEntity<Guid>
    {
        protected ProductOrderItem()
        {
        }

        public ProductOrderItem(
            Guid id,
            Guid orderId,
            Guid spuId,
            Guid skuId,
            decimal skuPrice
            , double num
        ) : base(id)
        {
            OrderId = orderId;
            SpuId = spuId;
            SkuId = skuId;
            SkuPrice = skuPrice;
            Num = num;
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
    }
}