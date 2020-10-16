using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace TT.Abp.AppManagement.Domain
{
    public class App : FullAuditedAggregateRoot<Guid>
    {
        [NotNull] public string Name { get; set; }

        [NotNull] public string ClientName { get; set; }

        public Dictionary<string, string> Value { get; set; }

        [CanBeNull] public virtual string ProviderName { get; protected set; }

        [CanBeNull] public virtual string ProviderKey { get; protected set; }

        protected App()
        {
        }

        public App(
            Guid id,
            [NotNull] string name,
            [NotNull] string clientName,
            [NotNull] Dictionary<string, string> value,
            [CanBeNull] string providerName = null,
            [CanBeNull] string providerKey = null)
        {
            Check.NotNull(name, nameof(name));
            Check.NotNull(value, nameof(value));

            Id = id;
            Name = name;
            ClientName = clientName;
            Value = value;
            ProviderName = providerName;
            ProviderKey = providerKey;
        }
    }
}