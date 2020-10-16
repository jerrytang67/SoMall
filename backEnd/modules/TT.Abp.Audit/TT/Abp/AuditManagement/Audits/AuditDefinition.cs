using System;
using System.Collections.Generic;
using Volo.Abp.Localization;

namespace TT.Abp.AuditManagement.Audits
{
    public class AuditDefinition
    {
        public AuditDefinition(string name, ILocalizableString displayName = null)
        {
            Name = name;
            DisplayName = displayName;
            Providers = new List<string>();
        }

        public string Name { get; set; }

        public Guid? DefaultValue { get; set; }

        public List<string> Providers { get; set; }

        public ILocalizableString DisplayName { get; set; }


        /// <summary>
        ///     Sets a property in the <see cref="Properties" /> dictionary.
        ///     This is a shortcut for nested calls on this object.
        /// </summary>
        public virtual AuditDefinition WithProviders(params string[] providers)
        {
            if (!providers.IsNullOrEmpty())
            {
                Providers.AddRange(providers);
            }

            return this;
        }
    }
}