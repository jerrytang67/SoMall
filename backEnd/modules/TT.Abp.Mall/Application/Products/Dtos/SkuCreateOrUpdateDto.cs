using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TT.Abp.Mall.Definitions;
using TT.Abp.Mall.Domain.Products;

namespace TT.Abp.Mall.Application.Products.Dtos
{
    /// <summary>
    /// <see cref="ProductSku"/>
    /// <see cref="ProductSkuDto"/>
    /// </summary>
    public class SkuCreateOrUpdateDto
    {
        #region ISkuData

        public Guid? Id { get; set; }

        public Guid? SpuId { get; set; }

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

        public string Desc { get; set; }

        public string PurchaseNotes { get; set; }

        public List<string> CoverImageUrls { get; set; }

        public DateTimeOffset? DateTimeStart { get; set; }

        public DateTimeOffset? DateTimeEnd { get; set; }

        public int? StockCount { get; set; }

        public int SoldCount { get; set; }

        public int? LimitBuyCount { get; set; }
        
        public string Unit { get; set; }
    }
}