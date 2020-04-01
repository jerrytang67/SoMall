using System;
using System.ComponentModel.DataAnnotations;
using TT.Abp.Shops;
using TT.Extensions;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace TT.Abp.Mall.Domain.Orders
{
    public class PayOrders : FullAuditedEntity<Guid>, IMultiTenant, IMultiShop
    {
        [StringLength(128)] public string Body { get; protected set; }

        /// <summary>
        /// 单位:分
        /// </summary>
        public int TotalPrice { get; protected set; }


        [StringLength(48)] public string BillNo { get; protected set; }

        [StringLength(32)] public string OpenId { get; protected set; }

        [StringLength(32)] public string MchId { get; protected set; }

        public MallEnums.OrderType Type { get; protected set; } = MallEnums.OrderType.Product;

        public int OrderId { get; set; }

        public MallEnums.PayType PayType { get; protected set; } = MallEnums.PayType.微信;

        public int State { get; protected set; }

        #region 支付

        public bool IsSuccessPay { get; protected set; } = false;
        public DateTime? SuccessPayTime { get; protected set; } = null;

        #endregion

        #region 退款

        public bool IsRefund { get; protected set; }
        public DateTime? RefundTime { get; protected set; }
        public DateTime? RefundComplateTime { get; protected set; }

        /// <summary>
        /// 单位:分
        /// </summary>
        public int? RefundPrice { get; protected set; } = null;

        #endregion

        public Guid? ShareFromUserId { get; set; }


        public string FromClient { get; protected set; }

        #region 私有方法

        private void InitBillNo(string mchId)
        {
            BillNo = $"{mchId}{DateTime.Now:yyyyMMddHHmmss}{StringExt.BuildRandomStr(6)}";
        }

        #endregion

        public void RefundComplate()
        {
            RefundComplateTime = DateTime.Now;
        }

        public Guid? TenantId { get; protected set; }

        public Guid? ShopId { get; protected set; }
    }
}