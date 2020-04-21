using Volo.Abp.DependencyInjection;

namespace TT.Abp.AppManagement.Apps
{
    public abstract class AppDefinitionProvider : IAppDefinitionProvider, ITransientDependency
    {
        public abstract void Define(IAppDefinitionContext context);
    }
}