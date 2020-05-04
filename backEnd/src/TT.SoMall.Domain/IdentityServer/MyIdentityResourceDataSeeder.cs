using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;
using Volo.Abp.Identity;
using Volo.Abp.IdentityServer.ApiResources;
using Volo.Abp.IdentityServer.Clients;
using Volo.Abp.IdentityServer.IdentityResources;
using Volo.Abp.PermissionManagement;

namespace TT.SoMall.IdentityServer
{
    [Dependency(ServiceLifetime.Transient, ReplaceServices = true)]
    public class MyIdentityResourceDataSeeder : IdentityResourceDataSeeder, IIdentityResourceDataSeeder, ITransientDependency
    {
        public MyIdentityResourceDataSeeder(IIdentityResourceRepository identityResourceRepository, IGuidGenerator guidGenerator, IIdentityClaimTypeRepository claimTypeRepository) : base(
            identityResourceRepository, guidGenerator, claimTypeRepository)
        {
        }

        public override async Task CreateStandardResourcesAsync()
        {
            var resources = new[]
            {
                new IdentityServer4.Models.IdentityResources.OpenId(),
                new IdentityServer4.Models.IdentityResources.Profile(),
                new IdentityServer4.Models.IdentityResources.Email(),
                new IdentityServer4.Models.IdentityResources.Address(),
                new IdentityServer4.Models.IdentityResources.Phone(),
                new IdentityServer4.Models.IdentityResource("role", "Roles of the user", new[] {"role"}),
                new IdentityServer4.Models.IdentityResource("picture", "User's HeadImgUrl", new[] {"picture"})
            };

            foreach (var resource in resources)
            {
                foreach (var claimType in resource.UserClaims)
                {
                    await AddClaimTypeIfNotExistsAsync(claimType);
                }

                await AddIdentityResourceIfNotExistsAsync(resource);
            }
        }
    }
}