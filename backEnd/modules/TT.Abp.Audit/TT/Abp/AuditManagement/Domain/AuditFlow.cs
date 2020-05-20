using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Volo.Abp.Domain.Entities.Auditing;

namespace TT.Abp.AuditManagement.Domain
{
    public class AuditFlow : FullAuditedAggregateRoot<Guid>
    {
        protected AuditFlow()
        {
        }

        public AuditFlow(
            [NotNull] string auditName,
            bool enable,
            [NotNull] string providerName,
            [CanBeNull] string providerKey,
            ICollection<AuditNode> auditNodes = null)
        {
            AuditName = auditName;
            Enable = enable;
            ProviderName = providerName;
            ProviderKey = providerKey;
            // AuditNodes = auditNodes ?? new List<AuditNode>();
        }

        [NotNull] public virtual string AuditName { get; protected set; }

        //Same AuditName and ProviderName only 1 Entity Enable
        public virtual bool Enable { get; protected set; }

        //This field "G","T","S"
        [NotNull] public virtual string ProviderName { get; protected set; }
        [CanBeNull] public virtual string ProviderKey { get; protected set; }

        // public virtual ICollection<AuditNode> AuditNodes { get; protected set; }
    }
}