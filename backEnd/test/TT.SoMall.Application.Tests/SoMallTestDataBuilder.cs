using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Identity;
using Volo.Abp.Threading;

namespace TT.SoMall
{
    public class SoMallTestDataBuilder : ITransientDependency
    {
        private readonly IDataSeeder _dataSeeder;

        public SoMallTestDataBuilder(IDataSeeder dataSeeder)
        {
            _dataSeeder = dataSeeder;
        }

        public void Build()
        {
            AsyncHelper.RunSync(BuildInternalAsync);
        }

        public async Task BuildInternalAsync()
        {
            await _dataSeeder.SeedAsync();
        }
    }
}