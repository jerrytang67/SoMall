using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using TT.Abp.Mall.Application.Shops;
using TT.Abp.Mall.Domain.Products;
using TT.Abp.Mall.Domain.Shops;
using TT.Abp.Shops;
using Volo.Abp.Application.Dtos;
using Volo.Abp.MultiTenancy;

namespace TT.Abp.Mall.Application.Products.Dtos
{
    public class ProductSpuDtoBase : ISpuData
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public DateTimeOffset? DateTimeStart { get; set; }
        public DateTimeOffset? DateTimeEnd { get; set; }
        public int? StockCount { get; set; }
        public int SoldCount { get; set; }
        public int? LimitBuyCount { get; set; }
    }

    /// <summary>
    /// <see cref="ProductSpu"/>
    /// </summary>
    public class ProductSpuDto : AuditedEntityDto<Guid>, ISpuData
    {
        public ProductCategoryDto Category { get; set; }

        public MallShopDto Shop { get; set; }

        public Guid? ShopId { get; set; }

        public List<ProductSkuDto> Skus { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        /// <summary>
        /// 商品详情
        /// </summary>
        public string DescCommon { get; set; }

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
    }
}