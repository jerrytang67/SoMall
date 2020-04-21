namespace TT.Abp.AppManagement.Apps
{
    public interface IAppDefinitionContext
    {
        AppDefinition GetOrNull(string name);

        void Add(params AppDefinition[] definitions);
    }
}