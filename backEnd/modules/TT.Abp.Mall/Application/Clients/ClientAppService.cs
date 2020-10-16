using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using DotNetCore.CAP;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Serilog;
using TT.Abp.AppManagement.Apps;
using TT.Abp.Mall.Application.Addresses.Dtos;
using TT.Abp.Mall.Application.Clients.Dtos;
using TT.Abp.Mall.Application.Products.Dtos;
using TT.Abp.Mall.Application.Shops;
using TT.Abp.Mall.Domain.Addresses;
using TT.Abp.Mall.Domain.Orders;
using TT.Abp.Mall.Domain.Pays;
using TT.Abp.Mall.Domain.Products;
using TT.Abp.Mall.Domain.Shares;
using TT.Abp.Mall.Domain.Shops;
using TT.Abp.Mall.Handlers;
using TT.Abp.Mall.Utils;
using TT.Abp.Weixin.Application;
using TT.Abp.Weixin.Application.Dtos;
using TT.HttpClient.Weixin.Models;
using TT.HttpClient.Weixin.Signature;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.EventBus.Local;
using Volo.Abp.Guids;
using Volo.Abp.Settings;

namespace TT.Abp.Mall.Application.Clients
{
    public class ClientAppService : ApplicationService, IClientAppService
    {
        private readonly IReadOnlyRepository<Address, Guid> _addressRepository;
        private readonly IAppDefinitionManager _appDefinitionManager;
        private readonly IAppProvider _appProvider;
        private readonly ICapPublisher _capBus;
        private readonly IProductCategoryRepository _categoryRepository;
        private readonly ILocalEventBus _eventBus;
        private readonly IGuidGenerator _guidGenerator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMediator _mediator;
        private readonly IRepository<ProductOrder, Guid> _orderRepository;
        private readonly IPayOrderRepository _payOrderRepository;
        private readonly ISettingProvider _setting;
        private readonly IMallShopLookupService _shopLookupService;
        private readonly IMallShopRepository _shopRepository;
        private readonly ISignatureGenerator _signatureGenerator;
        private readonly IRepository<ProductSpu, Guid> _spuRepository;
        private readonly IRepository<TenPayNotify, Guid> _tenpayRepository;
        private readonly IWeixinAppService _weixinAppService;

        public ClientAppService(
            //其它模块
            IGuidGenerator guidGenerator,
            ICapPublisher capBus,
            ISignatureGenerator signatureGenerator,
            IWeixinAppService weixinAppService,
            IAppDefinitionManager appDefinitionManager,
            IAppProvider appProvider,

            //本模块
            IMallShopLookupService shopLookupService,
            IMallShopRepository shopRepository,
            IReadOnlyRepository<Address, Guid> addressRepository,
            IRepository<ProductOrder, Guid> orderRepository,
            IRepository<TenPayNotify, Guid> tenpayRepository,
            IProductCategoryRepository categoryRepository,
            IRepository<ProductSpu, Guid> spuRepository,
            IPayOrderRepository payOrderRepository,

            //系统
            ISettingProvider setting,
            IHttpContextAccessor httpContextAccessor,
            ILocalEventBus eventBus,
            IMediator mediator
        )
        {
            _guidGenerator = guidGenerator;
            _weixinAppService = weixinAppService;
            _shopLookupService = shopLookupService;
            _shopRepository = shopRepository;
            _addressRepository = addressRepository;
            _orderRepository = orderRepository;
            _tenpayRepository = tenpayRepository;
            _categoryRepository = categoryRepository;
            _spuRepository = spuRepository;
            _payOrderRepository = payOrderRepository;
            _setting = setting;
            _appProvider = appProvider;
            _httpContextAccessor = httpContextAccessor;
            _eventBus = eventBus;
            _mediator = mediator;
            _capBus = capBus;
            _appDefinitionManager = appDefinitionManager;
            _signatureGenerator = signatureGenerator;
        }

        public async Task<object> Init(ClientInitRequestDto input)
        {
            var appName = _httpContextAccessor.GetAppName();

            await _eventBus.PublishAsync(new ClientInitEvent(input));

            var apps = _appDefinitionManager.GetAll();
            var shops = await _shopRepository.GetListAsync();
            var categories = await _categoryRepository.GetPublicListAsync(new MallRequestDto {ShopId = input.ShopId, AppName = appName});

            var spus = await _spuRepository
                .Include(x => x.AppProductSpus)
                .Include(x => x.Skus)
                .Where(x => x.AppProductSpus.Any(x => x.AppName == appName))
                .ToListAsync();

            return new
            {
                shops = ObjectMapper.Map<List<MallShop>, List<MallShopDto>>(shops),
                apps,
                appName,
                categories,
                spus = ObjectMapper.Map<List<ProductSpu>, List<ProductSpuDtoBase>>(spus)
            };
        }

        [HttpPost]
        public async Task<object> MiniAuth(WeChatMiniProgramAuthenticateModel loginModel)
        {
            var appName = _httpContextAccessor.GetAppName();

            return await _weixinAppService.MiniAuth(loginModel, appName);
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

            if (input.Address == null)
            {
                throw new UserFriendlyException("请选择地址");
            }

            var order = new ProductOrder(_guidGenerator.Create(), shopId, CurrentTenant.Id)
            {
                Comment = input.Comment,
                BuyerId = CurrentUser.Id,
                AddressId = input.Address.Id,
                AddressRealName = input.Address.RealName,
                AddressNickName = input.Address.NickName,
                AddressPhone = input.Address.Phone,
                AddressLocationLabel = input.Address.LocationLabel,
                AddressLocationAddress = input.Address.LocationAddress
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

                order.PriceOriginal += sku.Price * (decimal) sku.Num;
            }

            order.OrderItems = orderItemList;

            var result = await _orderRepository.InsertAsync(order);

            return await Task.FromResult(result.Id);
        }


        [HttpGet]
        public async Task<QrDetail> GetQrDetail(string id)
        {
            var qrDetail = await _mediator.Send(new GetQrDetailQuery(id));
            qrDetail.Viewd();
            return qrDetail;
        }


        /// <summary>
        ///     JS-SDK支付回调地址（在统一下单接口中设置notify_url）
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public virtual async Task<object> PayNotifyUrl(string appName, [FromBody] TenPayNotifyXml input)
        {
            Log.Warning(JsonConvert.SerializeObject(input));
            var return_msg = input.return_msg;
            var return_code = input.return_code;

            var app = await _appProvider.GetOrNullAsync(appName);
            var appsec = app["appsec"] ?? throw new AbpException($"App:{appName} appsec未设置");

            var verifySign = _signatureGenerator.Generate(GetPayParameters(input), MD5.Create(), appsec);
            Log.Warning($"verifySign:{verifySign},InputSign:{input.sign}");

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
                var insertEntity = await _tenpayRepository.InsertAsync(notify, true);
                await _capBus.PublishAsync("mall.tenpay.notify", insertEntity);
            }

            var xml = $@"<xml>
<return_code><![CDATA[{return_code}]]></return_code>
<return_msg><![CDATA[{return_msg}]]></return_msg>
</xml>";
            return xml;
        }

        private PayParameters GetPayParameters(TenPayNotifyXml tenPayNotify)
        {
            var p = new PayParameters();
            p.AddParameter("appid", tenPayNotify.appid);
            p.AddParameter("bank_type", tenPayNotify.bank_type);
            p.AddParameter("cash_fee", tenPayNotify.cash_fee);
            p.AddParameter("fee_type", tenPayNotify.fee_type);
            p.AddParameter("is_subscribe", tenPayNotify.is_subscribe);
            p.AddParameter("mch_id", tenPayNotify.mch_id);
            p.AddParameter("nonce_str", tenPayNotify.nonce_str);
            p.AddParameter("openid", tenPayNotify.openid);
            p.AddParameter("out_trade_no", tenPayNotify.out_trade_no);
            p.AddParameter("result_code", tenPayNotify.result_code);
            p.AddParameter("return_code", tenPayNotify.return_code);

            p.AddParameter("time_end", tenPayNotify.time_end);
            p.AddParameter("total_fee", tenPayNotify.total_fee);
            p.AddParameter("trade_type", tenPayNotify.trade_type);
            p.AddParameter("transaction_id", tenPayNotify.transaction_id);
            return p;
        }
    }
}