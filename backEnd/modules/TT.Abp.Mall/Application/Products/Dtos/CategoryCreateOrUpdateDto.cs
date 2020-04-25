using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json.Linq;
using TT.Abp.Mall.Domain.Products;

namespace TT.Abp.Mall.Application.Products.Dtos
{
    public class CategoryCreateOrUpdateDto
    {
        [Required]
        [StringLength(MallConsts.MaxNameLength)]
        public string Name { get; set; }

        [StringLength(MallConsts.MaxCodeLength)]
        public string Code { get; set; }

        public string LogoImageUrl { get; set; }

        public Guid? ShopId { get; set; }

        public string RedirectUrl { get; set; }

        public int Sort { get; set; }

        public bool IsGlobal { get; set; }
        
        public List<AppProductCategoryDto> AppProductCategories { get; set; }
        public List<JObject> Apps { get; set; }
    }
}