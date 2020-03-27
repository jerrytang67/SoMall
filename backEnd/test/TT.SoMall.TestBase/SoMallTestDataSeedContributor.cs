using System;
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

            // return Task.CompletedTask;
        }
    }
}