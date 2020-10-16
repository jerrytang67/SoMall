using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TT.Abp.Shops;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace TT.Abp.Mall.Domain.News
{
    public class NewsCategory : FullAuditedAggregateRoot<Guid>, IMultiShop, IMultiTenant
    {
        [NotNull] public string Name { get; set; }

        public virtual ICollection<NewsContent> Contents { get; set; }

        public Guid? ShopId { get; protected set; }

        public Guid? TenantId { get; protected set; }
    }
}