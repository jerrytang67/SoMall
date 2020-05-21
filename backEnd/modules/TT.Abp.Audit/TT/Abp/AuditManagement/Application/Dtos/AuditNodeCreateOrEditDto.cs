using System;

namespace TT.Abp.AuditManagement.Application.Dtos
{
    public class AuditNodeCreateOrEditDto
    {
        public Guid Id { get; set; }

        public string Desc { get; set; }

        public string UserName { get; set; }

        public Guid UserId { get; set; }

        public int Index { get; set; }

        public Guid AuditFlowId { get; set; }
    }
}