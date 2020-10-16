using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;
using TT.Abp.AppManagement.Apps;
using TT.Abp.Mall.Definitions;
using TT.Abp.Mall.Domain.Orders;
using TT.Abp.Mall.Domain.Pays;
using TT.Extensions;
using TT.HttpClient.Weixin;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Settings;
using Volo.Abp.Uow;

namespace TT.Abp.Mall.Events.Pays
{
    public class RefundAgreeEvent : INotification
    {
        public RefundAgreeEvent(Guid refundLogId)
        {
            RefundLogId = refundLogId;
        }

        public Guid RefundLogId { get; }

        public class RefundAgreeEventHandle : INotificationHandler<RefundAgreeEvent>
        {
            private readonly AppProvider _appProvider;
            private readonly IMediator _mediator;
            private readonly IPayApi _payApi;
            private readonly IRepository<PayOrder, Guid> _payOrderRepository;
            private readonly IRepository<ProductOrder, Guid> _productOrderRepository;
            private readonly IRepository<RefundLog, Guid> _refundLogRepository;
            private readonly ISettingProvider _settingProvider;

            public RefundAgreeEventHandle(
                IRepository<RefundLog, Guid> refundLogRepository,
                IRepository<PayOrder, Guid> payOrderRepository,
                IRepository<ProductOrder, Guid> productOrderRepository,
                IMediator mediator,
                AppProvider appProvider,
                ISettingProvider settingProvider,
                IPayApi payApi
            )
            {
                _refundLogRepository = refundLogRepository;
                _payOrderRepository = payOrderRepository;
                _productOrderRepository = productOrderRepository;
                _mediator = mediator;
                _appProvider = appProvider;
                _settingProvider = settingProvider;
                _payApi = payApi;
            }

            [UnitOfWork]
            public virtual async Task Handle(RefundAgreeEvent request, CancellationToken cancellationToken)
            {
                var refundLog = await _refundLogRepository.FirstOrDefaultAsync(x => x.Id == request.RefundLogId, cancellationToken);
                Check.NotNull(refundLog, nameof(refundLog));

                var payOrder = await _payOrderRepository.FirstOrDefaultAsync(x => x.BillNo == refundLog.BillNo, cancellationToken);
                Check.NotNull(payOrder, nameof(payOrder));

                var app = await _appProvider.GetOrNullAsync(payOrder.AppName);
                var appid = app["appid"] ?? throw new AbpException($"App:{payOrder.AppName} appid未设置");

                var mchId = await _settingProvider.GetOrNullAsync(MallManagementSetting.PayMchId);
                var mchKey = await _settingProvider.GetOrNullAsync(MallManagementSetting.PayKey);


                var result = await _payApi.RefundAsync(
                    appid,
                    mchId,
                    mchKey,
                    "",
                    "",
                    null,
                    payOrder.BillNo,
                    refundLog.Id.ToShortString(),
                    payOrder.TotalPrice,
                    refundLog.Price,
                    refundDesc: refundLog.Reason,
                    refundAccount: "REFUND_SOURCE_RECHARGE_FUNDS"
                );

                if (result)
                {
                    refundLog.RefundComplate();
                    payOrder.RefundComplate(refundLog.Price);

                    var productOrder = await _productOrderRepository.Where(x => x.BillNo == refundLog.BillNo).ToListAsync();

                    foreach (var p in productOrder)
                    {
                        p.RefundComplate();
                    }
                }

                Log.Warning(request.ToString());

                await Task.CompletedTask;
            }
        }
    }
}