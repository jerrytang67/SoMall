using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;
using Microsoft.EntityFrameworkCore;
using TT.Abp.AuditManagement.Application.Dtos;
using TT.Abp.AuditManagement.Audits;
using TT.Abp.Mall.Definitions;
using TT.Abp.Mall.Domain;
using TT.Abp.Mall.Domain.Pays;
using TT.Abp.Mall.Events.Pays;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace TT.Abp.Mall.Application.Pays
{
    public interface IRefundLogAppService : ICrudAppService<RefundLogDto, Guid, MallRequestDto, RefundLogDto, RefundLogDto>
    {
        //Task AgreeRefund(Guid id);

        Task StartAudit(RefundLogDto input);
    }

    public class RefundLogAppService : AuditCrudAppService<RefundLog, RefundLogDto, Guid, MallRequestDto, RefundLogDto, RefundLogDto>, IRefundLogAppService
    {
        private readonly IMediator _mediator;
        private readonly IServiceProvider _serviceProvider;

        public RefundLogAppService(
            IRepository<RefundLog, Guid> repository,
            IMediator mediator,
            IServiceProvider serviceProvider
        ) : base(repository, serviceProvider)
        {
            _mediator = mediator;
            _serviceProvider = serviceProvider;

            base.GetListPolicyName = MallPermissions.PayOrders.Default;
            base.GetPolicyName = MallPermissions.PayOrders.Default;


            CurrentAuditName = MallManagementAudit.ProductRefund;
        }

        // [HttpGet]
        // [Authorize]
        // public async Task AgreeRefund(Guid id)
        // {
        //     await _mediator.Publish(new RefundAgreeEvent(id));
        //     await Task.CompletedTask;
        // }

        public override Task<RefundLogDto> CreateAsync(RefundLogDto input)
        {
            throw new NotImplementedException();
        }

        public override Task<RefundLogDto> UpdateAsync(Guid id, RefundLogDto input)
        {
            throw new NotImplementedException();
        }

        public override Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }


        [Authorize(MallPermissions.PayOrders.Default)]
        public override Task StartAudit(RefundLogDto input)
        {
            return base.StartAudit(input);
        }
    }

    /// <summary>
    /// <see cref="RefundLog"/>
    /// </summary>
    public class RefundLogDto : CreationAuditedEntityDto<Guid>, INeedAuditBase
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


        #region 审核相关

        public Guid? AuditFlowId { get; set; }
        public int? Audit { get; set; }
        public int? AuditStatus { get; set; }
        public bool IsAudited { get; set; }
        public AuditFlowDto AuditFlow { get; set; }
        public List<AuditNodeDto> CurrentAuditNodes { get; set; }

        #endregion
    }
}