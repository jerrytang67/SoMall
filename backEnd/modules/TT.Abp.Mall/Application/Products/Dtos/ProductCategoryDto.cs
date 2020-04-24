using System;
using System.Collections.Generic;
using TT.Abp.Mall.Domain.Products;
using TT.Abp.Shops.Application.Dtos;
using Volo.Abp.Application.Dtos;

namespace TT.Abp.Mall.Application.Products.Dtos
{
    /// <summary>
    /// <see cref="ProductCategory"/>
    /// </summary>
    public class ProductCategoryDto : AuditedEntityDto<Guid>
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public string LogoImageUrl { get; set; }

        public string RedirectUrl { get; set; }

        public int Sort { get; set; }

        public bool IsGlobal { get; set; }

        public ShopDto Shop { get; set; }

        public List<ProductSpuDtoBase> Spus { get; set; }

        public int TotalCount { get; set; }
        
        public List<AppProductCategoryDto> AppProductCategories { get; set; }
    }
}