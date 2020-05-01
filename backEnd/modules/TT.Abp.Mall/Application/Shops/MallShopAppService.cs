using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TT.Abp.Mall.Domain.Shops;
using TT.Abp.Shops.Application.Dtos;
using TT.Abp.Shops.Domain;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Uow;

namespace TT.Abp.Mall.Application.Shops
{
    public class MallShopAppService : ApplicationService, IMallShopAppService
    {
        private readonly IMallShopLookupService _mallShopLookupService;
        private readonly IMallShopRepository _mallShopRepository;

        public MallShopAppService(
            IMallShopLookupService mallShopLookupService,
            IMallShopRepository mallShopRepository
        )
        {
            _mallShopLookupService = mallShopLookupService;
            _mallShopRepository = mallShopRepository;
        }


        public async Task<MallShopDto> GetAsync(Guid id)
        {
            var shop = await _mallShopRepository.GetAsync(id, true);
            return ObjectMapper.Map<MallShop, MallShopDto>(shop);
        }


        public async Task<ListResultDto<MallShopDto>> GetListAsync()
        {
            var shops = await _mallShopRepository.GetListAsync();

            return new ListResultDto<MallShopDto>(
                ObjectMapper.Map<List<MallShop>, List<MallShopDto>>(shops)
            );
        }

        [HttpPost]
        public async Task ShopSync(ShopSyncRequestDto input)
        {
            var localShops = await _mallShopRepository.GetShopsAsync(input.ShopIds);

            foreach (var shopId in input.ShopIds)
            {
                // if (localShop.All(x => x.Id != id))
                // {
                // shop will auto sync to mallShop table
                var syncShop = await _mallShopLookupService.FindByIdAsync(shopId);
                //localShop.Update(syncShop as IShopData);
                // }
            }

            await Task.CompletedTask;
        }
    }

    public class MallShopCreateOrEditDto
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string LogoImage { get; set; }
        public string CoverImage { get; set; }
        public string Description { get; set; }
    }

    public class MallShopDto : EntityDto<Guid>
    {
        public string Name { get; set; }

        public string ShortName { get; set; }

        public string LogoImage { get; set; }

        public string CoverImage { get; set; }

        public string Description { get; set; }
    }
}