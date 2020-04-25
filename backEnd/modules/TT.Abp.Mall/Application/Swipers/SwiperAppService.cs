using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
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
    }

    public class SwiperAppService : CrudAppService<Swiper, SwiperDto, Guid, MallRequestDto, SwiperCreateOrUpdateDto, SwiperCreateOrUpdateDto>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SwiperAppService(
            IRepository<Swiper, Guid> repository,
            IHttpContextAccessor httpContextAccessor
        ) : base(repository)
        {
            _httpContextAccessor = httpContextAccessor;
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

            query = query.OrderBy(input.Sorting);

            var result = await query.ToListAsync();

            return new ListResultDto<SwiperDto>(ObjectMapper.Map<List<Swiper>, List<SwiperDto>>(result));
        }
        
        
        

        protected override IQueryable<Swiper> CreateFilteredQuery(MallRequestDto input)
        {
            return base.CreateFilteredQuery(input)
                .WhereIf(input.ShopId.HasValue, x => x.ShopId == input.ShopId);
        }
        
    }
}