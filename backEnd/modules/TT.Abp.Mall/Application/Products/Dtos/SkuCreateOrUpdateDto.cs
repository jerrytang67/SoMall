using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TT.Abp.Mall.Application.Products.Dtos
{
    public class SkuCreateOrUpdateDto
    {
        #region ISkuData
        public Guid SpuId { get; set; }
        [Required]
        [StringLength(MallConsts.MaxNameLength)]
        public string Name { get; set; }
        
        [StringLength(MallConsts.MaxCodeLength)]
        public string Code { get; set; }
        
        public decimal Price { get; set; }

        #endregion
        
        /// <summary>
        /// 原价,非空则显示
        /// </summary>
        public decimal? OriginPrice { get; set; }

        /// <summary>
        /// 会员价或活动价
        /// </summary>
        public decimal? VipPrice { get; set; }

        public List<string> CoverImageUrls { get; set; }
        
        
    }
}