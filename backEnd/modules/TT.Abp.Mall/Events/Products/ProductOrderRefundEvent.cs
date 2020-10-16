using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TT.Abp.Mall.Domain.Orders;
using TT.Abp.Mall.Domain.Pays;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;

namespace TT.Abp.Mall.Events.Products
{
    public class ProductOrderRefundEvent : INotification
    {
        /// <summary>
        ///     ProductOrderRefundEvent
        /// </summary>
        /// <param name="productOrder"></param>
        /// <param name="price">单位:元</param>
        public ProductOrderRefundEvent(
            ProductOrder productOrder,
            decimal price,
            string reason
        )
        {
            ProductOrder = productOrder;
            Price = price;
            Reason = reason;
        }

        public ProductOrder ProductOrder { get; }
        public decimal Price { get; }
        public string Reason { get; }

        public class ProductOrderRefundEventHandle : INotificationHandler<ProductOrderRefundEvent>
        {
            private readonly IRepository<PayOrder, Guid> _payOrderRepository;

            public ProductOrderRefundEventHandle(IRepository<PayOrder, Guid> payOrderRepository)
            {
                _payOrderRepository = payOrderRepository;
            }

            [UnitOfWork]
            public virtual async Task Handle(ProductOrderRefundEvent request, CancellationToken cancellationToken)
            {
                if (request.ProductOrder.CanIRefund())
                {
                    var order = await _payOrderRepository.FirstOrDefaultAsync(x => x.BillNo == request.ProductOrder.BillNo, cancellationToken);

                    if (order == null)
                    {
                        throw new UserFriendlyException("找不到支付订单");
                    }

                    order.Refund(request.Price, request.Reason);

                    request.ProductOrder.Refund();
                }
            }
        }
    }
}