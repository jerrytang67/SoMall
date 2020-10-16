using System;
using TT.Abp.Mall.Domain;
using Volo.Abp.Application.Dtos;

namespace TT.Abp.Mall.Application.Coupons.Dtos
{
    /// <summary>
    /// <see cref="Coupon"/>
    /// </summary>
    public class CouponDto : EntityDto<Guid>
    {
        public int Amount { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string Desc { get; set; }

        public int Count { get; set; }

        public int TotalCount { get; set; }

        public MallEnums.UseType UseType { get; set; }

        public int State { get; set; }

        public DateTimeOffset DateTimeEnable { get; set; }

        public DateTimeOffset DateTimeStart { get; set; }

        public DateTimeOffset DatetimeEnd { get; set; }

        public int UseCount { get; set; }
    }
}