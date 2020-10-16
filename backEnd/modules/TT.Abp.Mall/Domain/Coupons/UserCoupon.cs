using System;
using TT.Abp.Shops;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace TT.Abp.Mall.Domain
{
    public class UserCoupon : FullAuditedAggregateRoot<Guid>, IMultiShop, IMultiTenant
    {
        private UserCoupon()
        {
        }

        public UserCoupon(Guid couponId, Guid ownerUserId, string couponName, int couponAmount, Guid? shopId = null, Guid? tenantId = null)
        {
            CouponId = couponId;
            OwnerUserId = ownerUserId;
            CouponName = couponName;
            CouponAmount = couponAmount;
            ShopId = shopId;
            TenantId = tenantId;
        }

        public Guid CouponId { get; protected set; }
        public Guid OwnerUserId { get; protected set; }
        public string CouponName { get; protected set; }
        public int CouponAmount { get; protected set; }


        #region 使用记录

        public Guid? PaymentId { get; private set; }

        public DateTimeOffset? UsedTime { get; private set; }

        public Guid? UsedOrderId { get; private set; }

        public MallEnums.OrderType? UsedOrderType { get; private set; }

        #endregion
        
        public Guid? ShopId { get; protected set; }
        public Guid? TenantId { get; protected set; }


        public void Use(MallEnums.OrderType type, Guid paymentId, Guid orderId)
        {
            UsedTime = DateTimeOffset.Now;
            PaymentId = paymentId;
            UsedOrderId = orderId;
            UsedOrderType = type;
        }
        
        public void Return()
        {
            UsedTime = null;
            PaymentId = null;
            UsedOrderId = null;
            UsedOrderType = null;
        }
    }
}