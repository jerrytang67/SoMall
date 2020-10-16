using System;
using System.Linq;
using System.Threading.Tasks;
using TT.Abp.Mall.Application.Coupons.Dtos;
using TT.Abp.Mall.Definitions;
using TT.Abp.Mall.Domain;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Linq;

namespace TT.Abp.Mall.Application.Coupons
{
    public interface ICouponAppService
    {
        Task<ListResultDto<CouponDto>> GetPublishListAsync(MallRequestDto input);
    }

    public class CouponAppService : CrudAppService<Coupon, CouponDto, Guid, MallRequestDto, CouponCreateOrUpdateDto, CouponCreateOrUpdateDto>, ICouponAppService
    {
        private readonly IAsyncQueryableExecuter _asyncQueryableExecuter;
        private readonly IRepository<UserCoupon, Guid> _userCouponRepository;

        public CouponAppService(
            IRepository<Coupon, Guid> repository,
            IRepository<UserCoupon, Guid> userCouponRepository,
            IAsyncQueryableExecuter asyncQueryableExecuter
        ) : base(repository)
        {
            _userCouponRepository = userCouponRepository;
            _asyncQueryableExecuter = asyncQueryableExecuter;
            base.GetListPolicyName = MallPermissions.Coupons.Default;
            base.CreatePolicyName = MallPermissions.Coupons.Create;
            base.UpdatePolicyName = MallPermissions.Coupons.Update;
            base.DeletePolicyName = MallPermissions.Coupons.Delete;
        }


        public async Task<ListResultDto<CouponDto>> GetPublishListAsync(MallRequestDto input)
        {
            var query = base.CreateFilteredQuery(input);

            var totalCount = await _asyncQueryableExecuter.CountAsync(query);

            query = ApplySorting(query, input);

            var entities = await _asyncQueryableExecuter.ToListAsync(query);

            var result = new ListResultDto<CouponDto>(
                entities.Select(MapToGetListOutputDto).ToList()
            );

            return result;
        }

        protected override IQueryable<Coupon> CreateFilteredQuery(MallRequestDto input)
        {
            return base.CreateFilteredQuery(input)
                .WhereIf(input.ShopId.HasValue, x => x.ShopId == input.ShopId);
        }
    }
}