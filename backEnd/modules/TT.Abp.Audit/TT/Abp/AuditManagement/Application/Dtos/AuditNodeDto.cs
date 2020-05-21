using System;
using TT.Abp.AuditManagement.Domain;
using Volo.Abp.Application.Dtos;

namespace TT.Abp.AuditManagement.Application
{
    /// <summary>
    /// <see cref="AuditNode"/>
    /// </summary>
    public class AuditNodeDto : CreationAuditedEntityDto<Guid>
    {
        public string Desc { get; set; }

        public string UserName { get; set; }

        public Guid UserId { get; set; }

        public int Index { get; set; }

        public Guid AuditFlowId { get; set; }
    }
}