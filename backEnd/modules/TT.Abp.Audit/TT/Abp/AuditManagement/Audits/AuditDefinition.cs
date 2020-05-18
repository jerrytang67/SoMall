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
        }

        public string Name { get; set; }

        public Guid DefaultValue { get; set; }

        public List<string> Providers { get; }

        public ILocalizableString DisplayName
        {
            get => _displayName;
            set => _displayName = value;
        }

        private ILocalizableString _displayName;
    }
}