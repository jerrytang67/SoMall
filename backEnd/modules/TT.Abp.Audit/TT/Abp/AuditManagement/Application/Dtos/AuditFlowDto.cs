using System;
using System.Collections.Generic;
using TT.Abp.AuditManagement.Domain;
using Volo.Abp.Application.Dtos;

namespace TT.Abp.AuditManagement.Application.Dtos
{
    /// <summary>
    /// <see cref="AuditFlow"/>
    /// </summary>
    public class AuditFlowDto : CreationAuditedEntityDto<Guid>
    {
        public string AuditName { get; set; }
        public bool Enable { get; set; }
        public string ProviderName { get; set; }
        public string ProviderKey { get; set; }

        public List<AuditNodeDto> AuditNodes { get; set; }
    }
}