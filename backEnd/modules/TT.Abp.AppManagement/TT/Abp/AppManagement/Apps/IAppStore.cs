using System.Threading.Tasks;
using JetBrains.Annotations;

namespace TT.Abp.AppManagement.Apps
{
    public interface IAppStore
    {
        Task<string> GetOrNullAsync(
            [NotNull] string name,
            [CanBeNull] string providerName,
            [CanBeNull] string providerKey
        );
    }
}