using System.Collections.Generic;
using System.Collections.Immutable;

namespace TT.Abp.AppManagement.Apps
{
    public class AppDefinitionContext : IAppDefinitionContext
    {
        public AppDefinitionContext(Dictionary<string, AppDefinition> apps)
        {
            Apps = apps;
        }

        protected Dictionary<string, AppDefinition> Apps { get; }

        public virtual AppDefinition GetOrNull(string name)
        {
            return Apps.GetOrDefault(name);
        }

        public virtual void Add(params AppDefinition[] definitions)
        {
            if (definitions.IsNullOrEmpty())
            {
                return;
            }

            foreach (var definition in definitions)
            {
                Apps[definition.Name] = definition;
            }
        }

        public virtual IReadOnlyList<AppDefinition> GetAll()
        {
            return Apps.Values.ToImmutableList();
        }
    }
}