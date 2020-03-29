using System;
using Volo.Abp.Application.Dtos;

namespace TT.Abp.Mall.Application.Products.Dtos
{
    public class ProductSkuDto : AuditedEntityDto<Guid>
    {
        public Guid SpuId { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public decimal Price { get; set; }

        public ProductSpuDto Spu { get; set; }
    }
}