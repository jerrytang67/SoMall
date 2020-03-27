using System;
using System.Threading.Tasks;
using Shouldly;
using TT.Abp.Mall.Domain.Shops;
using TT.Abp.VisitorManagement.Domain;
using TT.SoMall;
using Xunit;
using IVisitorShopLookupService = TT.Abp.VisitorManagement.Domain.IVisitorShopLookupService;

namespace TT.Abp.Modules.Tests.Samples
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

        public MallModuleTests()
        {
            _ShopLookupService = GetRequiredService<IMallShopLookupService>();
            _ShopRepository = GetRequiredService<IMallShopRepository>();
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
    }
}