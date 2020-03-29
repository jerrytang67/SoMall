using System;
using System.ComponentModel.DataAnnotations;

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
    }
}