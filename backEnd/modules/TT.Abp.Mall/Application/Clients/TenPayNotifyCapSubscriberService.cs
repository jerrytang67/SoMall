using System;
using System.Linq;
using System.Threading.Tasks;
using DotNetCore.CAP;
using Microsoft.EntityFrameworkCore;
using TT.Abp.Mall.Domain;
using TT.Abp.Mall.Domain.Orders;
using TT.Abp.Mall.Domain.Pays;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;

namespace TT.Abp.Mall.Application.Clients
{
    public class TenPayNotifyCapSubscriberService : ICapSubscribe, ITransientDependency
    {
        private readonly IPayOrderRepository _payOrderRepository;
        private readonly IRepository<ProductOrder, Guid> _productOrderRepository;
        private readonly UnitOfWorkManager _unitOfWorkManager;

        public TenPayNotifyCapSubscriberService(
            IRepository<ProductOrder, Guid> productOrderRepository,
            IPayOrderRepository payOrderRepository,
            UnitOfWorkManager unitOfWorkManager
        )
        {
            _payOrderRepository = payOrderRepository;
            _productOrderRepository = productOrderRepository;
            _unitOfWorkManager = unitOfWorkManager;
        }

        [CapSubscribe("mall.tenpay.notify")]
        public async Task TenPayNotifySubscriber(TenPayNotify tenPayNotify)
        {
            using (var uow = _unitOfWorkManager.Begin(requiresNew: true))
            {
                var payOrder = await _payOrderRepository.FindAsync(tenPayNotify.out_trade_no);
                if (payOrder != null)
                {
                    if (payOrder.TotalPrice.ToString() == tenPayNotify.total_fee && tenPayNotify.result_code == "SUCCESS")
                    {
                        payOrder.SuccessPay(tenPayNotify.Id);

                        if (payOrder.Type == MallEnums.OrderType.Product)
                        {
                            var productOrders = await _productOrderRepository.Where(x => x.BillNo == payOrder.BillNo).ToListAsync();

                            foreach (var o in productOrders)
                            {
                                // TODO:实收少于应收多少范围内要发消息 
                                o.SuccessPay(MallEnums.PayType.微信, payOrder.TotalPrice / 100m);
                            }
                        }

                        await uow.SaveChangesAsync();
                    }
                    else
                    {
                        throw new Exception($"Tenpay Result Fee not equals !!pay is {tenPayNotify.fee_type} , db is {payOrder.TotalPrice} , BillNo is {payOrder.BillNo}");
                    }
                }
                else
                {
                    //TODO:这里要更多的消息通知管理员
                    throw new Exception($"cant't find BillNo {tenPayNotify.out_trade_no}");
                }

                await Task.CompletedTask;
            }
        }
    }
}