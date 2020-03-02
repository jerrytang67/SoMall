using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace TT.SoMall.Products
{
    public class ProductCategoryDto : AuditedEntityDto<Guid>
    {
        public string Name { get; set; }

        public string Code { get; set; }
    }

    public class ProductSpuDto : AuditedEntityDto<Guid>
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public string Desc { get; set; }

        public ProductCategoryDto Category { get; set; }
    }

    public class ProductSkuDto : AuditedEntityDto<Guid>
    {
        public Guid SpuId { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public decimal Price { get; set; }

        public ProductSpuDto Spu { get; set; }
    }



}
