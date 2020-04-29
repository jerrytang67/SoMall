using System;
using System.Threading.Tasks;
using Shouldly;
using TT.Abp.VisitorManagement.Domain;
using TT.SoMall;
using Xunit;

namespace TT.Abp.Modules.Tests.Samples
{
    /* This is just an example test class.
     * Normally, you don't test code of the modules you are using
     * (like IIdentityUserAppService here).
     * Only test your own application services.
     */
    public class VisitorModuleTests : SoMallModulesTestBase
    {
        private readonly IVisitorShopLookupService _visitorShopLookupService;
        private readonly IVisitorShopRepository _visitorShopRepository;

        public VisitorModuleTests()
        {
            _visitorShopLookupService = GetRequiredService<IVisitorShopLookupService>();
            _visitorShopRepository = GetRequiredService<IVisitorShopRepository>();
        }

        [Fact]
        public async Task VisitorShopLookupService_MUST_Copy_Default_Shop()
        {
            //Act
            var result = await _visitorShopLookupService.FindByIdAsync(TestConsts.Shop1Id);

            //Assert
            result.ShouldNotBe(null);
            result.Name.ShouldBe("TestShop");
            result.ShortName.ShouldBe("TS");
        }

        [Fact]
        public async Task VisitorShopLookupService_MUST_Copy_Default_Shop_FindBy_ShortName()
        {
            //Act
            await _visitorShopLookupService.FindByIdAsync(TestConsts.Shop1Id);

            var result = await _visitorShopRepository.FindByShortNameAsync("TS");

            //Assert
            result.ShouldNotBe(null);
            result.Name.ShouldBe("TestShop");
            result.ShortName.ShouldBe("TS");
        }
    }
}