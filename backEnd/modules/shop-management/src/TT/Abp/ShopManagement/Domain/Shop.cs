using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace TT.Abp.ShopManagement.Domain
{
    public class Shop : FullAuditedAggregateRoot<Guid>
    {

        public string Name { get; set; }


        protected Shop()
        {
            ExtraProperties = new Dictionary<string, object>();
        }


        protected internal Shop(Guid id, [NotNull] string name)
        {
            Id = id;
            SetName(name);

            //ConnectionStrings = new List<TenantConnectionString>();

            ExtraProperties = new Dictionary<string, object>();
        }


        internal void SetName([NotNull] string name)
        {
            Name = Check.NotNullOrWhiteSpace(name, nameof(name), ShopConsts.MaxNameLength);
        }
    }
}
