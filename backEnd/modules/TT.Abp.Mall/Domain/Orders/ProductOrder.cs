using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using TT.Abp.Shops;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace TT.Abp.Mall.Domain.Orders
{
    public class ProductOrder : FullAuditedAggregateRoot<Guid>, IMultiTenant, IMultiShop
    {
        public ProductOrder(
            Guid id,
            Guid? shopId = null,
            Guid? tenantId = null) : base(id)
        {
            ShopId = shopId;
            TenantId = tenantId;
        }

        public virtual Guid? PayOrderId { get; protected set; }

        [CanBeNull] public virtual string BillNo { get; protected set; }

        public decimal? PricePaidIn { get; protected set; } //实收
        public decimal PriceOriginal { get; set; } //原价，应收

        private DateTime? DatetimeComplate { get; set; }

        public MallEnums.OrderState State { get; protected set; } = MallEnums.OrderState.未完成;

        public MallEnums.ProductOrderType Type { get; set; } = MallEnums.ProductOrderType.未标记;

        public MallEnums.PayType PayType { get; set; } = MallEnums.PayType.未支付;

        public string Comment { get; set; }

        public Guid? BuyerId { get; set; }

        public Guid? AddressId { get; set; }

        public string AddressRealName { get; set; }

        public string AddressNickName { get; set; }

        public string AddressPhone { get; set; }

        public string AddressLocationLabel { get; set; }

        public string AddressLocationAddress { get; set; }

        public Guid? ManId { get; set; }

        public int PrintCount { get; set; } = 0; //打印次数统计

        public virtual ICollection<ProductOrderItem> OrderItems { get; set; }

        public Guid? ShopId { get; protected set; }

        public Guid? TenantId { get; protected set; }

        public void SetBillNo(Guid payOrderId, string billno)
        {
            PayOrderId = payOrderId;
            BillNo = billno;
        }

        public void SuccessPay(MallEnums.PayType payType, decimal paidIn)
        {
            PayType = payType;
            PricePaidIn = paidIn;
        }

        public bool CanIRefund()
        {
            if (PayType == MallEnums.PayType.未支付)
            {
                throw new UserFriendlyException("未支付");
            }

            if (!PricePaidIn.HasValue || PricePaidIn == 0)
            {
                throw new UserFriendlyException("实收为0");
            }

            // TODO:已完成是否可退款开关
            if (State == MallEnums.OrderState.完成)
            {
                throw new UserFriendlyException("已完成不能退款");
            }

            return true;
        }

        public void Refund()
        {
            State = MallEnums.OrderState.退款中;
        }

        public void RefundComplate()
        {
            State = MallEnums.OrderState.退款完成;
        }
    }
}