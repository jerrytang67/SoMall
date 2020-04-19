using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace TT.Abp.Mall.Domain.Partners
{
    public class RealNameInfo : FullAuditedEntity<Guid>, IMultiTenant
    {
        [NotNull] public string RealName { get; protected set; }

        [NotNull] public string Phone { get; protected set; }

        public string PhoneBackup { get; protected set; }

        public MallEnums.RealNameInfoType Type { get; protected set; }

        [NotNull] public string IDCardFrontUrl { get; protected set; }

        [NotNull] public string IDCardBackUrl { get; protected set; }

        [NotNull] public string IDCardHandUrl { get; protected set; }

        public string BusinessLicenseUrl { get; protected set; }

        public MallEnums.RealNameInfoState State { get; protected set; } = 0;

        public Guid? TenantId { get; protected set; }
    }
}