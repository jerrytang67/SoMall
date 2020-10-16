using System.Threading.Tasks;
using IdentityServer4.Models;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;
using Volo.Abp.Identity;
using Volo.Abp.IdentityServer.IdentityResources;
using IdentityResource = IdentityServer4.Models.IdentityResource;

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
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResources.Address(),
                new IdentityResources.Phone(),
                new IdentityResource("role", "Roles of the user", new[] {"role"}),
                new IdentityResource("picture", "User's HeadImgUrl", new[] {"picture"})
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