using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using TT.Abp.Shops;
using TT.Abp.Shops.Domain;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace TT.Abp.Mall.Domain.Products
{
    public class ProductCategory : FullAuditedAggregateRoot<Guid>, IMultiTenant, IMultiShop
    {
        public ProductCategory()
        {
        }

        public ProductCategory(string name, string code, Guid? shopId, Guid? tenantId)
        {
            Name = name;
            Code = code;
            ShopId = shopId;
            TenantId = tenantId;
        }

        public virtual string Name { get; set; }
        public virtual string Code { get; set; }

        public virtual ICollection<ProductSpu> SpuList { get; set; }
        public virtual Guid? TenantId { get; internal set; }
        public Guid? ShopId { get; internal set; }
    }


    public class ProductSpu : FullAuditedAggregateRoot<Guid>, IMultiTenant, IMultiShop
    {
        public ProductSpu()
        {
        }

        public ProductSpu(Guid categoryId, string name, string code, string desc, Guid? shopId, Guid? tenantId)
        {
            CategoryId = categoryId;
            Name = name;
            Code = code;
            Desc = desc;
            ShopId = shopId;
            TenantId = tenantId;
        }

        public virtual Guid CategoryId { get; set; }

        public virtual string Name { get; set; }
        public virtual string Code { get; set; }
        public virtual string Desc { get; set; }
        public virtual Guid? TenantId { get; internal set; }

        public virtual Guid? ShopId { get; internal set; }

        [ForeignKey("CategoryId")] public virtual ProductCategory Category { get; set; }
    }

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