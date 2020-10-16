using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TT.Abp.AuditManagement.Audits;
using Volo.Abp.Application.Services;

namespace TT.Abp.AuditManagement.Application
{
    public interface IAuditManagementAppService : IApplicationService
    {
        Task<IReadOnlyList<AuditDefinition>> GetAllAsync();
        Task<Guid?> GetAsync(AuditRequestInput input);
    }


    public class AuditManagementAppService :
        ApplicationService,
        IAuditManagementAppService
    {
        private readonly IAuditDefinitionManager _auditDefinitionManager;
        private readonly IAuditProvider _auditProvider;

        public AuditManagementAppService(
            IAuditDefinitionManager auditDefinitionManager,
            IAuditProvider auditProvider
        )
        {
            _auditDefinitionManager = auditDefinitionManager;
            _auditProvider = auditProvider;
        }

        [HttpGet]
        public async Task<IReadOnlyList<AuditDefinition>> GetAllAsync()
        {
            return await Task.FromResult(_auditDefinitionManager.GetAll());
        }


        public async Task<Guid?> GetAsync(AuditRequestInput input)
        {
            return await _auditProvider.GetOrNullAsync(input.Name);
        }
    }

    public class AuditRequestInput
    {
        public string Name { get; set; }

        public string ProviderName { get; set; }
    }
}