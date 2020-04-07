using System;
using TT.Abp.Shops;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace TT.Abp.Mall.Domain.Comments
{
    public class Comment : FullAuditedEntity<Guid>, IMultiTenant, IMultiShop
    {
        public Comment(Guid spuId, Guid? skuId = null, Guid? tenantId = null, Guid? shopId = null)
        {
            SpuId = spuId;
            SkuId = skuId;
            TenantId = tenantId;
            ShopId = shopId;
        }

        public string BuyerName { get; set; }

        public string BuyerAvatar { get; set; }

        public string Content { get; set; }

        public int Level { get; set; }

        public int Status { get; set; }
        public Guid SpuId { get; protected set; }
        public Guid? SkuId { get; protected set; }
        public Guid? TenantId { get; protected set; }
        public Guid? ShopId { get; protected set; }
    }
}