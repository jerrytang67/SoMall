using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Shouldly;
using TT.Abp.Mall.Application;
using TT.Abp.Mall.Application.Pays;
using TT.Abp.Mall.Application.Products;
using TT.Abp.Mall.Application.Shops;
using TT.Abp.Mall.Domain.Pays;
using TT.Abp.Mall.Domain.Products;
using TT.Abp.Mall.Domain.Shops;
using TT.Abp.Shops.Application.Dtos;
using TT.SoMall;
using Volo.Abp.Users;
using Xunit;

namespace TT.Abp.Modules.Tests.Mall
{
    /* This is just an example test class.
     * Normally, you don't test code of the modules you are using
     * (like IIdentityUserAppService here).
     * Only test your own application services.
     */
    public class MallModuleTests : SoMallModulesTestBase
    {
        private readonly IMallShopLookupService _ShopLookupService;
        private readonly IMallShopRepository _ShopRepository;

        private readonly IMallShopAppService _shopAppService;
        private readonly IProductSpuAppService _spuAppService;

        private readonly ICurrentUser _currentUser;


        public MallModuleTests()
        {
            _ShopLookupService = GetRequiredService<IMallShopLookupService>();
            _ShopRepository = GetRequiredService<IMallShopRepository>();
            _shopAppService = GetRequiredService<IMallShopAppService>();
            _spuAppService = GetRequiredService<IProductSpuAppService>();
            _currentUser = GetRequiredService<ICurrentUser>();
        }

        [Fact]
        public async Task ShopLookupService_MUST_Copy_Default_Shop()
        {
            //Act
            var result = await _ShopLookupService.FindByIdAsync(TestConsts.Shop1Id);

            //Assert
            result.ShouldNotBe(null);
            result.Name.ShouldBe("TestShop");
            result.ShortName.ShouldBe("TS");
        }

        [Fact]
        public async Task ShopLookupService_MUST_Copy_Default_Shop_FindBy_ShortName()
        {
            //Act
            await _ShopLookupService.FindByIdAsync(TestConsts.Shop1Id);

            var result = await _ShopRepository.FindByShortNameAsync("TS");


            //Assert
            result.ShouldNotBe(null);
            result.Name.ShouldBe("TestShop");
            result.ShortName.ShouldBe("TS");
        }

        [Fact]
        public async Task ShopSync_MUST_Copy_Default_Shop()
        {
            //Act
            await WithUnitOfWorkAsync(async () =>
            {
                await _shopAppService.ShopSync(new ShopSyncRequestDto()
                {
                    ShopIds = new List<Guid>() { TestConsts.Shop1Id, TestConsts.Shop2Id }
                });
            });

            var list = await _shopAppService.GetListAsync();

            //Assert
            list.Items.Count.ShouldBe(2);
        }

        [Fact]
        public async Task PayOrder_Convert_Test()
        {
            var str = @"{""Id"": ""e8689d8f-43e4-20f7-fc93-39f52104e06f""}";

            var payDto = JsonConvert.DeserializeObject<PayOrderDto>(str);
            var pay = JsonConvert.DeserializeObject<PayOrder>(str);
            payDto.Id.ShouldBe(new Guid("e8689d8f-43e4-20f7-fc93-39f52104e06f")); // it True


            //pay.Id.ShouldBe(new Guid("e8689d8f-43e4-20f7-fc93-39f52104e06f")); // wrong

            var spu = JsonConvert.DeserializeObject<ProductSpu>(str);
            //spu.Id.ShouldBe(new Guid("e8689d8f-43e4-20f7-fc93-39f52104e06f")); // wrong
            await Task.CompletedTask;
        }


        [Fact]
        public async Task GetSpuQr()
        {
            //act
            var result = await _spuAppService.GetQr(new MallRequestDto() { Keywords = "!@3", AppName = "mall_mini" });
            result.Params["Keywords"].ShouldBe("!@3");
            result.Id.ShouldNotBe(Guid.Empty);
            result.CreatorId.ShouldBe(_currentUser.Id);
            result.ViewCount.ShouldBe(1);
        }
    }
}