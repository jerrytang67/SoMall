using System;
using System.Threading.Tasks;
using Shouldly;
using TT.Abp.VisitorManagement.Domain;
using Volo.Abp.Identity;
using Xunit;

namespace TT.Abp.Modules.Tests.Samples
{
    /* This is just an example test class.
     * Normally, you don't test code of the modules you are using
     * (like IIdentityUserAppService here).
     * Only test your own application services.
     */
    public class SampleAppServiceTests : SoMallModulesTestBase
    {
        private readonly IVisitorShopLookupService _visitorShopLookupService;

        public SampleAppServiceTests()
        {
            _visitorShopLookupService = GetRequiredService<IVisitorShopLookupService>();
        }

        [Fact]
        public async Task Initial_Data_Should_Contain_Admin_User()
        {
            //Act
            var result = await _visitorShopLookupService.FindByIdAsync(Guid.NewGuid());

            result.ShouldBeNull();
            //Assert
            // result.TotalCount.ShouldBeGreaterThan(0);
            // result.Items.ShouldContain(u => u.UserName == "admin");
        }
    }
}