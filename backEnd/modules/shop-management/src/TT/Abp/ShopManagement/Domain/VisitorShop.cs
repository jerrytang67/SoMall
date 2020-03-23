using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace TT.Abp.ShopManagement.Domain
{
    public class VisitorShop : FullAuditedAggregateRoot<Guid>, IMultiTenant, IShopData
    {
        [NotNull] public virtual string Name { get; protected set; }

        [NotNull] public virtual string ShortName { get; set; }

        [NotNull] public virtual string LogoImage { get; protected set; }

        [NotNull] public virtual string CoverImage { get; protected set; }


        [CanBeNull] public virtual string Description { get; set; }

        public virtual Guid? TenantId { get; set; }

        protected VisitorShop()
        {
            ExtraProperties = new Dictionary<string, object>();
        }


        protected internal VisitorShop(Guid id, [NotNull] string name, [NotNull] string shortName, [NotNull] string logoImage, [NotNull] string coverImage)
        {
            Id = id;
            SetName(name);
            SetShortName(shortName);
            SetLogoImage(logoImage);
            SetCoverImage(coverImage);
            ExtraProperties = new Dictionary<string, object>();
        }


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

        internal void SetDescription([CanBeNull] string desc)
        {
            Description = desc;
        }
    }
}