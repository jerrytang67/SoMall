using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using TT.Abp.Mall.Application.Coupons.Dtos;
using TT.Abp.Mall.Domain;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Linq;

namespace TT.Abp.Mall.Application.Coupons
{
    public interface IUserCouponAppService
    {
        Task<ListResultDto<UserCouponDto>> GetPublicListAsync(CouponResultRequestDto input);
    }

    public class UserCouponAppService : CrudAppService<UserCoupon, UserCouponDto, Guid, CouponResultRequestDto, UserCouponCreateOrUpdateDto, UserCouponCreateOrUpdateDto>, IUserCouponAppService
    {
        private readonly IAsyncQueryableExecuter _asyncQueryableExecuter;
        public UserCouponAppService(IRepository<UserCoupon, Guid> repository, IAsyncQueryableExecuter asyncQueryableExecuter) : base(repository)
        {
            _asyncQueryableExecuter = asyncQueryableExecuter;
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

            var totalCount = await _asyncQueryableExecuter.CountAsync(query);

            query = ApplySorting(query, input);

            var entities = await _asyncQueryableExecuter.ToListAsync(query);

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