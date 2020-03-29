using System;
using System.Collections.Generic;

namespace TT.Abp.Mall.Domain.Products
{
    public interface ISkuData : ISkuDataBase
    {
        /// <summary>
        /// 商品详情
        /// </summary>
        public virtual string Desc { get; }

        /// <summary>
        /// 购买须知
        /// </summary>
        public string PurchaseNotes { get; }

        /// <summary>
        /// 原价,非空则显示
        /// </summary>
        public decimal? OriginPrice { get; }

        /// <summary>
        /// 会员价或活动价
        /// </summary>
        public decimal? VipPrice { get; }

        /// <summary>
        /// 封面图片
        /// </summary>
        public List<string> CoverImageUrls { get; }

        /// <summary>
        /// 开售时间
        /// </summary>
        public DateTimeOffset? DateTimeStart { get; }

        /// <summary>
        /// 结束售卖时间
        /// </summary>
        public DateTimeOffset? DateTimeEnd { get; }

        /// <summary>
        /// 库存
        /// </summary>
        public int? StockCount { get; }

        /// <summary>
        /// 售出
        /// </summary>
        public int SoldCount { get; }

        /// <summary> 
        /// 限购
        /// </summary>
        public int? LimitBuyCount { get; }
    }
}