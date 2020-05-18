using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Http;
using TT.Abp.AuditManagement.Domain;
using Volo.Abp.Domain.Repositories;

namespace TT.Abp.AuditManagement.Audits
{
    public interface IAuditValueProvider
    {
        string Name { get; }

        Task<Guid?> GetOrNullAsync([NotNull] AuditDefinition audit);
    }

    public abstract class AuditValueProvider : IAuditValueProvider
    {
        protected IRepository<AuditFlow, Guid> AuditFlowRepository { get; }
        public abstract string Name { get; }

        protected AuditValueProvider(IRepository<AuditFlow, Guid> auditFlowRepository)
        {
            AuditFlowRepository = auditFlowRepository;
        }

        public abstract Task<Guid?> GetOrNullAsync(AuditDefinition audit);
    }
}