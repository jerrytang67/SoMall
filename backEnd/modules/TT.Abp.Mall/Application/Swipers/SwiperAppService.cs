using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using TT.Abp.AppManagement.Apps;
using TT.Abp.Mall.Application.Products;
using TT.Abp.Mall.Application.Swipers.Dtos;
using TT.Abp.Mall.Definitions;
using TT.Abp.Mall.Domain.Swipers;
using TT.Abp.Mall.Utils;
using TT.Extensions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace TT.Abp.Mall.Application.Swipers
{
    public interface ISwiperAppService : ICrudAppService<SwiperDto, Guid, MallRequestDto, SwiperCreateOrUpdateDto, SwiperCreateOrUpdateDto>
    {
        Task<ListResultDto<SwiperDto>> GetPublishListAsync(MallRequestDto input);
        Task<GetForEditOutput<SwiperCreateOrUpdateDto>> GetForEdit(Guid id);
    }

    public class SwiperAppService : CrudAppService<Swiper, SwiperDto, Guid, MallRequestDto, SwiperCreateOrUpdateDto, SwiperCreateOrUpdateDto>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAppDefinitionManager _appDefinitionManager;

        public SwiperAppService(
            IRepository<Swiper, Guid> repository,
            IHttpContextAccessor httpContextAccessor,
            IAppDefinitionManager appDefinitionManager
        ) : base(repository)
        {
            _httpContextAccessor = httpContextAccessor;
            _appDefinitionManager = appDefinitionManager;

            base.GetListPolicyName = MallPermissions.Swipers.Default;
            base.CreatePolicyName = MallPermissions.Swipers.Create;
            base.UpdatePolicyName = MallPermissions.Swipers.Update;
            base.DeletePolicyName = MallPermissions.Swipers.Delete;
        }


        public async Task<ListResultDto<SwiperDto>> GetPublishListAsync(MallRequestDto input)
        {
            var appName = _httpContextAccessor.GetAppName();
            var query = CreateFilteredQuery(input)
                .WhereIf(!appName.IsNullOrEmptyOrWhiteSpace(), x => x.AppName == appName)
                .WhereIf(!input.Keywords.IsNullOrEmptyOrWhiteSpace(), x => x.GroupName == input.Keywords);

            query = query.OrderBy(input.Sorting ?? "sort desc");

            var result = await query.ToListAsync();

            return new ListResultDto<SwiperDto>(ObjectMapper.Map<List<Swiper>, List<SwiperDto>>(result));
        }


        [Authorize]
        public async Task<GetForEditOutput<SwiperCreateOrUpdateDto>> GetForEdit(Guid id)
        {
            var find = await Repository
                .FirstOrDefaultAsync(z => z.Id == id);

            var schema = JToken.FromObject(new { });

            var apps = _appDefinitionManager.GetAll();
            schema["apps"] = apps.GetSelection("string", "appName", @"{0}", new[] {"Name"}, "Name");

            return new GetForEditOutput<SwiperCreateOrUpdateDto>(
                ObjectMapper.Map<Swiper, SwiperCreateOrUpdateDto>(find ?? new Swiper()), schema);
        }

        public override Task<SwiperDto> CreateAsync(SwiperCreateOrUpdateDto input)
        {
            return base.CreateAsync(input);
        }

        protected override IQueryable<Swiper> CreateFilteredQuery(MallRequestDto input)
        {
            return base.CreateFilteredQuery(input)
                .WhereIf(input.ShopId.HasValue, x => x.ShopId == input.ShopId);
        }
    }
}