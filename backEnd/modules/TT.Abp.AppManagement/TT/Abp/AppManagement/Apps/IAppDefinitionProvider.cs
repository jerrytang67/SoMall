namespace TT.Abp.AppManagement.Apps
{
    public interface IAppDefinitionProvider
    {
        void Define(IAppDefinitionContext context);
    }
}