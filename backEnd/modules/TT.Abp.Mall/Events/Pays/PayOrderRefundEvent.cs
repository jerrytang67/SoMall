using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TT.Abp.Mall.Domain;
using TT.Abp.Mall.Domain.Pays;
using Volo.Abp;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.EventBus;
using Volo.Abp.Uow;

namespace TT.Abp.Mall.Events.Pays
{
    public class PayOrderRefundEvent
    {
        public PayOrder PayOrder { get; }
        public decimal RefundPrice { get; }
        public string Reason { get; }

        public PayOrderRefundEvent(PayOrder payOrder, in decimal refundPrice, string reason = null)
        {
            PayOrder = payOrder;
            RefundPrice = refundPrice;
            Reason = reason;
        }
    }

    public class PayOrderRefundEventHandle : ILocalEventHandler<PayOrderRefundEvent>, ITransientDependency
    {
        private readonly IRepository<RefundLog, Guid> _refundLogRepository;

        public PayOrderRefundEventHandle(IRepository<RefundLog, Guid> refundLogRepository)
        {
            _refundLogRepository = refundLogRepository;
        }

        [UnitOfWork]
        public virtual async Task HandleEventAsync(PayOrderRefundEvent eventData)
        {
            var payOrder = eventData.PayOrder;

            if (!payOrder.CreatorId.HasValue)
            {
                throw new UserFriendlyException("payorder CreatorId is null");
            }

            var dbEntity = await _refundLogRepository.FirstOrDefaultAsync(x => x.BillNo == payOrder.BillNo && x.IsSuccess == false);

            if (dbEntity != null)
            {
                throw new UserFriendlyException("此订单正在申请退款,请误重复操作");
            }

            var refundLog = new RefundLog(
                payOrder.BillNo,
                MallEnums.OrderType.Product,
                payOrder.CreatorId.Value,
                eventData.Reason,
                Convert.ToInt32(eventData.RefundPrice * 100),
                payOrder.ShopId,
                payOrder.TenantId);

            await _refundLogRepository.InsertAsync(refundLog, true);

            await Task.CompletedTask;
        }
    }
}