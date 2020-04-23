using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCore.CAP;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Serilog;
using TT.Abp.AppManagement.Apps;
using TT.Abp.Mall.Application.Addresses.Dtos;
using TT.Abp.Mall.Application.Clients.Dtos;
using TT.Abp.Mall.Application.Shops;
using TT.Abp.Mall.Domain.Addresses;
using TT.Abp.Mall.Domain.Orders;
using TT.Abp.Mall.Domain.Pays;
using TT.Abp.Mall.Domain.Shops;
using TT.Abp.Weixin.Application;
using TT.Abp.Weixin.Application.Dtos;
using TT.Abp.Weixin.Domain;
using TT.HttpClient.Weixin;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.EventBus.Local;
using Volo.Abp.Guids;
using Volo.Abp.Settings;
using Volo.Abp.Uow;

namespace TT.Abp.Mall.Application.Clients
{
    public interface IClientAppService
    {
        Task<object> Init(ClientInitRequestDto input);
        Task<object> MiniAuth(WeChatMiniProgramAuthenticateModel loginModel);
        Task<ListResultDto<AddressDto>> GetUserAddressListAsync();
        Task<object> SumbitOrder(ProductOrderRequestDto input);
    }

    public class ClientAppService : ApplicationService, IClientAppService
    {
        private readonly IGuidGenerator _guidGenerator;
        private readonly IWeixinAppService _weixinAppService;
        private readonly IMallShopLookupService _shopLookupService;
        private readonly IMallShopRepository _shopRepository;
        private readonly IReadOnlyRepository<Address, Guid> _addressRepository;
        private readonly IRepository<ProductOrder, Guid> _orderRepository;
        private readonly IRepository<TenPayNotify, Guid> _tenpayRepository;
        private readonly IPayOrderRepository _payOrderRepository;
        private readonly ISettingProvider _setting;
        private readonly IAppProvider _appProvider;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILocalEventBus _eventBus;
        private readonly ICapPublisher _capBus;

        public ClientAppService(
            IGuidGenerator guidGenerator,
            IWeixinAppService weixinAppService,
            IMallShopLookupService shopLookupService,
            IMallShopRepository shopRepository,
            IReadOnlyRepository<Address, Guid> addressRepository,
            IRepository<ProductOrder, Guid> orderRepository,
            IRepository<TenPayNotify, Guid> tenpayRepository,
            IPayOrderRepository payOrderRepository,
            ISettingProvider setting,
            IAppProvider appProvider,
            IHttpContextAccessor httpContextAccessor,
            ILocalEventBus eventBus,
            ICapPublisher capBus
        )
        {
            _guidGenerator = guidGenerator;
            _weixinAppService = weixinAppService;
            _shopLookupService = shopLookupService;
            _shopRepository = shopRepository;
            _addressRepository = addressRepository;
            _orderRepository = orderRepository;
            _tenpayRepository = tenpayRepository;
            _payOrderRepository = payOrderRepository;
            _setting = setting;
            _appProvider = appProvider;
            _httpContextAccessor = httpContextAccessor;
            _eventBus = eventBus;
            _capBus = capBus;
        }

        public async Task<object> Init(ClientInitRequestDto input)
        {
            await _eventBus.PublishAsync(new ClientInitEvent(input));

            var apps = await _appProvider.GetAllAsync();
            var shops = await _shopRepository.GetListAsync();
            var appName = _httpContextAccessor?.HttpContext.Request.Headers["AppName"].FirstOrDefault();
            return new
            {
                shops = ObjectMapper.Map<List<MallShop>, List<MallShopDto>>(shops),
                apps, appName
            };
        }

        [HttpPost]
        public async Task<object> MiniAuth(WeChatMiniProgramAuthenticateModel loginModel)
        {
            var appName = _httpContextAccessor?.HttpContext.Request.Headers["AppName"].FirstOrDefault();
            var app = await _appProvider.GetOrNullAsync(appName);
            var appid = app["appid"] ?? throw new AbpException($"App:{appName} appid未设置");
            var appSec = app["appsec"] ?? throw new AbpException($"App:{appName} appsec未设置");

            return await _weixinAppService.MiniAuth(loginModel, appid, appSec);
        }

        public async Task<ListResultDto<AddressDto>> GetUserAddressListAsync()
        {
            var list = await _addressRepository.Where(x => x.CreatorId == CurrentUser.Id).ToListAsync();
            return new ListResultDto<AddressDto>(ObjectMapper.Map<List<Address>, List<AddressDto>>(list));
        }

        [HttpPost]
        public async Task<object> SumbitOrder(ProductOrderRequestDto input)
        {
            var shopId = input.Skus[0].ShopId;
            var order = new ProductOrder(_guidGenerator.Create(), shopId, CurrentTenant.Id)
            {
                Comment = input.Comment,
                BuyerId = CurrentUser.Id,
                AddressId = input.Address.Id,
                AddressRealName = input.Address.RealName,
                AddressNickName = input.Address.NickName,
                AddressPhone = input.Address.Phone,
                AddressLocationLable = input.Address.LocationLable,
                AddressLocationAddress = input.Address.LocationAddress,
            };

            var orderItemList = new List<ProductOrderItem>();

            foreach (var sku in input.Skus)
            {
                orderItemList.Add(new ProductOrderItem(
                    _guidGenerator.Create(),
                    order.Id,
                    sku.SpuId,
                    sku.Id,
                    sku.Price,
                    sku.Num,
                    CurrentTenant.Id
                )
                {
                    SkuName = sku.Name,
                    SkuCoverImageUrl = sku.CoverImageUrls[0],
                    SkuUnit = sku.Unit,
                    SpuName = sku.SpuName
                    //Comment = sku.Comment
                });

                order.PriceOriginal += (sku.Price * (decimal) sku.Num);
            }

            order.OrderItems = orderItemList;

            var result = await _orderRepository.InsertAsync(order);

            return await Task.FromResult(result.Id);
        }


        /// <summary>
        /// JS-SDK支付回调地址（在统一下单接口中设置notify_url）
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public virtual async Task<object> PayNotifyUrl([FromBody] TenPayNotifyXml input)
        {
            Log.Warning(JsonConvert.SerializeObject(input));
            var return_msg = input.return_msg;
            var return_code = input.return_code;

            var tenPayNotify = new TenPayNotify
            {
                appid = input.appid,
                bank_type = input.bank_type,
                cash_fee = input.cash_fee,
                fee_type = input.fee_type,
                is_subscribe = input.is_subscribe,
                mch_id = input.mch_id,
                nonce_str = input.nonce_str,
                openid = input.openid,
                out_trade_no = input.out_trade_no,
                result_code = input.result_code,
                return_code = input.return_code,

                sign = input.sign,
                time_end = input.time_end,
                total_fee = input.total_fee,
                trade_type = input.trade_type,
                transaction_id = input.transaction_id
            };

            var notify = await _tenpayRepository.FirstOrDefaultAsync(z => z.out_trade_no == tenPayNotify.out_trade_no);

            if (notify == null)
            {
                notify = tenPayNotify;
                await _tenpayRepository.InsertAsync(notify, autoSave: true);
            }

            await _capBus.PublishAsync("mall.tenpay.notify", JsonConvert.SerializeObject(tenPayNotify));

            var xml = $@"<xml>
<return_code><![CDATA[{return_code}]]></return_code>
<return_msg><![CDATA[{return_msg}]]></return_msg>
</xml>";
            return xml;
        }
    }

    public class TenPayNotifyCapSubscriberService : ICapSubscribe, ITransientDependency
    {
        private readonly IPayOrderRepository _payOrderRepository;
        private readonly IRepository<ProductOrder, Guid> _productOrderRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TenPayNotifyCapSubscriberService(
            IPayOrderRepository payOrderRepository,
            IRepository<ProductOrder, Guid> productOrderRepository,
            IUnitOfWork unitOfWork
        )
        {
            _payOrderRepository = payOrderRepository;
            _productOrderRepository = productOrderRepository;
            _unitOfWork = unitOfWork;
        }

        [CapSubscribe("mall.tenpay.notify")]
        [UnitOfWork]
        public virtual async Task TenPayNotifySubscriber(string input)
        {
            var tenPayNotify = JsonConvert.DeserializeObject<TenPayNotify>(input);

            Log.Logger.Warning("Cap:mall.tenpay.notify");

            var payOrder = await _payOrderRepository.FindAsync(tenPayNotify.out_trade_no);
            if (payOrder != null)
            {
                if (payOrder.TotalPrice.ToString() == tenPayNotify.total_fee && tenPayNotify.result_code == "SUCCESS")
                {
                    payOrder.SuccessPay(tenPayNotify.Id);
                    await _unitOfWork.SaveChangesAsync();
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