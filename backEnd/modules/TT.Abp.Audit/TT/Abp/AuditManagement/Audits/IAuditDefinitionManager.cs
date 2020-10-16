using System.Collections.Generic;
using System.Collections.Immutable;
using JetBrains.Annotations;

namespace TT.Abp.AuditManagement.Audits
{
    public interface IAuditDefinitionManager
    {
        AuditDefinition Get([NotNull] string name);

        IReadOnlyList<AuditDefinition> GetAll();

        AuditDefinition GetOrNull(string name);
    }

    public class AuditDefinitionContext : IAuditDefinitionContext
    {
        public AuditDefinitionContext(Dictionary<string, AuditDefinition> audits)
        {
            Audits = audits;
        }

        protected Dictionary<string, AuditDefinition> Audits { get; }

        public virtual AuditDefinition GetOrNull(string name)
        {
            return Audits.GetOrDefault(name);
        }

        public virtual void Add(params AuditDefinition[] definitions)
        {
            if (definitions.IsNullOrEmpty())
            {
                return;
            }

            foreach (var definition in definitions)
            {
                Audits[definition.Name] = definition;
            }
        }

        public virtual IReadOnlyList<AuditDefinition> GetAll()
        {
            return Audits.Values.ToImmutableList();
        }
    }
}