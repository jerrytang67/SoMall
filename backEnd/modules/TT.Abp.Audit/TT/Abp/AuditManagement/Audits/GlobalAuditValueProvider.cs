using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TT.Abp.AuditManagement.Domain;
using Volo.Abp.Domain.Repositories;

namespace TT.Abp.AuditManagement.Audits
{
    public class GlobalAuditValueProvider : AuditValueProvider
    {
        public const string ProviderName = "G";
        public override string Name => ProviderName;

        public GlobalAuditValueProvider(
            IRepository<AuditFlow, Guid> auditFlowRepository
        ) : base(auditFlowRepository)
        {
        }

        public override async Task<Guid?> GetOrNullAsync(AuditDefinition audit)
        {
            var dbEntity = await AuditFlowRepository
                .FirstOrDefaultAsync(x =>
                    x.ProviderKey == ProviderName
                    && x.AuditName == audit.Name
                    && x.Enable);

            return dbEntity?.Id;
        }
    }
}