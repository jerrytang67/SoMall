using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Settings;

namespace TT.Abp.AppManagement.Apps
{
    public static class AppProviderExtensions
    {
        // public static async Task<bool> IsTrueAsync([NotNull] this IAppProvider settingProvider, [NotNull] string name)
        // {
        //     Check.NotNull(settingProvider, nameof(settingProvider));
        //     Check.NotNull(name, nameof(name));
        //
        //     return string.Equals(
        //         await settingProvider.GetOrNullAsync(name),
        //         "true",
        //         StringComparison.OrdinalIgnoreCase
        //     );
        // }

        public static async Task<T> GetAsync<T>([NotNull] this ISettingProvider settingProvider, [NotNull] string name, T defaultValue = default)
            where T : struct
        {
            Check.NotNull(settingProvider, nameof(settingProvider));
            Check.NotNull(name, nameof(name));

            var value = await settingProvider.GetOrNullAsync(name);
            return value?.To<T>() ?? defaultValue;
        }
    }
}