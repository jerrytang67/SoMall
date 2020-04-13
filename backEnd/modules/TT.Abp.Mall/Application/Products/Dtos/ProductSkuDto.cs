using System;
using System.Collections.Generic;
using TT.Abp.Mall.Domain.Products;
using Volo.Abp.Application.Dtos;

namespace TT.Abp.Mall.Application.Products.Dtos
{
    public class ProductSkuDtoBase : IEntityDto<Guid>, ISkuDataBase
    {
        #region ISkuDataBase

        public Guid SpuId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public decimal Price { get; set; }

        #endregion

        public Guid Id { get; set; }

        /// <summary>
        /// 单张封面.默认用automapper取Urls第一张
        /// </summary>
        public string CoverImageUrl { get; set; }
    }

    /// <summary>
    /// <see cref="ProductSku"/>
    /// </summary>
    public class ProductSkuDto : AuditedEntityDto<Guid>, ISkuData
    {
        #region ISkuData

        public Guid SpuId { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public decimal Price { get; set; }

        /// <summary>
        /// 商品详情
        /// </summary>
        public virtual string Desc { get; set; }

        /// <summary>
        /// 购买须知
        /// </summary>
        public string PurchaseNotes { get; set; }

        /// <summary>
        /// 原价,非空则显示
        /// </summary>
        public decimal? OriginPrice { get; set; }

        /// <summary>
        /// 会员价或活动价
        /// </summary>
        public decimal? VipPrice { get; set; }

        /// <summary>
        /// 封面图片
        /// </summary>
        public List<string> CoverImageUrls { get; set; }

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
        /// 售出
        /// </summary>
        public int SoldCount { get; set; }

        /// <summary>
        /// 限购
        /// </summary>
        public int? LimitBuyCount { get; set; }

        /// <summary>
        /// 计价单位
        /// </summary>
        public string Unit { get; set; }

        #endregion


        // just for client
        public virtual double Num { get; set; }
        
        public virtual string Comment { get; set; }

        public ProductSpuDto Spu { get; set; }
    }
}