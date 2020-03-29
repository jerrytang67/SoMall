using System;
using System.ComponentModel.DataAnnotations.Schema;
using TT.Abp.Shops;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace TT.Abp.Mall.Domain.Products
{
    public class ProductSku : FullAuditedAggregateRoot<Guid>, IMultiTenant, IMultiShop
    {
        public ProductSku()
        {
        }

        public ProductSku(Guid spuId, string name, string code, decimal price, Guid? shopId, Guid? tenantId)
        {
            SpuId = spuId;
            Name = name;
            Code = code;
            Price = price;
            ShopId = shopId;
            TenantId = tenantId;
        }

        public virtual Guid SpuId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Code { get; set; }
        public virtual decimal Price { get; set; }

        public virtual Guid? TenantId { get; internal set; }

        public Guid? ShopId { get; internal set; }

        [ForeignKey("SpuId")] public virtual ProductSpu Spu { get; set; }
    }
}