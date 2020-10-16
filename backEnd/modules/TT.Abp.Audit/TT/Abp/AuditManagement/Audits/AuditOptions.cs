using Volo.Abp.Collections;

namespace TT.Abp.AuditManagement.Audits
{
    public class AuditOptions
    {
        public AuditOptions()
        {
            DefinitionProviders = new TypeList<IAuditDefinitionProvider>();
            ValueProviders = new TypeList<IAuditValueProvider>();
        }

        public ITypeList<IAuditDefinitionProvider> DefinitionProviders { get; }

        public ITypeList<IAuditValueProvider> ValueProviders { get; }
    }
}