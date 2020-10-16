using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using TT.Abp.Mall.Domain.Orders;
using TT.Abp.Mall.Events.Pays;
using TT.Abp.Shops;
using TT.Extensions;
using Volo.Abp;
using Volo.Abp.Auditing;
using Volo.Abp.Data;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace TT.Abp.Mall.Domain.Pays
{
    public class PayOrder : FullAuditedAggregateRoot<Guid>, IMultiTenant, IMultiShop
    {
        public PayOrder()
        {
        }

        public override Guid Id { get; protected set; }

        /// <summary>
        /// 单位:分
        /// </summary>
        public virtual int TotalPrice { get; protected set; }

        [NotNull] public virtual string Body { get; protected set; }

        [NotNull] public virtual string BillNo { get; protected set; }

        [NotNull] public virtual string OpenId { get; protected set; }

        [NotNull] public virtual string MchId { get; protected set; }

        [NotNull] public virtual string AppName { get; protected set; }

        public virtual MallEnums.OrderType Type { get; protected set; } = MallEnums.OrderType.Product;

        public virtual MallEnums.PayType PayType { get; protected set; } = MallEnums.PayType.微信;

        public virtual MallEnums.PayState State { get; protected set; } = MallEnums.PayState.未支付;

        #region 支付成功

        public virtual bool IsSuccessPay { get; protected set; } = false;
        public virtual DateTime? SuccessPayTime { get; protected set; } = null;

        #endregion

        #region 退款相关

        public virtual bool IsRefund { get; protected set; } = false;
        public virtual DateTime? RefundTime { get; protected set; }
        public virtual DateTime? RefundComplateTime { get; protected set; }

        /// <summary>
        /// 单位:分
        /// </summary>
        public virtual int? RefundPrice { get; protected set; }

        #endregion

        public virtual Guid? ShareFromUserId { get; protected set; }

        public virtual Guid? PartnerId { get; protected set; }


        public virtual Guid? TenantId { get; protected set; }

        public virtual Guid? ShopId { get; protected set; }

        #region 私有方法

        private void InitBillNo(string mchId)
        {
            BillNo = $"{mchId}{DateTime.Now:yyyyMMddHHmmss}{StringExt.BuildRandomStr(6)}";
        }


        private void SetBodyFromProduct(ProductOrder productOrder)
        {
            var bodyStr = productOrder.OrderItems.FirstOrDefault()?.SpuName ?? throw new Exception("没有SpuName信息");
            if (bodyStr.Length > 32)
            {
                bodyStr = bodyStr.Substring(32);
            }

            Body = bodyStr;
        }

        /// <summary>
        /// 从活动订单生成支付Order
        /// </summary>
        public void CreatWxPayFromProductOrder(Guid id, ProductOrder productOrder,
            string mchId,
            string openid,
            string appName,
            Guid? shareFromUserId = null,
            Guid? partnerId = null
        )
        {
            Id = id;
            InitBillNo(mchId);
            SetBodyFromProduct(productOrder);
            OpenId = openid;
            AppName = appName;
            MchId = mchId;
            TotalPrice = Convert.ToInt32(productOrder.PriceOriginal * 100);
            Type = MallEnums.OrderType.Product;
            PayType = MallEnums.PayType.微信;
            CreatorId = productOrder.CreatorId;
            ShopId = productOrder.ShopId;
            TenantId = productOrder.TenantId;

            ShareFromUserId = shareFromUserId;
            PartnerId = partnerId;
        }

        #endregion

        public void SuccessPay(Guid notifyId)
        {
            IsSuccessPay = true;
            SuccessPayTime = DateTime.Now;
            State = MallEnums.PayState.已支付;

            this.SetProperty("TenPayNotifyId", notifyId);
            //domain event
        }

        public void Refund(in decimal refundPrice, string reason)
        {
            var canRefundPrice = TotalPrice - (RefundPrice ?? 0);
            if (refundPrice * 100 > canRefundPrice)
            {
                throw new UserFriendlyException($"退款金额不能大于可退款金额,当前可退金额:{canRefundPrice / 100m:0.00}");
            }

            State = MallEnums.PayState.待退款;
            IsRefund = true;
            RefundTime = DateTime.Now;
            AddLocalEvent(new PayOrderRefundEvent(this, refundPrice, reason));
        }

        public void RefundComplate(int refundPrice)
        {
            RefundPrice ??= 0;

            RefundPrice += refundPrice;

            if (RefundPrice == TotalPrice)
            {
                RefundComplateTime = DateTime.Now;
                State = MallEnums.PayState.已退款;
            }
            else
            {
                IsRefund = false;
                State = MallEnums.PayState.部分退款;
            }
        }
    }
}