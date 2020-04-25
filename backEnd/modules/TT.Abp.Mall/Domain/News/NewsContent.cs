using System;
using System.Diagnostics.CodeAnalysis;
using TT.Abp.Shops;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace TT.Abp.Mall.Domain.News
{
    public class NewsContent : FullAuditedAggregateRoot<Guid>, IMultiShop, IMultiTenant
    {
        public Guid CategoryId { get; set; }

        [NotNull] public string Title { get; set; }

        public string CoverImageUrl { get; set; }

        public string Content { get; set; }

        public int Status { get; set; }
        public int ViewCount { get; protected set; }

        public Guid? ShopId { get; protected set; }

        public Guid? TenantId { get; protected set; }

        public void Viewed()
        {
            ViewCount += 1;
        }

        public virtual NewsCategory Category { get; set; }
    }
}