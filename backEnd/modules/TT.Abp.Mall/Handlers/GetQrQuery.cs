using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TT.Abp.Mall.Application;
using TT.Abp.Mall.Domain.Shares;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Uow;

namespace TT.Abp.Mall.Handlers
{
    public class GetQrQuery : IRequest<QrDetail>
    {
        public MallRequestDto Input { get; }

        public GetQrQuery(MallRequestDto input)
        {
            Input = input;
        }

        public class GetOuQueryHandler : IRequestHandler<GetQrQuery, QrDetail>
        {
            private readonly IRepository<QrDetail, Guid> _repository;
            private readonly ICurrentTenant _currentTenant;

            public GetOuQueryHandler(
                IRepository<QrDetail, Guid> repository,
                ICurrentTenant currentTenant
            )
            {
                _repository = repository;
                _currentTenant = currentTenant;
            }

            [UnitOfWork]
            public virtual async Task<QrDetail> Handle(GetQrQuery request, CancellationToken cancellationToken)
            {
                var detail = new QrDetail("mall_mini", "mall_product_page", _currentTenant.Id);
                detail.Params.Add("SpuId", request.Input.SpuId.ToString());
                detail.Params.Add("Keywords", request.Input.Keywords);

                var entity = await _repository.InsertAsync(detail, autoSave: true, cancellationToken: cancellationToken);

                return await Task.FromResult(entity);
            }
        }
    }
}