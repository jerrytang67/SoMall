using System;
using System.ComponentModel;
using TT.Abp.Mall.Application.Users;
using TT.Abp.Mall.Domain;
using TT.Abp.Mall.Domain.Partners;
using Volo.Abp.Application.Dtos;

namespace TT.Abp.Mall.Application.Partners.Dtos
{
    /// <summary>
    /// <see cref="RealNameInfo"/>
    /// </summary>
    public class RealNameInfoDto : EntityDto<Guid>
    {
        [DisplayName("姓名")] public string RealName { get; set; }

        [DisplayName("手机")] public string Phone { get; set; }

        [DisplayName("备用手机")] public string PhoneBackup { get; set; }

        [DisplayName("认证类型")] public MallEnums.RealNameInfoType Type { get; set; }

        [DisplayName("身份证-正面")] public string IDCardFrontUrl { get; set; }

        [DisplayName("身份证-背面")] public string IDCardBackUrl { get; set; }

        [DisplayName("手持身份证-正面")] public string IDCardHandUrl { get; set; }

        [DisplayName("营业执照")] public string BusinessLicenseUrl { get; set; }

        [DisplayName("认证状态")] public MallEnums.RealNameInfoState State { get; set; } = MallEnums.RealNameInfoState.未认证;

        public Guid? CreatorId { get; set; }

        public MallUserDto MallUser { get; set; }
    }
}