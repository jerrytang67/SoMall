using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Volo.Abp.Guids;
using Volo.Abp.Modularity;

namespace TT.Abp.Core
{
    public class TtCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.Replace(ServiceDescriptor.Transient<IGuidGenerator, SequentialGuid>());
        }
    }
}