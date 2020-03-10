using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace TT.SoMall.Products
{

    public class ProductCategory : AuditedAggregateRoot<Guid>, ISoftDelete, IMultiTenant
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public virtual ICollection<ProductSpu> SpuList { get; set; }

        public bool IsDeleted { get; set; }

        public Guid? TenantId { get; }
    }


    public class ProductSpu : AuditedAggregateRoot<Guid>, ISoftDelete, IMultiTenant
    {
        public Guid CategoryId { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string Desc { get; set; }

        [ForeignKey("CategoryId")]
        public virtual ProductCategory Category { get; set; }

        public bool IsDeleted { get; set; }

        public Guid? TenantId { get; }
    }

    public class ProductSku : AuditedAggregateRoot<Guid>, ISoftDelete, IMultiTenant
    {
        public Guid SpuId { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public decimal Price { get; set; }

        [ForeignKey("SpuId")]
        public virtual ProductSpu Spu { get; set; }

        public bool IsDeleted { get; set; }

        public Guid? TenantId { get; }
    }


}