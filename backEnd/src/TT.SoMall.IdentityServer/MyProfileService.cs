using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TT.SoMall.Users;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;

namespace TT.SoMall
{
    [Dependency(ServiceLifetime.Transient, ReplaceServices = true)]
    public class MyProfileService : DefaultProfileService
    {
        private readonly IRepository<AppUser, Guid> _appUserRepository;

        public MyProfileService(ILogger<DefaultProfileService> logger,
            IRepository<AppUser, Guid> appUserRepository) : base(logger)
        {
            _appUserRepository = appUserRepository;
        }


        [UnitOfWork]
        public override async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            await base.GetProfileDataAsync(context);

            //>Processing

            var claims2 = context.Subject.Claims;

            var userId = claims2.FirstOrDefault(x => x.Type == "sub")?.Value;

            if (userId != null)
            {
                var guid = new Guid(userId);

                var user = await _appUserRepository.AsNoTracking().FirstOrDefaultAsync(x => x.Id == guid);

                if (user != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim("picture", user.HeadImgUrl ?? ""),
                    };

                    context.IssuedClaims.AddRange(claims);
                }
            }
        }
    }
}