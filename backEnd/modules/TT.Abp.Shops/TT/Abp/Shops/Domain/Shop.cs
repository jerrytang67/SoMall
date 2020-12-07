using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Data;
using Volo.Abp.Domain.Entities.Auditing;

namespace TT.Abp.Shops.Domain
{
    public class Shop : FullAuditedAggregateRoot<Guid>, IShop
    {
        protected Shop()
        {
            ExtraProperties = new ExtraPropertyDictionary();
        }

        public Shop(Guid id, string name, string shortName, string logoImage, string description, Guid? tenantId)
        {
            Id = id;
            Name = name;
            ShortName = shortName;
            LogoImage = logoImage;
            Description = description;
            TenantId = tenantId;
            ExtraProperties = new ExtraPropertyDictionary();
        }


        public Shop(ShopData shopData)
        {
            Id = shopData.Id;
            Name = shopData.Name;
            ShortName = shopData.ShortName;
            LogoImage = shopData.ShortName;
            CoverImage = shopData.CoverImage;
            Description = shopData.Description;
            TenantId = shopData.TenantId;
            ExtraProperties = new ExtraPropertyDictionary();
        }


        [NotNull] public string Name { get; internal set; }

        [NotNull] public string ShortName { get; internal set; }

        [NotNull] public string LogoImage { get; internal set; }

        [NotNull] public string Description { get; internal set; }

        public virtual string CoverImage { get; set; }


        public Guid? TenantId { get; internal set; }

        internal void SetName([NotNull] string name)
        {
            Name = Check.NotNullOrWhiteSpace(name, nameof(name), ShopConsts.MaxNameLength);
        }

        internal void SetShortName([NotNull] string shortName)
        {
            ShortName = Check.NotNullOrWhiteSpace(shortName, nameof(shortName), ShopConsts.MaxShortNameLength);
        }

        internal void SetLogoImage([NotNull] string logoImage)
        {
            LogoImage = Check.NotNullOrWhiteSpace(logoImage, nameof(logoImage), ShopConsts.MaxImageLength);
        }

        internal void SetCoverImage([NotNull] string coverImage)
        {
            CoverImage = Check.NotNullOrWhiteSpace(coverImage, nameof(coverImage), ShopConsts.MaxImageLength);
        }

        internal void SetDescription(string desc)
        {
            Description = desc;
        }
    }
}