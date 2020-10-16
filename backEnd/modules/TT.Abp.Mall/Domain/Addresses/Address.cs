using System;
using JetBrains.Annotations;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace TT.Abp.Mall.Domain.Addresses
{
    public class Address : FullAuditedEntity<Guid>, IMultiTenant
    {
        protected Address()
        {
        }

        public Address([NotNull] string realName, [NotNull] string phone, [NotNull] string locationLabel, [NotNull] string locationAddress)
        {
            RealName = realName;
            Phone = phone;
            LocationLabel = locationLabel;
            LocationAddress = locationAddress;
        }

        [NotNull] public string RealName { get; protected set; }
        [NotNull] public string Phone { get; protected set; }
        [NotNull] public string LocationLabel { get; protected set; }
        [NotNull] public string LocationAddress { get; protected set; }

        public string NickName { get; set; }

        //是否为默认地址
        public bool IsDefault { get; set; } = false;

        //最后一次使用这个地址时间
        public DateTime? DatetimeLast { get; set; }

        public double? Lat { get; set; }

        public double? Lng { get; set; }

        public MallEnums.LocationType LocationType { get; set; }

        public Guid? TenantId { get; protected set; }
    }
}