using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TT.Abp.Mall.Application.Shops;
using TT.Abp.Mall.Domain.Shops;
using TT.Abp.Weixin.Application;
using TT.Abp.Weixin.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Settings;

namespace TT.Abp.Mall.Application.Clients
{
    public class ClientAppService : ApplicationService
    {
        private readonly IWeixinAppService _weixinAppService;
        private readonly IMallShopLookupService _shopLookupService;
        private readonly IMallShopRepository _shopRepository;
        private readonly ISettingProvider _setting;

        public ClientAppService(
            IWeixinAppService weixinAppService,
            IMallShopLookupService shopLookupService,
            IMallShopRepository shopRepository, ISettingProvider setting)
        {
            _weixinAppService = weixinAppService;
            _shopLookupService = shopLookupService;
            _shopRepository = shopRepository;
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
    }
}