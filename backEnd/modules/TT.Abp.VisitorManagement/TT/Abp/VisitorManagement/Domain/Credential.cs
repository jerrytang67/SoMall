using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace TT.Abp.VisitorManagement.Domain
{
    // 用户凭证
    public class Credential : CreationAuditedAggregateRoot<Guid>, ISoftDelete, IMultiTenant
    {
        public Credential(Guid? tenantId)
        {
            TenantId = tenantId;
        }

        public VisitorEnums.CredentialType Type { get; set; }

        public string Data { get; set; }

        public int UseTimes { get; internal set; }
        public Guid? TenantId { get; protected set; }

        public bool IsDeleted { get; set; }

        internal void Use()
        {
            UseTimes += 1;
        }
    }
}