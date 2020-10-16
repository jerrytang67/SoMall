using System;

namespace TT.Abp.Mall.Application.Coupons.Dtos
{
    public class CouponResultRequestDto : MallRequestDto
    {
        public Guid? CouponId { get; set; }
    }
}