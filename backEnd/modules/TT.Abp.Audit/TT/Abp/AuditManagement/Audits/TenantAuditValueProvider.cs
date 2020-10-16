using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TT.Abp.AuditManagement.Domain;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Uow;

namespace TT.Abp.AuditManagement.Audits
{
    public class TenantAuditValueProvider : AuditValueProvider
    {
        public const string ProviderName = "T";
        private readonly ICurrentTenant _currentTenant;

        public TenantAuditValueProvider(
            IRepository<AuditFlow, Guid> auditFlowRepository,
            ICurrentTenant currentTenant
        ) : base(auditFlowRepository)
        {
            _currentTenant = currentTenant;
        }

        public override string Name => ProviderName;

        [UnitOfWork]
        public override async Task<Guid?> GetOrNullAsync(AuditDefinition audit)
        {
            var tenantId = _currentTenant.Id?.ToString();

            var dbEntity = await AuditFlowRepository
                .FirstOrDefaultAsync(
                    x => x.ProviderName == ProviderName
                         && x.AuditName == audit.Name
                         && x.Enable
                         && x.ProviderKey == tenantId
                );

            return dbEntity?.Id;
        }
    }
}