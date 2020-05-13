using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using TT.Abp.AppManagement.Apps;
using TT.Abp.Mall.Application;
using TT.Abp.Mall.Domain.Shares;
using TT.Abp.Weixin.Domain;
using TT.Extensions;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Uow;

namespace TT.Abp.Mall.Handlers
{
    public class GetQrQuery : IRequest<QrDetail>
    {
        public MallRequestDto Input { get; }
        public string EventName { get; }

        public GetQrQuery(MallRequestDto input, string eventName)
        {
            Input = input;
            EventName = eventName;
        }

        public class GetOuQueryHandler : IRequestHandler<GetQrQuery, QrDetail>
        {
            private readonly IRepository<QrDetail, Guid> _repository;
            private readonly IHttpContextAccessor _httpContextAccessor;
            private readonly ICurrentTenant _currentTenant;
            private readonly WeixinManager _weixinManager;
            private readonly IAppProvider _appProvider;

            public GetOuQueryHandler(
                IRepository<QrDetail, Guid> repository,
                IHttpContextAccessor httpContextAccessor,
                ICurrentTenant currentTenant,
                WeixinManager weixinManager,
                IAppProvider appProvider
            )
            {
                _repository = repository;
                _httpContextAccessor = httpContextAccessor;
                _currentTenant = currentTenant;
                _weixinManager = weixinManager;
                _appProvider = appProvider;
            }

            [UnitOfWork]
            public virtual async Task<QrDetail> Handle(GetQrQuery request, CancellationToken cancellationToken)
            {
                var detail = new QrDetail(request.Input.AppName, request.EventName, _currentTenant.Id);
                detail.Params.Add("spuId", request.Input.SpuId.ToString());
                detail.Params.Add("keywords", request.Input.Keywords);

                var app = await _appProvider.GetOrNullAsync(request.Input.AppName);
                if (app == null)
                {
                    throw new UserFriendlyException("没有定义的APP");
                }

                var entity = await _repository.InsertAsync(detail, autoSave: true, cancellationToken: cancellationToken);
                var qr = await _weixinManager.Getwxacodeunlimit(app["appid"], app["appsec"], entity.Id.ToShortString(), detail.Path);

                entity.SetQrUrl(qr);

                return await Task.FromResult(entity);
            }
        }
    }
}