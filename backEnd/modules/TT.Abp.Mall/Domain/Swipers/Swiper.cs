using System;
using JetBrains.Annotations;
using TT.Abp.Shops;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace TT.Abp.Mall.Domain.Swipers
{
    public class Swiper : FullAuditedAggregateRoot<Guid>, IMultiShop, IMultiTenant
    {
        private Swiper()
        {
        }

        public Swiper(
            string groupName, string appName, string coverImageUrl,
            Guid? shopId = null,
            Guid? tenantId = null)
        {
            GroupName = groupName;
            AppName = appName;
            CoverImageUrl = coverImageUrl;
            ShopId = shopId;
            TenantId = tenantId;
        }

        [NotNull] public virtual string GroupName { get; protected set; }

        [NotNull] public virtual string AppName { get; protected set; }

        [NotNull] public virtual string CoverImageUrl { get; protected set; }

        public virtual string Name { get; set; }

        public virtual string RedirectUrl { get; set; }

        public virtual int State { get; set; } = 1;

        public virtual int Sort { get; set; }

        public virtual Guid? ShopId { get; protected set; }

        public virtual Guid? TenantId { get; protected set; }
    }
}