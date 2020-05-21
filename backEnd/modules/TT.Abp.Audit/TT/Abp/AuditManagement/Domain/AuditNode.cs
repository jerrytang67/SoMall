using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Volo.Abp.Domain.Entities.Auditing;

namespace TT.Abp.AuditManagement.Domain
{
    public class AuditNode : CreationAuditedEntity<Guid>
    {
        public string Desc { get; protected set; }

        // 空间换时间
        [NotNull] public string UserName { get; set; }

        public Guid UserId { get; set; }

        public int Index { get; set; } // 0,1,2

        public Guid AuditFlowId { get; set; }

        [ForeignKey("AuditFlowId")] public virtual AuditFlow AuditFlow { get; set; }
    }
}