using System;
using JetBrains.Annotations;
using Volo.Abp.Auditing;
using Volo.Abp.Data;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace TT.Abp.Cms.Domain
{
    [DisableAuditing]
    public class Category : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public Category()
        {
            this.SetProperty("new", "123");
        }

        [NotNull] public string Name { get; set; }
        
        public Guid? TenantId { get; protected set; }
    }
}