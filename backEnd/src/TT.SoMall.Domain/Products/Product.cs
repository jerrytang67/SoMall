using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities.Auditing;

namespace TT.SoMall.Products
{

    public class ProductCategory : AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public virtual ICollection<ProductSpu> SpuList { get; set; }
    }


    public class ProductSpu : AuditedAggregateRoot<Guid>
    {
        public Guid CategoryId { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string Desc { get; set; }

        [ForeignKey("CategoryId")]
        public virtual ProductCategory Category { get; set; }
    }

    public class ProductSku : AuditedAggregateRoot<Guid>
    {
        public Guid SpuId { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public decimal Price { get; set; }

        [ForeignKey("SpuId")]
        public virtual ProductSpu Spu { get; set; }
    }


}