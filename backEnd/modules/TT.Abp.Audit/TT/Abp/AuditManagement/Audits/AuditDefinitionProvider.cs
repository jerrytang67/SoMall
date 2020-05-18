using Volo.Abp.DependencyInjection;

namespace TT.Abp.AuditManagement.Audits
{
    public abstract class AuditDefinitionProvider : IAuditDefinitionProvider, ITransientDependency
    {
        public abstract void Define(IAuditDefinitionContext context);
    }
}