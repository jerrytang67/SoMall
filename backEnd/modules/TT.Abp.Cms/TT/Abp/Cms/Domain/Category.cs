using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace TT.Abp.Cms.Domain
{
    public class Category : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public string Name { get; set; }
        public Guid? TenantId { get; protected set; }
    }
}