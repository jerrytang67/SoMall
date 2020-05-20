using System.Collections.Generic;

namespace TT.Abp.AppManagement.Apps
{
    public interface IAppValueProviderManager
    {
        List<IAppValueProvider> Providers { get; }
    }
}