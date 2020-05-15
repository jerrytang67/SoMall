using System;
using JetBrains.Annotations;
using TT.Abp.Shops;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace TT.Abp.Mall.Domain.Pays
{
    public class RefundLog : FullAuditedAggregateRoot<Guid>, IMultiTenant, IMultiShop
    {
        /// <summary>
        /// RefundLog
        /// </summary>
        /// <param name="billNo"></param>
        /// <param name="payOrderType"></param>
        /// <param name="userId"></param>
        /// <param name="reason"></param>
        /// <param name="price"></param>
        /// <param name="shopId"></param>
        /// <param name="tenantId"></param>
        public RefundLog([NotNull] string billNo, MallEnums.OrderType payOrderType, Guid userId, string reason, int price, Guid? shopId = null, Guid? tenantId = null)
        {
            BillNo = billNo;
            PayOrderType = payOrderType;
            UserId = userId;
            Reason = reason;
            Price = price;
            TenantId = tenantId;
            ShopId = shopId;
        }

        [NotNull] public virtual string BillNo { get; protected set; }

        public virtual MallEnums.OrderType PayOrderType { get; protected set; }

        /// <summary>
        /// 接受退款的用户
        /// </summary>
        public virtual Guid UserId { get; protected set; }

        /// <summary>
        /// 退款原因
        /// </summary>
        public virtual string Reason { get; protected set; }

        /// <summary>
        /// 退款金额单位：分
        /// </summary>
        public virtual int Price { get; protected set; }

        public virtual bool IsSuccess { get; protected set; }

        public virtual DateTime? SuccessTime { get; protected set; }


        public virtual Guid? TenantId { get; protected set; }
        public virtual Guid? ShopId { get; protected set; }

        public void RefundComplate()
        {
            IsSuccess = true;
            SuccessTime = DateTime.Now;
            
            
        }
    }
}