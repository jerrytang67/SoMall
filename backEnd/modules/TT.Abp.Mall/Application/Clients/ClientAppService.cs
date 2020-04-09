using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TT.Abp.Mall.Application.Addresses;
using TT.Abp.Mall.Application.Addresses.Dtos;
using TT.Abp.Mall.Application.Shops;
using TT.Abp.Mall.Domain.Addresses;
using TT.Abp.Mall.Domain.Products;
using TT.Abp.Mall.Domain.Shops;
using TT.Abp.Weixin.Application;
using TT.Abp.Weixin.Application.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Settings;

namespace TT.Abp.Mall.Application.Clients
{
    public interface IClientAppService 
    {
        Task<object> Init();
        Task<object> MiniAuth(WeChatMiniProgramAuthenticateModel loginModel);
        Task<ListResultDto<AddressDto>> GetUserAddressListAsync();
    }

    public class ClientAppService : ApplicationService, IClientAppService
    {
        private readonly IWeixinAppService _weixinAppService;
        private readonly IMallShopLookupService _shopLookupService;
        private readonly IMallShopRepository _shopRepository;
        private readonly IReadOnlyRepository<Address, Guid> _addressRepository;
        private readonly ISettingProvider _setting;

        public ClientAppService(
            IWeixinAppService weixinAppService,
            IMallShopLookupService shopLookupService,
            IMallShopRepository shopRepository,
            IReadOnlyRepository<Address, Guid> addressRepository,
            ISettingProvider setting)
        {
            _weixinAppService = weixinAppService;
            _shopLookupService = shopLookupService;
            _shopRepository = shopRepository;
            _addressRepository = addressRepository;
            _setting = setting;
        }

        public async Task<object> Init()
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
            return await _weixinAppService.MiniAuth(loginModel, appid, appSec);
        }

        public async Task<ListResultDto<AddressDto>> GetUserAddressListAsync()
        {
            var list = await _addressRepository.Where(x => x.CreatorId == CurrentUser.Id).ToListAsync();
            return new ListResultDto<AddressDto>(ObjectMapper.Map<List<Address>, List<AddressDto>>(list));
        }
    }
}