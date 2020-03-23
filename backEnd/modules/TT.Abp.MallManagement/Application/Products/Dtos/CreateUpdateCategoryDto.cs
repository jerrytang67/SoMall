using System;
using System.ComponentModel.DataAnnotations;

namespace TT.Abp.MallManagement.Application.Products.Dtos
{
    public class CreateUpdateCategoryDto
    {
        [Required]
        [StringLength(64)]
        public string Name { get; set; }


        [StringLength(32)]
        public string Code { get; set; }
    }

    public class CreateUpdateSpuDto
    {
        public Guid CategoryId { get; set; }

        [Required]
        [StringLength(64)]
        public string Name { get; set; }

        [StringLength(32)]
        public string Code { get; set; }

        public string Desc { get; set; }

    }

    public class CreateUpdateSkuDto
    {
        public Guid SpuId { get; set; }

        [Required]
        [StringLength(64)]
        public string Name { get; set; }

        [StringLength(32)]
        public string Code { get; set; }

        public decimal Price { get; set; }
    }
}
