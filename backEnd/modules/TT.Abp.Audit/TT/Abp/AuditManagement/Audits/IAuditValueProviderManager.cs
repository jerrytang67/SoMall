using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Volo.Abp.DependencyInjection;

namespace TT.Abp.AuditManagement.Audits
{
    public interface IAuditValueProviderManager
    {
        List<IAuditValueProvider> Providers { get; }
    }

    public class AuditValueProviderManager : IAuditValueProviderManager, ISingletonDependency
    {
        public List<IAuditValueProvider> Providers => _lazyProviders.Value;
        protected AuditOptions Options { get; }

        private readonly Lazy<List<IAuditValueProvider>> _lazyProviders;

        public AuditValueProviderManager(
            IServiceProvider serviceProvider,
            IOptions<AuditOptions> options)
        {
            Options = options.Value;

            _lazyProviders = new Lazy<List<IAuditValueProvider>>(
                () => Options
                    .ValueProviders
                    .Select(type => serviceProvider.GetRequiredService(type) as IAuditValueProvider)
                    .ToList(),
                true
            );
        }
    }
}