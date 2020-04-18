using System;
using TT.Abp.Mall.Application.Partners.Dtos;
using TT.Abp.Mall.Domain;
using TT.Abp.Mall.Domain.Partners;

namespace TT.Abp.Mall.Application.Partners
{
    public class PartnerDto : PartnerDtoBase
    {
        public DateTime UpdateDate { get; set; }

        public MallEnums.PartnerState State { get; set; }

        /// <summary>
        /// 已提现总数
        /// </summary>
        public virtual decimal TotalWithdrawals { get; set; }

        public DateTime? LastLoginDate { get; set; }

        //locaton info
        public virtual double? Lat { get; set; }

        public virtual double? Lng { get; set; }

        public virtual string LocationLabel { get; set; }

        public virtual string LocationAddress { get; set; }

        public PartnerDetail Detail { get; set; }
    }
}