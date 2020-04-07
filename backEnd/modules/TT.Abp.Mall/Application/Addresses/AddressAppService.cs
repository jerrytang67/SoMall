using System;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Authorization;
using TT.Abp.Mall.Domain.Products;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

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
            if (await AuthorizationService.IsGrantedAsync(GetListPolicyName))
            {
                return await base.GetListAsync(input);
            }

            var query = CreateFilteredQuery(input);
            var list = await query.Where(x => x.CreatorId == CurrentUser.Id).ToListAsync();
            return new PagedResultDto<AddressDto>(
                list.Count,
                list.Select(MapToGetListOutputDto).ToList()
            );
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

    public class AddressCreateOrUpdateDto
    {
        [NotNull] public string RealName { get; set; }
        [NotNull] public string Phone { get; set; }
        [NotNull] public string LocationLable { get; set; }
        [NotNull] public string LocationAddress { get; set; }
        public string NickName { get; set; }
        public double? Lat { get; set; }
        public double? Lng { get; set; }
        public LocationType LocationType { get; set; }
    }

    public class AddressDto : EntityDto<Guid>
    {
        public string RealName { get; set; }

        public string Phone { get; set; }

        public string LocationLable { get; set; }

        public string LocationAddress { get; set; }

        public string NickName { get; set; }

        //是否为默认地址
        public bool IsDefault { get; set; } = false;

        //最后一次使用这个地址时间
        public DateTime? DatetimeLast { get; set; }

        public double? Lat { get; set; }

        public double? Lng { get; set; }

        public LocationType LocationType { get; set; }
    }
}