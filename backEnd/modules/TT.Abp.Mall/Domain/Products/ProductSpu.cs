using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using JetBrains.Annotations;
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
            Desc = desc;
            ShopId = shopId;
            TenantId = tenantId;
        }

        public virtual Guid CategoryId { get; set; }
        public virtual Guid? TenantId { get; internal set; }
        public virtual Guid? ShopId { get; internal set; }

        public virtual string Name { get; set; }

        /// <summary>
        /// 商品编码
        /// </summary>
        public virtual string Code { get; set; }

        /// <summary>
        /// 商品详情
        /// </summary>
        public virtual string Desc { get; set; }

        /// <summary>
        /// 购买须知
        /// </summary>
        public string PurchaseNotes { get; set; }

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

        public bool CanBuy()
        {
            if (IsSoldOut())
            {
                return false;
            }

            if (DateTimeOffset.Now < DateTimeStart)
            {
                return false;
            }

            if (DateTimeOffset.Now > DateTimeEnd)
            {
                return false;
            }

            return true;
        }


        public bool IsSoldOut()
        {
            if (StockCount == 0)
                return true;
            return false;
        }


        [ForeignKey("CategoryId")] public virtual ProductCategory Category { get; set; }

        public virtual ICollection<ProductSku> Skus { get; set; }
    }
}