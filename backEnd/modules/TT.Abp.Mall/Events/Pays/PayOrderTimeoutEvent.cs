using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TT.Abp.Mall.Domain.Pays;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;

namespace TT.Abp.Mall.Events.Pays
{
    public class PayOrderTimeoutEvent : INotification
    {
        public Guid Id { get; }

        public PayOrderTimeoutEvent(Guid id)
        {
            Id = id;
        }

        public class PayOrderTimeoutEventHandler : INotificationHandler<PayOrderTimeoutEvent>
        {
            private readonly IRepository<PayOrder, Guid> _payOrderRepository;

            public PayOrderTimeoutEventHandler(IRepository<PayOrder, Guid> payOrderRepository)
            {
                _payOrderRepository = payOrderRepository;
            }

            [UnitOfWork]
            public virtual async Task Handle(PayOrderTimeoutEvent notification, CancellationToken cancellationToken)
            {
                var entity = await _payOrderRepository.FirstOrDefaultAsync(x => x.Id == notification.Id, cancellationToken: cancellationToken);

                if (entity != null)
                {
                    await _payOrderRepository.DeleteAsync(entity, true, cancellationToken);
                }
            }
        }
    }
}