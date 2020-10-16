using System;
using JetBrains.Annotations;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace TT.Abp.AccountManagement.Domain
{
    public class RealNameInfo : FullAuditedEntity, IMultiTenant
    {
        public Guid UserId { get; protected set; }

        public override object[] GetKeys()
        {
            return new object[] {UserId};
        }

        [NotNull] public string RealName { get; protected set; }

        [NotNull] public string Phone { get; protected set; }


        public AccountEnums.RealNameInfoType Type { get; protected set; }

        [NotNull] public string IDCardFrontUrl { get; protected set; }

        [NotNull] public string IDCardBackUrl { get; protected set; }

        [NotNull] public string IDCardHandUrl { get; protected set; }

        public string BusinessLicenseUrl { get; protected set; }

        public AccountEnums.RealNameInfoState State { get; protected set; } = 0;

        public Guid? TenantId { get; protected set; }
    }
}