using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TT.Abp.Mall.Application.Addresses;
using TT.Abp.Mall.Application.Addresses.Dtos;
using TT.Abp.Mall.Application.Products.Dtos;
using TT.Abp.Mall.Application.Shops;
using TT.Abp.Mall.Domain.Addresses;
using TT.Abp.Mall.Domain.Orders;
using TT.Abp.Mall.Domain.Products;
using TT.Abp.Mall.Domain.Shops;
using TT.Abp.Weixin.Application;
using TT.Abp.Weixin.Application.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;
using Volo.Abp.Settings;

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
        private readonly ISettingProvider _setting;

        public ClientAppService(
            IGuidGenerator guidGenerator,
            IWeixinAppService weixinAppService,
            IMallShopLookupService shopLookupService,
            IMallShopRepository shopRepository,
            IReadOnlyRepository<Address, Guid> addressRepository,
            IRepository<ProductOrder, Guid> orderRepository,
            ISettingProvider setting)
        {
            _guidGenerator = guidGenerator;
            _weixinAppService = weixinAppService;
            _shopLookupService = shopLookupService;
            _shopRepository = shopRepository;
            _addressRepository = addressRepository;
            _orderRepository = orderRepository;
            _setting = setting;
        }

        public async Task<object> Init(ClientInitRequestDto input)
        {
            var shops = await _shopRepository.GetListAsync();
            return new
            {
                shops = ObjectMapper.Map<List<MallShop>, List<MallShopDto>>(shops)
            };
        }

        [HttpPost]
        public async Task<object> MiniAuth(WeChatMiniProgramAuthenticateModel loginModel)
        {
            var appid = await _setting.GetOrNullAsync(MallManagementSetting.MiniAppId);
            var appSec = await _setting.GetOrNullAsync(MallManagementSetting.MiniAppSecret);

            if (loginModel.appid == "wx20963173630db476")
            {
                appid = "wx20963173630db476";
                appSec = "b1d63d235d3d9e74836c740b5b63590c";
            }

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
    }

    public class ProductOrderRequestDto
    {
        public AddressDto Address { get; set; }
        public List<ProductSkuDto> Skus { get; set; }

        public string Comment { get; set; }
    }

    public class ClientInitRequestDto
    {
    }
}