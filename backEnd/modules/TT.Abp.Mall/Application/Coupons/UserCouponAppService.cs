using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using TT.Abp.Mall.Application.Coupons.Dtos;
using TT.Abp.Mall.Domain;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace TT.Abp.Mall.Application.Coupons
{
    public interface IUserCouponAppService
    {
        Task<ListResultDto<UserCouponDto>> GetPublicListAsync(CouponResultRequestDto input);
    }

    public class UserCouponAppService : CrudAppService<UserCoupon, UserCouponDto, Guid, CouponResultRequestDto, UserCouponCreateOrUpdateDto, UserCouponCreateOrUpdateDto>, IUserCouponAppService
    {
        public UserCouponAppService(IRepository<UserCoupon, Guid> repository) : base(repository)
        {
        }

        public override Task<PagedResultDto<UserCouponDto>> GetListAsync(CouponResultRequestDto input)
        {
            return base.GetListAsync(input);
        }


        [Authorize]
        public async Task<ListResultDto<UserCouponDto>> GetPublicListAsync(CouponResultRequestDto input)
        {
            var query = base.CreateFilteredQuery(input)
                .Where(x => x.OwnerUserId == CurrentUser.Id);

            var totalCount = await AsyncQueryableExecuter.CountAsync(query);

            query = ApplySorting(query, input);

            var entities = await AsyncQueryableExecuter.ToListAsync(query);

            return new ListResultDto<UserCouponDto>(
                entities.Select(MapToGetListOutputDto).ToList()
            );
        }

        protected override IQueryable<UserCoupon> CreateFilteredQuery(CouponResultRequestDto input)
        {
            return base.CreateFilteredQuery(input)
                .WhereIf(input.ShopId.HasValue, x => x.ShopId == input.ShopId)
                .WhereIf(input.CouponId.HasValue, x => x.CouponId == input.CouponId);
        }
    }
}