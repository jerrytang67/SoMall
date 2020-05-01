using System.Collections.Generic;
using Volo.Abp;
using Volo.Abp.Localization;

namespace TT.Abp.AppManagement.Apps
{
    public class AppDefinition
    {
        public string Name { get; set; }
        public string ClientName { get; set; }
        public Dictionary<string, string> DefaultValues { get; set; }
        public string ClientType { get; set; }
        public List<string> Providers { get; }
        
        public ILocalizableString DisplayName
        {
            get => _displayName;
            set => _displayName = value;
        }
        private ILocalizableString _displayName;

        public AppDefinition(
            string name,
            string clientName, string clientType = null,
            Dictionary<string, string> defaultValue = null,
            ILocalizableString displayName = null
        )
        {
            Name = name;
            ClientName = clientName;
            ClientType = clientType;
            DefaultValues = defaultValue;
            Providers = new List<string>();
            DisplayName = displayName;
        }
    }
}