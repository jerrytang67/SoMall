using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace TT.Abp.AppManagement.Apps
{
    public interface IAppValueProvider
    {
        string Name { get; }

        Task<Dictionary<string, string>> GetOrNullAsync([NotNull] AppDefinition app);
    }
}