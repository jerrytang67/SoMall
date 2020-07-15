using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using TT.Abp.Mall.Application.Addresses.Dtos;
using TT.Abp.Mall.Application.Users;
using TT.Abp.Mall.Definitions;
using TT.Abp.Mall.Domain.Addresses;
using TT.Abp.Mall.Domain.Users;
using Volo.Abp.Linq;

namespace TT.Abp.Mall.Application.Addresses
{
    public interface IAddressAppService : ICrudAppService<
        AddressDto,
        Guid,
        PagedAndSortedResultRequestDto,
        AddressCreateOrUpdateDto,
        AddressCreateOrUpdateDto>
    {
    }

    [Authorize]
    public class AddressAppService
        : CrudAppService<Address, AddressDto, Guid, PagedAndSortedResultRequestDto, AddressCreateOrUpdateDto, AddressCreateOrUpdateDto>, IAddressAppService
    {
        protected IMallUserLookupService UserLookupService { get; }

        private readonly IAsyncQueryableExecuter _asyncQueryableExecuter;
        public AddressAppService(
            IRepository<Address, Guid> repository,
            IMallUserLookupService userLookupService, IAsyncQueryableExecuter asyncQueryableExecuter)
            : base(repository)
        {
            UserLookupService = userLookupService;
            _asyncQueryableExecuter = asyncQueryableExecuter;

            base.CreatePolicyName = MallPermissions.Addresses.Create;
            base.UpdatePolicyName = MallPermissions.Addresses.Update;
            base.DeletePolicyName = MallPermissions.Addresses.Delete;
        }

        public override async Task<PagedResultDto<AddressDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            await CheckGetListPolicyAsync();

            var query = CreateFilteredQuery(input);

            var totalCount = await _asyncQueryableExecuter.CountAsync(query);

            query = ApplySorting(query, input);
            query = ApplyPaging(query, input);

            var entities = await _asyncQueryableExecuter.ToListAsync(query);

            var addresslist = new PagedResultDto<AddressDto>(
                totalCount,
                entities.Select(MapToGetListOutputDto).ToList()
            );

            var userDictionary = new Dictionary<Guid, MallUserDto>();

            foreach (var addressDto in addresslist.Items)
            {
                if (addressDto.CreatorId.HasValue)
                {
                    if (!userDictionary.ContainsKey(addressDto.CreatorId.Value))
                    {
                        var creatorUser = await UserLookupService.FindByIdAsync(addressDto.CreatorId.Value);
                        if (creatorUser != null)
                        {
                            userDictionary[creatorUser.Id] = ObjectMapper.Map<MallUser, MallUserDto>(creatorUser);
                        }
                    }

                    if (userDictionary.ContainsKey(addressDto.CreatorId.Value))
                    {
                        addressDto.MallUser = userDictionary[(Guid) addressDto.CreatorId];
                    }
                }
            }

            return addresslist;
        }

        public override async Task<AddressDto> CreateAsync(AddressCreateOrUpdateDto input)
        {
            // 暂时新建的地址都是自己的,所以不用判断权限
            // await CheckCreatePolicyAsync();

            var entity = MapToEntity(input);

            TryToSetTenantId(entity);

            await Repository.InsertAsync(entity, autoSave: true);

            return MapToGetOutputDto(entity);
        }

        public override async Task<AddressDto> UpdateAsync(Guid id, AddressCreateOrUpdateDto input)
        {
            var entity = await Repository.GetAsync(id);
            if (entity.CreatorId != CurrentUser.Id)
            {
                await CheckUpdatePolicyAsync();
            }

            //TODO: Check if input has id different than given id and normalize if it's default value, throw ex otherwise
            MapToEntity(input, entity);
            await Repository.UpdateAsync(entity, autoSave: true);

            return MapToGetOutputDto(entity);
        }

        public override async Task DeleteAsync(Guid id)
        {
            var find = await Repository.GetAsync(id);
            if (find.CreatorId == CurrentUser.Id)
            {
                await DeleteByIdAsync(id);
            }
            else
            {
                await CheckDeletePolicyAsync();

                await DeleteByIdAsync(id);
            }
        }


        [Authorize]
        public async Task SetDefault(Guid id)
        {
            var list = await Repository.Where(x => x.CreatorId == CurrentUser.Id).ToListAsync();
            foreach (var address in list)
            {
                if (address.Id != id)
                {
                    address.IsDefault = false;
                }

                address.IsDefault = true;
            }

            await Task.CompletedTask;
        }

        protected override IQueryable<Address> CreateFilteredQuery(PagedAndSortedResultRequestDto input)
        {
            return base.CreateFilteredQuery(input);
        }
    }
}