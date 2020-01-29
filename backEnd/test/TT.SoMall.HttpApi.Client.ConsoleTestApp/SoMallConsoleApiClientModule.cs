using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace TT.SoMall.HttpApi.Client.ConsoleTestApp
{
    [DependsOn(
        typeof(SoMallHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class SoMallConsoleApiClientModule : AbpModule
    {
        
    }
}
