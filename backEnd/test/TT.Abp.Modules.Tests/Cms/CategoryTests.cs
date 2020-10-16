using System.Threading.Tasks;
using Shouldly;
using TT.Abp.Cms.Application;
using Xunit;

namespace TT.Abp.Modules.Tests.Cms
{
    public class CategoryTests : SoMallModulesTestBase
    {
        private readonly ICmsCategoryAppService _service;

        public CategoryTests()
        {
            _service = GetRequiredService<ICmsCategoryAppService>();
        }

        [Fact]
        public async Task CreateAndGet()
        {
            //Act
            var result = await _service.CreateAsync(new CategoryCreateOrUpdate
            {
                Name = "TT"
            });

            //Assert
            result.ShouldNotBe(null);
            result.Name.ShouldBe("TT");
            //
            // var getDto = await _service.GetAsync(result.Id);
            //
            // getDto.ShouldNotBeNull();
            // getDto.Name.ShouldBe("TT");
            //
            // await _service.DianZan(result.Id);
            // await _service.DianZan(result.Id);
            //
            // getDto = await _service.GetAsync(result.Id);
            //
            // getDto.Zan.ShouldBe(2);
        }

        [Fact]
        public async Task TestZan()
        {
            //Act
            var result = await _service.CreateAsync(new CategoryCreateOrUpdate
            {
                Name = "TT"
            });

            await _service.DianZan(result.Id);

            var getDto = await _service.GetAsync(result.Id);

            getDto.Zan.ShouldBe(1);
        }
    }
}