using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TT.Abp.AuditManagement.Application
{
    public class AuditFlowCreateOrEditDto
    {
        [Required] public string AuditName { get; set; }
        public bool Enable { get; set; }
        [Required] public string ProviderName { get; set; }
        public string ProviderKey { get; set; }

        public List<AuditNodeCreateOrEditDto> AuditNodes { get; set; }
    }
}