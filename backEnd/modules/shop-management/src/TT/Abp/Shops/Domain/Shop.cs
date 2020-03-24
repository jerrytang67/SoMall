using System;
using System.Diagnostics.CodeAnalysis;
using Volo.Abp.Domain.Entities.Auditing;

namespace TT.Abp.Shops.Domain
{
    public class Shop : FullAuditedEntity<Guid>, IShopData
    {
        protected Shop()
        {
        }

        public Shop(Guid id, string name, string shortName, string logoImage, string description, Guid? tenantId)
        {
            Id = id;
            Name = name;
            ShortName = shortName;
            LogoImage = logoImage;
            Description = description;
            TenantId = tenantId;
        }

        [NotNull] public string Name { get; set; }
        [NotNull] public string ShortName { get; set; }
        [NotNull] public string LogoImage { get; set; }
        [NotNull] public string Description { get; set; }

        public virtual string CoverImage { get; set; }

        public Guid? TenantId { get; }
    }
}