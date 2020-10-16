using Volo.Abp.Collections;

namespace TT.Abp.AppManagement.Apps
{
    public class AppOptions
    {
        public AppOptions()
        {
            DefinitionProviders = new TypeList<IAppDefinitionProvider>();
            ValueProviders = new TypeList<IAppValueProvider>();
        }

        public ITypeList<IAppDefinitionProvider> DefinitionProviders { get; }

        public ITypeList<IAppValueProvider> ValueProviders { get; }
    }
}