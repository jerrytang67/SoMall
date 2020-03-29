using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using TT.Abp.Shops;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace TT.Abp.Mall.Domain.Products
{
    public class ProductSpu : FullAuditedAggregateRoot<Guid>, ISpuData, IMultiTenant, IMultiShop
    {
        public ProductSpu()
        {
        }

        public ProductSpu(Guid categoryId, string name, string code, string desc, Guid? shopId = null, Guid? tenantId = null)
        {
            CategoryId = categoryId;
            Name = name;
            Code = code;
            DescCommon = desc;
            ShopId = shopId;
            TenantId = tenantId;
        }

        public virtual Guid CategoryId { get; internal set; }
        public virtual Guid? TenantId { get; internal set; }
        public virtual Guid? ShopId { get; internal set; }
        public virtual string Name { get; internal set; }

        /// <summary>
        /// 商品编码
        /// </summary>
        public virtual string Code { get; internal set; }

        /// <summary>
        /// 共用商品详情
        /// </summary>
        public virtual string DescCommon { get; set; }

        /// <summary>
        /// 共用购买须知
        /// </summary>
        public virtual string PurchaseNotesCommon { get; set; }

        /// <summary>
        /// 开售时间
        /// </summary>
        public virtual DateTimeOffset? DateTimeStart { get; set; }

        /// <summary>
        /// 结束售卖时间
        /// </summary>
        public virtual DateTimeOffset? DateTimeEnd { get; set; }

        /// <summary>
        /// 限购
        /// </summary>
        public virtual int? LimitBuyCount { get; internal set; }

        /// <summary>
        /// 售出
        /// </summary>
        public virtual int SoldCount { get; internal set; }

        [ForeignKey("CategoryId")] public virtual ProductCategory Category { get; set; }

        public virtual ICollection<ProductSku> Skus { get; set; }
    }
}