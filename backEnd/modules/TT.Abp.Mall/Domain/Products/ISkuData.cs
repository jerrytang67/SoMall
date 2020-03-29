using System;
using System.Collections.Generic;

namespace TT.Abp.Mall.Domain.Products
{
    public interface ISkuData : ISkuDataBase
    {
        /// <summary>
        /// 商品详情
        /// </summary>
        string Desc { get; }

        /// <summary>
        /// 购买须知
        /// </summary>
        string PurchaseNotes { get; }

        /// <summary>
        /// 原价,非空则显示
        /// </summary>
        decimal? OriginPrice { get; }

        /// <summary>
        /// 会员价或活动价
        /// </summary>
        decimal? VipPrice { get; }

        /// <summary>
        /// 封面图片
        /// </summary>
        List<string> CoverImageUrls { get; }

        /// <summary>
        /// 开售时间
        /// </summary>
        DateTimeOffset? DateTimeStart { get; }

        /// <summary>
        /// 结束售卖时间
        /// </summary>
        DateTimeOffset? DateTimeEnd { get; }

        /// <summary>
        /// 库存
        /// </summary>
        int? StockCount { get; }

        /// <summary>
        /// 售出
        /// </summary>
        int SoldCount { get; }

        /// <summary> 
        /// 限购
        /// </summary>
        int? LimitBuyCount { get; }
    }
}