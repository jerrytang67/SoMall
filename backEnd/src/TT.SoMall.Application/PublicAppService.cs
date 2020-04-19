using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using TT.Extensions;
using TT.SoMall.Users;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;

namespace TT.SoMall
{
    public class PublicAppService : ApplicationService
    {
        private readonly IRepository<AppUser, Guid> _userRepository;
        private readonly IdentityUserManager _identityUserManager;

        public PublicAppService(
            IRepository<AppUser, Guid> userRepository,
            IdentityUserManager identityUserManager
        )
        {
            _userRepository = userRepository;
            _identityUserManager = identityUserManager;
        }

        [Authorize]
        public async Task<UserProfileInput> GetCurrentUser()
        {
            var currentUser = await _userRepository.FirstOrDefaultAsync(x => x.Id == CurrentUser.Id);
            if (currentUser == null)
            {
                throw new UserFriendlyException("当前登录用户不正确");
            }

            var result = ObjectMapper.Map<AppUser, UserProfileInput>(currentUser);
            return result;
        }


        [Authorize]
        public async Task UpdateUserProfile(UserProfileInput input)
        {
            if (!input.Password.IsNullOrEmptyOrWhiteSpace())
            {
                if (!input.Password.Equals(input.PasswordConfirm))
                {
                    throw new UserFriendlyException("二次输入的密码不同");
                }
            }

            var currentUser = await _userRepository.FirstOrDefaultAsync(x => x.Id == CurrentUser.Id);
            if (currentUser == null)
            {
                throw new UserFriendlyException("当前登录用户不正确");
            }

            currentUser.SetUserName(input.UserName);
            currentUser.SetName(input.Name);
            currentUser.SetSurname(input.Surname);
            currentUser.SetPhone(input.PhoneNumber);
            currentUser.SetEmail(input.Email);
            currentUser.Nickname = input.Name;
            currentUser.HeadImgUrl = input.HeadImgUrl;
        }
    }

    public class UserProfileInput
    {
        public bool IsAuthenticated { get; set; } = true;
        [Required] public string UserName { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string PhoneNumber { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }

        public string Nickname { get; set; }
        public string HeadImgUrl { get; set; }
        
        public Guid? TenantId { get; set; }
        
        public Guid Id { get; set; }
    }
}