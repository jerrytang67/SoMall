using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace TT.Abp.Mall.Application.Users
{
    public class MallUserDto : IEntityDto<Guid>
    {
        public Guid Id { get; set; }

        public Guid? TenantId { get; set; }

        public string UserName { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }

        public string PhoneNumber { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

        public Dictionary<string, object> ExtraProperties { get; set; }
    }
}