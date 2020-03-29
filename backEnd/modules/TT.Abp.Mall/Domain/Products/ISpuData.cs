using System;
using JetBrains.Annotations;

namespace TT.Abp.Mall.Domain.Products
{
    public interface ISpuData
    {
        /// <summary>
        /// 商品名称
        /// </summary>
        [NotNull]
        string Name { get; set; }

        /// <summary>
        /// 商品编码
        /// </summary>
        [NotNull]
        string Code { get; set; }

        /// <summary>
        /// 开售时间
        /// </summary>
        DateTimeOffset? DateTimeStart { get; set; }

        /// <summary>
        /// 结束售卖时间
        /// </summary>
        DateTimeOffset? DateTimeEnd { get; set; }

        /// <summary>
        /// 库存
        /// </summary>
        int? StockCount { get; set; }

        /// <summary>
        /// 总售出
        /// </summary>
        int SoldCount { get; set; }

        /// <summary>
        /// 限购
        /// </summary>
        int? LimitBuyCount { get; set; }
    }
}