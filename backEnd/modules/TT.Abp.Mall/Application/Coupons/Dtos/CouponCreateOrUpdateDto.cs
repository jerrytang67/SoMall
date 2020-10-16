using System;
using JetBrains.Annotations;
using TT.Abp.Mall.Domain;

namespace TT.Abp.Mall.Application.Coupons.Dtos
{
    /// <summary>
    ///     <see cref="Coupon" />
    /// </summary>
    public class CouponCreateOrUpdateDto
    {
        public int Amount { get; set; }

        [NotNull] public string Name { get; set; }

        [NotNull] public string Code { get; set; }

        [NotNull] public string Desc { get; set; }

        public int Count { get; set; }

        public int TotalCount { get; set; }

        public MallEnums.UseType UseType { get; set; }

        public int State { get; set; }

        public DateTimeOffset DateTimeEnable { get; set; }

        public DateTimeOffset DateTimeStart { get; set; }

        public DateTimeOffset DatetimeEnd { get; set; }
    }
}