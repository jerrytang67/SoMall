using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using TT.Abp.Shops;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace TT.Abp.Mall.Domain.Products
{
    public class ProductCategory : FullAuditedAggregateRoot<Guid>, IMultiTenant, IMultiShop
    {
        public ProductCategory()
        {
        }

        public ProductCategory(string name, string code, Guid? shopId = null, Guid? tenantId = null)
        {
            Name = name;
            Code = code;
            ShopId = shopId;
            TenantId = tenantId;
        }

        public virtual string Name { get; protected set; }
        public virtual string Code { get; protected set; }
        public virtual string LogoImageUrl { get; set; }
        [CanBeNull] public virtual string RedirectUrl { get; set; }
        public virtual ICollection<ProductSpu> SpuList { get; set; }

        public virtual int Sort { get; set; }

        /// <summary>
        ///     全部APP显示
        /// </summary>
        public virtual bool IsGlobal { get; set; }

        public virtual ICollection<AppProductCategory> AppProductCategories { get; set; }
        public virtual Guid? ShopId { get; protected set; }
        public virtual Guid? TenantId { get; protected set; }
    }


    public class AppProductCategoryDto
    {
        public string AppName { get; set; }
        public Guid ProductCategoryId { get; set; }
        public string ProductCategoryName { get; set; }
        public virtual int Sort { get; set; }
    }
}