using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;
using TT.Abp.Mall.Definitions;
using TT.Abp.Mall.Domain;
using TT.Abp.Mall.Domain.Pays;
using TT.Abp.Mall.Events.Pays;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace TT.Abp.Mall.Application.Pays
{
    public interface IRefundLogAppService : ICrudAppService<RefundLogDto, Guid, MallRequestDto, RefundLogDto, RefundLogDto>
    {
        Task AgreeRefund(Guid id);
    }

    public class RefundLogAppService : CrudAppService<RefundLog, RefundLogDto, Guid, MallRequestDto, RefundLogDto, RefundLogDto>, IRefundLogAppService
    {
        private readonly IMediator _mediator;

        public RefundLogAppService(
            IRepository<RefundLog, Guid> repository,
            IMediator mediator
        ) : base(repository)
        {
            _mediator = mediator;

            base.GetListPolicyName = MallPermissions.PayOrders.Default;
            base.GetPolicyName = MallPermissions.PayOrders.Default;
        }

        [HttpGet]
        [Authorize]
        public async Task AgreeRefund(Guid id)
        {
            await _mediator.Publish(new RefundAgreeEvent(id));
            await Task.CompletedTask;
        }

        public override Task<RefundLogDto> CreateAsync(RefundLogDto input)
        {
            throw new NotImplementedException();
            //return base.CreateAsync(input);
        }

        public override Task<RefundLogDto> UpdateAsync(Guid id, RefundLogDto input)
        {
            throw new NotImplementedException();

            //return base.UpdateAsync(id, input);
        }

        public override Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
            //return base.DeleteAsync(id);
        }
    }

    /// <summary>
    /// <see cref="RefundLog"/>
    /// </summary>
    public class RefundLogDto : CreationAuditedEntityDto<Guid>
    {
        public string BillNo { get; set; }
        public MallEnums.OrderType PayOrderType { get; set; }
        /// <summary>
        /// 接受退款的用户
        /// </summary>
        public Guid UserId { get; set; }
        /// <summary>
        /// 退款原因
        /// </summary>
        public string Reason { get; set; }
        /// <summary>
        /// 退款金额单位：分
        /// </summary>
        public int Price { get; set; }
        public bool IsSuccess { get; set; }
        public DateTime? SuccessTime { get; set; }
        public Guid? ShopId { get; set; }
    }
}