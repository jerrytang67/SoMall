using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Volo.Abp.Domain.Entities.Auditing;

namespace TT.Abp.AuditManagement.Domain
{
    public class AuditFlow : FullAuditedAggregateRoot<Guid>
    {
        [NotNull] public virtual string AuditName { get; set; }

        //Same AuditName and ProviderName only 1 Entity Enable
        public virtual bool Enable { get; set; }

        //This field "G","T","S"
        [NotNull] public virtual string ProviderName { get; set; }
        [CanBeNull] public virtual string ProviderKey { get; set; }

        public virtual ICollection<AuditNode> AuditNodes { get; set; }
    }
}