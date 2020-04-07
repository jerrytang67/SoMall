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
        [NotNull] public string RealName { get; set; }

        [NotNull] public string Phone { get; set; }

        public string PhoneBackup { get; set; }

        public MallEnums.RealNameInfoType Type { get; set; }

        [NotNull] [DisplayName("身份证-正面")] public string IDCardFrontUrl { get; set; }

        [NotNull] [DisplayName("身份证-背面")] public string IDCardBackUrl { get; set; }

        [NotNull] [DisplayName("手持身份证-正面")] public string IDCardHandUrl { get; set; }

        public string BusinessLicenseUrl { get; set; }

        public MallEnums.RealNameInfoState State { get; set; } = 0;

        public Guid? TenantId { get; protected set; }
    }
}