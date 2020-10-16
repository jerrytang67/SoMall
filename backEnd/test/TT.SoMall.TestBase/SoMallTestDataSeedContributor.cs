using System.Threading.Tasks;
using TT.Abp.Shops.Domain;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace TT.SoMall
{
    public class SoMallTestDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Shop> _shopRepository;

        public SoMallTestDataSeedContributor(IRepository<Shop> shopRepository)
        {
            _shopRepository = shopRepository;
        }


        public async Task SeedAsync(DataSeedContext context)
        {
            var shop = await _shopRepository.InsertAsync(
                new Shop(
                    new ShopData(
                        TestConsts.Shop1Id,
                        null,
                        "TestShop",
                        "TS",
                        "logo",
                        "cover",
                        "null description"
                    )));

            var shop2 = await _shopRepository.InsertAsync(
                new Shop(
                    new ShopData(
                        TestConsts.Shop2Id,
                        null,
                        "TestShop2",
                        "TS2",
                        "logo2",
                        "cover2",
                        "null description2"
                    )));

            await Task.CompletedTask;
        }
    }
}