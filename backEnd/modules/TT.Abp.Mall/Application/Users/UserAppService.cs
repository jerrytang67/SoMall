using System;
using Microsoft.AspNetCore.Authorization;
using TT.Abp.Mall.Domain.Users;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace TT.Abp.Mall.Application.Users
{
    public interface IMallUserAppService : ICrudAppService<MallUserDto, Guid, PagedAndSortedResultRequestDto, MallUserDto, MallUserDto>
    {
    }

    [Authorize]
    public class MallUserAppService : CrudAppService<MallUser, MallUserDto, Guid, PagedAndSortedResultRequestDto, MallUserDto, MallUserDto>, IMallUserAppService
    {
        public MallUserAppService(IRepository<MallUser, Guid> repository) : base(repository)
        {
            base.GetListPolicyName = MallPermissions.MallUsers.Default;
            base.CreatePolicyName = MallPermissions.MallUsers.Create;
            base.UpdatePolicyName = MallPermissions.MallUsers.Update;
            base.DeletePolicyName = MallPermissions.MallUsers.Delete;
        }
    }
}