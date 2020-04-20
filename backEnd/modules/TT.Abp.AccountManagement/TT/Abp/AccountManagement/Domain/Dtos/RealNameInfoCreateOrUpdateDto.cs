using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TT.Abp.AccountManagement.Domain.Dtos
{
    /// <summary>
    /// <see cref="RealNameInfo"/>
    /// </summary>
    public class RealNameInfoCreateOrUpdateDto
    {
        [Required] [DisplayName("姓名")] public string RealName { get; set; }

        [Required] [DisplayName("手机")] public string Phone { get; set; }

        [DisplayName("备用手机")] public string PhoneBackup { get; set; }

        [DisplayName("认证类型")] public AccountEnums.RealNameInfoType Type { get; set; }

        [Required] [DisplayName("身份证-正面")] public string IDCardFrontUrl { get; set; }

        [Required] [DisplayName("身份证-背面")] public string IDCardBackUrl { get; set; }

        [Required] [DisplayName("手持身份证-正面")] public string IDCardHandUrl { get; set; }

        [DisplayName("营业执照")] public string BusinessLicenseUrl { get; set; }
    }
}