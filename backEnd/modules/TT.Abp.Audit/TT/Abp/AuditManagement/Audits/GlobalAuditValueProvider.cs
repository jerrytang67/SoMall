using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TT.Abp.AuditManagement.Domain;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;

namespace TT.Abp.AuditManagement.Audits
{
    public class GlobalAuditValueProvider : AuditValueProvider
    {
        public const string ProviderName = "G";

        public GlobalAuditValueProvider(
            IRepository<AuditFlow, Guid> auditFlowRepository
        ) : base(auditFlowRepository)
        {
        }

        public override string Name => ProviderName;


        [UnitOfWork]
        public override async Task<Guid?> GetOrNullAsync(AuditDefinition audit)
        {
            var dbEntity = await AuditFlowRepository
                .FirstOrDefaultAsync(x =>
                    x.ProviderName == ProviderName
                    && x.AuditName == audit.Name
                    && x.Enable);

            return dbEntity?.Id;
        }
    }
}