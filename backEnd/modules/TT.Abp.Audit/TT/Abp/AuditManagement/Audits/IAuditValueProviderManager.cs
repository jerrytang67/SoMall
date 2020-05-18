using System.Collections.Generic;

namespace TT.Abp.AuditManagement.Audits
{
    public interface IAuditValueProviderManager
    {
        List<IAuditValueProvider> Providers { get; }
    }
}