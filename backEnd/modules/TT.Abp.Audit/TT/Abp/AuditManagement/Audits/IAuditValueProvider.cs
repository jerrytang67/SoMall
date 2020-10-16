using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using TT.Abp.AuditManagement.Domain;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace TT.Abp.AuditManagement.Audits
{
    public interface IAuditValueProvider
    {
        string Name { get; }

        Task<Guid?> GetOrNullAsync([NotNull] AuditDefinition audit);
    }

    public abstract class AuditValueProvider : IAuditValueProvider, ITransientDependency
    {
        protected AuditValueProvider(IRepository<AuditFlow, Guid> auditFlowRepository)
        {
            AuditFlowRepository = auditFlowRepository;
        }

        protected IRepository<AuditFlow, Guid> AuditFlowRepository { get; }
        public abstract string Name { get; }

        public abstract Task<Guid?> GetOrNullAsync(AuditDefinition audit);
    }
}