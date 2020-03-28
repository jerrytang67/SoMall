using System;
using System.ComponentModel.DataAnnotations;

namespace TT.Abp.Mall.Application.Products.Dtos
{
    public class SpuCreateOrUpdateDto
    {
        public Guid CategoryId { get; set; }

        [Required] [StringLength(64)] public string Name { get; set; }

        [StringLength(32)] public string Code { get; set; }

        public string Desc { get; set; }
    }
}