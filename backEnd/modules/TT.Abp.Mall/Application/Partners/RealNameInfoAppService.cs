using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TT.Abp.Mall.Application.Partners.Dtos;
using TT.Abp.Mall.Application.Users;
using TT.Abp.Mall.Domain.Partners;
using TT.Abp.Mall.Domain.Users;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace TT.Abp.Mall.Application.Partners
{
    public interface IRealNameInfoAppService : ICrudAppService<RealNameInfoDto, Guid, MallRequestDto, RealNameInfoCreateOrUpdateDto, RealNameInfoCreateOrUpdateDto>
    {
    }

    public class RealNameInfoAppService : CrudAppService<RealNameInfo, RealNameInfoDto, Guid, MallRequestDto, RealNameInfoCreateOrUpdateDto, RealNameInfoCreateOrUpdateDto>
    {
        protected IMallUserLookupService UserLookupService { get; }

        public RealNameInfoAppService(
            IRepository<RealNameInfo, Guid> repository,
            IMallUserLookupService mallUserLookupService
        ) : base(repository)
        {
            UserLookupService = mallUserLookupService;
            base.GetListPolicyName = MallPermissions.RealNameInfos.Default;
            base.CreatePolicyName = MallPermissions.RealNameInfos.Create;
            base.UpdatePolicyName = MallPermissions.RealNameInfos.Update;
            base.DeletePolicyName = MallPermissions.RealNameInfos.Delete;
        }

        public override async Task<PagedResultDto<RealNameInfoDto>> GetListAsync(MallRequestDto input)
        {
            await CheckGetListPolicyAsync();

            var query = CreateFilteredQuery(input);

            var totalCount = await AsyncQueryableExecuter.CountAsync(query);

            query = ApplySorting(query, input);
            query = ApplyPaging(query, input);

            var entities = await AsyncQueryableExecuter.ToListAsync(query);

            var list = new PagedResultDto<RealNameInfoDto>(
                totalCount,
                entities.Select(MapToGetListOutputDto).ToList()
            );

            var userDictionary = new Dictionary<Guid, MallUserDto>();

            foreach (var item in list.Items)
            {
                if (item.CreatorId.HasValue)
                {
                    if (!userDictionary.ContainsKey(item.CreatorId.Value))
                    {
                        var creatorUser = await UserLookupService.FindByIdAsync(item.CreatorId.Value);
                        if (creatorUser != null)
                        {
                            userDictionary[creatorUser.Id] = ObjectMapper.Map<MallUser, MallUserDto>(creatorUser);
                        }
                    }

                    if (userDictionary.ContainsKey(item.CreatorId.Value))
                    {
                        item.MallUser = userDictionary[(Guid) item.CreatorId];
                    }
                }
            }

            return list;
        }
    }
}