using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace TT.Abp.Mall.Domain.Products
{
    public class ProductCategory : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public ProductCategory()
        {
        }

        public ProductCategory(string name, string code, Guid? tenantId)
        {
            Name = name;
            Code = code;
            TenantId = tenantId;
        }

        public virtual string Name { get; set; }
        public virtual string Code { get; set; }

        public virtual ICollection<ProductSpu> SpuList { get; set; }
        public virtual Guid? TenantId { get; }
    }


    public class ProductSpu : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public ProductSpu()
        {
        }

        public ProductSpu(Guid categoryId, string name, string code, string desc, Guid? tenantId)
        {
            CategoryId = categoryId;
            Name = name;
            Code = code;
            Desc = desc;
            TenantId = tenantId;
        }

        public virtual Guid CategoryId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Code { get; set; }
        public virtual string Desc { get; set; }

        public virtual Guid? TenantId { get; }


        [ForeignKey("CategoryId")] public virtual ProductCategory Category { get; set; }
    }

    public class ProductSku : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public ProductSku()
        {
        }

        public ProductSku(Guid spuId, string name, string code, decimal price, Guid? tenantId)
        {
            SpuId = spuId;
            Name = name;
            Code = code;
            Price = price;
            TenantId = tenantId;
        }


        public virtual Guid SpuId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Code { get; set; }
        public virtual decimal Price { get; set; }

        [ForeignKey("SpuId")] public virtual ProductSpu Spu { get; set; }
        public virtual Guid? TenantId { get; }
    }
}