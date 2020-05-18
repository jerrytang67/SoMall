using Volo.Abp.Collections;

namespace TT.Abp.AuditManagement.Audits
{
    public class AuditOptions
    {
        public ITypeList<IAuditDefinitionProvider> DefinitionProviders { get; }

        public ITypeList<IAuditValueProvider> ValueProviders { get; }

        public AuditOptions()
        {
            DefinitionProviders = new TypeList<IAuditDefinitionProvider>();
            ValueProviders = new TypeList<IAuditValueProvider>();
        }
    }
}