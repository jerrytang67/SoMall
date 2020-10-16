using System;
using System.ComponentModel.DataAnnotations;

namespace TT.SoMall.Dtos
{
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