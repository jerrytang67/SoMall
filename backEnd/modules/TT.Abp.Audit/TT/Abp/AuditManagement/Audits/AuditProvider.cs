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
        protected IAuditDefinitionManager AuditDefinitionManager { get; }
        protected IAuditValueProviderManager AuditValueProviderManager { get; }

        public AuditProvider(
            IAuditDefinitionManager auditDefinitionManager,
            IAuditValueProviderManager auditValueProviderManager
        )
        {
            AuditDefinitionManager = auditDefinitionManager;
            AuditValueProviderManager = auditValueProviderManager;
        }


        public virtual async Task<Guid?> GetOrNullAsync(string name)
        {
            var audit = AuditDefinitionManager.Get(name);

            var providers = Enumerable
                .Reverse(AuditValueProviderManager.Providers);

            if (audit.Providers.Any())
            {
                providers = providers.Where(p => audit.Providers.Contains(p.Name));
            }

            //TODO: How to implement setting.IsInherited?

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
                return value;
            }

            return null;
        }
    }
    
    
    
}