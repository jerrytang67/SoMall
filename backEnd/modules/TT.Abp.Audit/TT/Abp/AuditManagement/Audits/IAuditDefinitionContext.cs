namespace TT.Abp.AuditManagement.Audits
{
    public interface IAuditDefinitionContext
    {
        AuditDefinition GetOrNull(string name);

        void Add(params AuditDefinition[] definitions);
    }
}