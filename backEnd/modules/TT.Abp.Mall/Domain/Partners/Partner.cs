using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace TT.Abp.Mall.Domain.Partners
{
    public class Partner : FullAuditedEntity, IMultiTenant
    {
        private Partner()
        {
        }

        public Partner(Guid userId)
        {
            UserId = userId;
        }

        public Guid UserId { get; set; }

        [NotNull] public virtual string RealName { get; protected set; }
        [NotNull] public virtual string Phone { get; protected set; }

        public virtual string HeadImgUrl { get; protected set; }
        [NotNull] public virtual string PhoneBackup { get; protected set; }

        public MallEnums.PartnerState State { get; protected set; } = MallEnums.PartnerState.待审核;

        /// <summary>
        ///     可用余额
        /// </summary>
        public virtual decimal AvblBalance { get; protected set; } = 0;

        /// <summary>
        ///     不可用余额
        /// </summary>
        public virtual decimal UnavblBalance { get; protected set; } = 0;

        /// <summary>
        ///     已提现总数
        /// </summary>
        public virtual decimal TotalWithdrawals { get; protected set; } = 0;

        public DateTime? LastLoginDate { get; protected set; }

        //locaton info
        public virtual double? Lat { get; protected set; }

        public virtual double? Lng { get; protected set; }
        public virtual string LocationLabel { get; protected set; }
        public virtual string LocationAddress { get; protected set; }

        public virtual MallEnums.LocationType LocationType { get; protected set; }
        public virtual ICollection<PartnerProduct> PartnerProducts { get; set; }

        public int Views { get; set; } = 0;
        public PartnerDetail Detail { get; set; } = new PartnerDetail();

        public Guid? TenantId { get; protected set; }

        public override object[] GetKeys()
        {
            return new object[] {UserId};
        }
    }

    [Owned]
    public class PartnerDetail
    {
        public virtual string NoticeContent { get; set; }

        //以下信息基于微信
        public virtual string weixin { get; set; } //微信号

        /// <summary>
        ///     自我介绍
        /// </summary>
        public virtual string Introducting { get; set; } = @"所在地：
微信好友数：
从事工作类型：";
    }
}