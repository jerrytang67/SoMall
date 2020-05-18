using System.Security.Cryptography.X509Certificates;
using Volo.Abp.DependencyInjection;
using Volo.Abp.MultiTenancy;

namespace TT.Abp.Core.Certificates
{
    public class CertificateProvider : ITransientDependency
    {
        private readonly ICurrentTenant _currentTenant;

        public CertificateProvider(ICurrentTenant currentTenant)
        {
            _currentTenant = currentTenant;
        }

        public X509Certificate2 GetCertificate()
        {
            var tenant = _currentTenant;
            return new X509Certificate2(@"C:\apiclient_cert.p12", "1486627732");
        }
    }
}