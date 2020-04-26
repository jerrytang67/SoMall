using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json.Linq;
using TT.Abp.AppManagement.Application;
using TT.Abp.Mall.Domain.Products;
using TT.Abp.Shops;

namespace TT.Abp.Mall.Application.Products.Dtos
{
    public class SpuCreateOrUpdateDto
    {
        public Guid? ShopId { get; set; }

        public Guid CategoryId { get; set; }

        [Required]
        [StringLength(MallConsts.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(MallConsts.MaxCodeLength)]
        public string Code { get; set; }

        /// <summary>
        /// 商品详情
        /// </summary>
        public virtual string DescCommon { get; set; }

        /// <summary>
        /// 购买须知
        /// </summary>
        public string PurchaseNotesCommon { get; set; }

        /// <summary>
        /// 开售时间
        /// </summary>
        public DateTimeOffset? DateTimeStart { get; set; }

        /// <summary>
        /// 结束售卖时间
        /// </summary>
        public DateTimeOffset? DateTimeEnd { get; set; }

        /// <summary>
        /// 库存
        /// </summary>
        public int? StockCount { get; set; }

        /// <summary>
        /// 总售出
        /// </summary>
        public int SoldCount { get; set; }

        /// <summary>
        /// 限购
        /// </summary>
        public int? LimitBuyCount { get; set; }

        public List<SkuCreateOrUpdateDto> Skus { get; set; } = new List<SkuCreateOrUpdateDto>();
        
        public List<AppProductSpu> AppProductSpus { get; set; } = new List<AppProductSpu>();
        
        public List<JObject> Apps { get; set; }
    }
}