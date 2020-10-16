using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TT.Abp.Mall.Domain.Shares;
using TT.Extensions;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;

namespace TT.Abp.Mall.Handlers
{
    public class GetQrDetailQuery : IRequest<QrDetail>
    {
        public string Id { get; }

        public GetQrDetailQuery(string id)
        {
            Id = id;
        }


        public class GetQrDetailQueryHandle : IRequestHandler<GetQrDetailQuery, QrDetail>
        {
            private readonly IRepository<QrDetail, Guid> _repository;

            public GetQrDetailQueryHandle(IRepository<QrDetail, Guid> repository)
            {
                _repository = repository;
            }

            [UnitOfWork]
            public virtual async Task<QrDetail> Handle(GetQrDetailQuery request, CancellationToken cancellationToken)
            {
                var entity = await _repository.FirstOrDefaultAsync(x => x.Id == request.Id.FromShortString(), cancellationToken: cancellationToken);
            
                return entity;
            }
        }
    }
}