using System;
using System.Collections.Generic;
using TT.Abp.Shops;
using TT.Abp.Shops.Domain;
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
        public virtual ICollection<ProductSpu> SpuList { get; set; }
        public virtual Guid? TenantId { get; protected set; }
        public virtual Guid? ShopId { get; protected set; }
    }
}