using System;
using System.Collections.Generic;
using TT.Abp.Shops.Application.Dtos;
using Volo.Abp.Application.Dtos;

namespace TT.Abp.Mall.Application.Products.Dtos
{
    public class ProductCategoryDto : AuditedEntityDto<Guid>
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public string LogoImageUrl { get; set; }

        public ShopDto Shop { get; set; }

        public List<ProductSpuDtoBase> Spus { get; set; }

        public int TotalCount { get; set; }
    }
}