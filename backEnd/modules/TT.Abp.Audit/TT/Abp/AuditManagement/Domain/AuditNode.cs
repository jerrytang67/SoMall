using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace TT.Abp.AuditManagement.Domain
{
    public class AuditNode : CreationAuditedEntity<Guid>
    {
        public string Desc { get; protected set; }
    }
}