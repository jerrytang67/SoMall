using System;
using JetBrains.Annotations;

namespace TT.Abp.Mall.Domain.Products
{
    public interface ISpuData
    {
        /// <summary>
        ///     商品名称
        /// </summary>
        [NotNull]
        string Name { get; }

        /// <summary>
        ///     商品编码
        /// </summary>
        [NotNull]
        string Code { get; }

        /// <summary>
        ///     开售时间
        /// </summary>
        DateTimeOffset? DateTimeStart { get; }

        /// <summary>
        ///     结束售卖时间
        /// </summary>
        DateTimeOffset? DateTimeEnd { get; }

        /// <summary>
        ///     总售出
        /// </summary>
        int SoldCount { get; }

        /// <summary>
        ///     限购
        /// </summary>
        int? LimitBuyCount { get; }
    }
}