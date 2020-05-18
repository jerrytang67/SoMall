using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TT.Abp.AuditManagement.Audits;
using Volo.Abp.Application.Services;

namespace TT.Abp.AuditManagement.Application
{
    public class AuditManagementAppService : ApplicationService
    {
        private readonly IAuditDefinitionManager _auditDefinitionManager;

        public AuditManagementAppService(
            IAuditDefinitionManager auditDefinitionManager
        )
        {
            _auditDefinitionManager = auditDefinitionManager;
        }

        [HttpGet]
        public async Task<IReadOnlyList<AuditDefinition>> GetAllAsync()
        {
            return await Task.FromResult(_auditDefinitionManager.GetAll());
        }
    }
}