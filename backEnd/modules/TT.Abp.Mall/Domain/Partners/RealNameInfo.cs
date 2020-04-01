using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TT.Abp.Mall.Domain.Partners
{
    public class RealNameInfo
    {
        public Guid UserId { get; protected set; }

        [StringLength(32)] public string unionid { get; set; }

        [StringLength(32)]
        [Required]
        [DisplayName("姓名")]
        public string RealName { get; set; }

        [StringLength(16)]
        [Required]
        [DisplayName("手机号")]
        public string Telphone { get; set; }

        [StringLength(16)]
        [Required]
        [DisplayName("备用电话")]
        public string TelphoneBackup { get; set; }

        public MallEnums.RealNameInfoType Type { get; set; }

        [StringLength(256)]
        [Required]
        [DisplayName("身份证-正面")]
        public string IDCardFrontUrl { get; set; }

        [StringLength(256)]
        [Required]
        [DisplayName("身份证-背面")]
        public string IDCardBackUrl { get; set; }

        [StringLength(256)]
        [Required]
        [DisplayName("手持身份证-正面")]
        public string IDCardHandUrl { get; set; }

        [StringLength(256)] public string BusinessLicenseUrl { get; set; }

        public MallEnums.RealNameInfoState State { get; set; } = 0;
    }
}