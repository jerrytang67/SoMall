using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using TT.Abp.Mall.Domain.Addresses;

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
        public AddressAppService(
            IRepository<Address, Guid> repository
        )
            : base(repository)
        {
        }

        public override async Task<PagedResultDto<AddressDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            return await base.GetListAsync(input);
        }

        public override async Task<AddressDto> CreateAsync(AddressCreateOrUpdateDto input)
        {
            await CheckCreatePolicyAsync();

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
    }
}