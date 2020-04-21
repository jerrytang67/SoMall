using System.Collections.Generic;
using JetBrains.Annotations;

namespace TT.Abp.AppManagement.Apps
{
    public interface IAppDefinitionManager
    {
        [NotNull]
        AppDefinition Get([NotNull] string name);

        IReadOnlyList<AppDefinition> GetAll();

        AppDefinition GetOrNull(string name);
    }
}