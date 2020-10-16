using System;
using TT.Abp.Mall.Domain;
using TT.Abp.Mall.Domain.Partners;

namespace TT.Abp.Mall.Application.Partners.Dtos
{
    public class PartnerDto : PartnerDtoBase
    {
        public string BackupPhone { get; set; }


        public DateTime UpdateDate { get; set; }

        public MallEnums.PartnerState State { get; set; }

        /// <summary>
        /// 已提现总数
        /// </summary>
        public decimal TotalWithdrawals { get; set; }

        public DateTime? LastLoginDate { get; set; }

        //locaton info
        public double? Lat { get; set; }

        public double? Lng { get; set; }

        public string LocationLabel { get; set; }

        public string LocationAddress { get; set; }

        public MallEnums.LocationType LocationType { get; set; }

        public PartnerDetail Detail { get; set; }
    }
}