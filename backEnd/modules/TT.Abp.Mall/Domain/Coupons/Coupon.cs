using System;
using JetBrains.Annotations;
using TT.Abp.Shops;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace TT.Abp.Mall.Domain
{
    public class Coupon : FullAuditedAggregateRoot<Guid>, IMultiTenant, IMultiShop
    {
        private Coupon(string desc)
        {
            Desc = desc;
        }

        public Coupon(Guid id, int amount, string name, string code, string desc, int count, int totalCount, MallEnums.UseType useType, int state, DateTimeOffset dateTimeEnable,
            DateTimeOffset dateTimeStart,
            DateTimeOffset datetimeEnd, Guid? shopId = null, Guid? tenantId = null)
        {
            Id = id;
            Amount = amount;
            Name = name;
            Code = code;
            Desc = desc;
            Count = count;
            TotalCount = totalCount;
            UseType = useType;
            State = state;
            DateTimeEnable = dateTimeEnable;
            DateTimeStart = dateTimeStart;
            DatetimeEnd = datetimeEnd;
            ShopId = shopId;
            TenantId = tenantId;
        }

        public int Amount { get; protected set; }
        [NotNull] public string Name { get; protected set; }

        [NotNull] public string Code { get; protected set; }

        [NotNull] public string Desc { get; protected set; }
        public int Count { get; protected set; }

        public int TotalCount { get; protected set; }

        public MallEnums.UseType UseType { get; protected set; }

        public int State { get; protected set; }

        public DateTimeOffset DateTimeEnable { get; protected set; }

        public DateTimeOffset DateTimeStart { get; protected set; }

        public DateTimeOffset DatetimeEnd { get; protected set; }


        public int UseCount { get; set; }

        public Guid? ShopId { get; protected set; }

        public Guid? TenantId { get; protected set; }
    }
}