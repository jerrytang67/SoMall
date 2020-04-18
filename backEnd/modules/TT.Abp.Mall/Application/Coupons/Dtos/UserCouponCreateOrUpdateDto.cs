using System;
using TT.Abp.Mall.Domain;

namespace TT.Abp.Mall.Application.Coupons.Dtos
{
    /// <summary>
    /// <see cref="UserCoupon"/>
    /// </summary>
    public class UserCouponCreateOrUpdateDto
    {
        public Guid CouponId { get; set; }
        public Guid OwnerUserId { get; set; }
    }
}