using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using TT.Abp.Mall.Domain;
using TT.Abp.Mall.Domain.Pays;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace TT.Abp.Mall.Application.Pays
{
    public interface IPayOrderAppService
    {
        Task<PagedResultDto<PayOrderDto>> GetListAsync(MallRequestDto input);
        Task<PagedResultDto<PayOrderDto>> GetPublicListAsync(MallRequestDto input);
    }


    public class PayOrderAppService : ApplicationService, IPayOrderAppService
    {
        private readonly IPayOrderRepository _repository;

        public PayOrderAppService(IPayOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<PagedResultDto<PayOrderDto>> GetListAsync(MallRequestDto input)
        {
            await AuthorizationService.CheckAsync(MallPermissions.PayOrders.Default);

            var query = _repository.GetQuery(input.ShopId);

            var totalCount = await query.CountAsync();

            query = query.OrderBy(input.Sorting);

            query = query.PageBy(input);

            var list = await query.ToListAsync();

            var result = new PagedResultDto<PayOrderDto>(totalCount, ObjectMapper.Map<List<PayOrder>, List<PayOrderDto>>(list));

            return result;
        }


        #region for Client

        [Authorize]
        public async Task<PagedResultDto<PayOrderDto>> GetPublicListAsync(MallRequestDto input)
        {
            var query = _repository
                .GetQuery(input.ShopId)
                .Where(x => x.CreatorId == CurrentUser.Id);

            var totalCount = await query.CountAsync();

            query = query.OrderBy(input.Sorting);

            query = query.PageBy(input);

            var list = await query.ToListAsync();

            var result = new PagedResultDto<PayOrderDto>(totalCount, ObjectMapper.Map<List<PayOrder>, List<PayOrderDto>>(list));

            return result;
        }

        #endregion
    }


    public interface IPayOrderBase : IEntityDto<Guid>
    {
        public int TotalPrice { get; set; }

        public string Body { get; set; }

        public string BillNo { get; set; }

        public string AppName { get; set; }

        public string OpenId { get; set; }

        public string MchId { get; set; }


        public MallEnums.PayState State { get; set; }

        public MallEnums.OrderType Type { get; set; }

        public Guid? ShopId { get; set; }
        public DateTime CreationTime { get; set; }

    }


    /// <summary>
    /// <see cref="PayOrder"/>
    /// </summary>
    public class PayOrderDtoBase : IPayOrderBase
    {
        public Guid Id { get; set; }

        public int TotalPrice { get; set; }

        public string Body { get; set; }

        public string BillNo { get; set; }

        public string AppName { get; set; }

        public string OpenId { get; set; }

        public string MchId { get; set; }


        public MallEnums.PayState State { get; set; }

        public MallEnums.OrderType Type { get; set; }

        public Guid? ShopId { get; set; }
        
        public DateTime CreationTime { get; set; }
    }


    /// <summary>
    /// <see cref="PayOrder"/>
    /// </summary>
    public class PayOrderDto : IPayOrderBase
    {
        public Guid Id { get; set; }
        public int TotalPrice { get; set; }
        public string Body { get; set; }
        public string BillNo { get; set; }
        public string AppName { get; set; }
        public string OpenId { get; set; }
        public string MchId { get; set; }
        public MallEnums.PayState State { get; set; }
        public MallEnums.OrderType Type { get; set; }
        public Guid? ShopId { get; set; }
        public DateTime CreationTime { get; set; }

        public MallEnums.PayType PayType { get; protected set; }

        #region 支付成功

        public bool IsSuccessPay { get; protected set; }
        public DateTime? SuccessPayTime { get; protected set; }

        #endregion

        #region 退款相关

        public bool IsRefund { get; protected set; } = false;
        public DateTime? RefundTime { get; protected set; }
        public DateTime? RefundComplateTime { get; protected set; }

        /// <summary>
        /// 单位:分
        /// </summary>
        public int? RefundPrice { get; protected set; }

        #endregion

        public Guid? ShareFromUserId { get; protected set; }

        public Guid? PartnerId { get; protected set; }
    }
}