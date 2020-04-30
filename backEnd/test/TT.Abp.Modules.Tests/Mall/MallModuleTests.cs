using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shouldly;
using TT.Abp.Mall.Application.Shops;
using TT.Abp.Mall.Domain.Shops;
using TT.Abp.Shops.Application.Dtos;
using TT.SoMall;
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

        public MallModuleTests()
        {
            _ShopLookupService = GetRequiredService<IMallShopLookupService>();
            _ShopRepository = GetRequiredService<IMallShopRepository>();
            _shopAppService = GetRequiredService<IMallShopAppService>();
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
                    ShopIds = new List<Guid>() {TestConsts.Shop1Id, TestConsts.Shop2Id}
                });
            });

            var list = await _shopAppService.GetListAsync();

            //Assert
            list.Items.Count.ShouldBe(2);
        }
    }
}