using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using TT.Abp.Mall.Domain.Shops;
using TT.Abp.Shops.Domain;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace TT.Abp.Mall.Domain.Partners
{
    public class Partner : FullAuditedEntity<Guid>, IMultiTenant
    {
        protected Partner()
        {
        }

        public Partner(string realName, string phone, string nickname, string headImageUrl)
        {
            RealName = realName;
            Phone = phone;
            Nickname = nickname;
            HeadImageUrl = headImageUrl;
        }

        [NotNull] public string RealName { get; protected set; }

        [NotNull] public string Phone { get; protected set; }

        public string Nickname { get; protected set; }
        public string HeadImageUrl { get; protected set; }

        public DateTime UpdateDate { get; set; } = DateTime.Now;

        public MallEnums.PartnerState State { get; protected set; } = MallEnums.PartnerState.待审核;

        /// <summary>
        /// 可用余额
        /// </summary>
        public virtual decimal AvblBalance { get; protected set; } = 0;

        /// <summary>
        /// 不可用余额
        /// </summary>
        public virtual decimal UnavblBalance { get; protected set; } = 0;

        /// <summary>
        /// 已提现总数
        /// </summary>
        public virtual decimal TotalWithdrawals { get; protected set; } = 0;

        public DateTime? LastLoginDate { get; set; }

        //locaton info
        public virtual double? Lat { get; set; }

        public virtual double? Lng { get; set; }
        public virtual string LocationLabel { get; set; }
        public virtual string LocationAddress { get; set; }

        public virtual ICollection<PartnerProduct> PartnerProducts { get; set; }

        public int Views { get; set; } = 0;

        public PartnerDetail Detail { get; set; }

        public Guid? TenantId { get; protected set; }
    }

    [Owned]
    public class PartnerDetail
    {
        public virtual string NoticeContent { get; set; }

        //以下信息基于微信
        public virtual string openid { get; set; }
        public virtual string unionid { get; set; }
        public virtual string weixin { get; set; } //微信号

        /// <summary>
        /// 自我介绍
        /// </summary>
        public virtual string Introducting { get; set; } = @"所在地：
微信好友数：
从事工作类型：";
    }
}