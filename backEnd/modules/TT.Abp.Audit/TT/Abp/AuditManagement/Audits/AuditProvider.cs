using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace TT.Abp.AuditManagement.Audits
{
    public interface IAuditProvider
    {
        Task<Guid?> GetOrNullAsync(string name);
    }

    public class AuditProvider : IAuditProvider, ITransientDependency
    {
        public AuditProvider(
            IAuditDefinitionManager auditDefinitionManager,
            IAuditValueProviderManager auditValueProviderManager
        )
        {
            AuditDefinitionManager = auditDefinitionManager;
            AuditValueProviderManager = auditValueProviderManager;
        }

        protected IAuditDefinitionManager AuditDefinitionManager { get; }
        protected IAuditValueProviderManager AuditValueProviderManager { get; }


        public virtual async Task<Guid?> GetOrNullAsync(string name)
        {
            var audit = AuditDefinitionManager.Get(name);

            var providers = Enumerable
                .Reverse(AuditValueProviderManager.Providers);

            if (audit.Providers.Any())
            {
                providers = providers.Where(p => audit.Providers.Contains(p.Name));
            }

            var value = await GetOrNullValueFromProvidersAsync(providers, audit);
            return value;
        }

        protected virtual async Task<Guid?> GetOrNullValueFromProvidersAsync(
            IEnumerable<IAuditValueProvider> providers,
            AuditDefinition audit)
        {
            foreach (var provider in providers)
            {
                var value = await provider.GetOrNullAsync(audit);
                if (value != null)
                {
                    return value;
                }
            }

            return null;
        }
    }
}