using System;
using TT.Abp.Mall.Domain;
using Volo.Abp.Application.Dtos;

namespace TT.Abp.Mall.Application.Coupons.Dtos
{
    /// <summary>
    ///     <see cref="UserCoupon" />
    /// </summary>
    public class UserCouponDto : EntityDto<Guid>
    {
        public Guid CouponId { get; set; }
        public Guid OwnerUserId { get; set; }
        public string CouponName { get; set; }
        public int CouponAmount { get; set; }

        public CouponDto Coupon { get; set; }

        #region 使用记录

        public Guid? PaymentId { get; set; }

        public DateTimeOffset? UsedTime { get; set; }

        public Guid? UsedOrderId { get; set; }

        public MallEnums.OrderType? UsedOrderType { get; set; }

        #endregion
    }
}