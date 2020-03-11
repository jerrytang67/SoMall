using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace TT.Abp.ShopManagement.Domain
{
    public class Shop : FullAuditedAggregateRoot<Guid>
    {
        [NotNull]
        public virtual string Name { get; protected set; }

        [NotNull]
        public virtual string ShortName { get; protected set; }

        [NotNull]
        public virtual string CoverImage { get; protected set; }


        [CanBeNull]
        public virtual string Description { get; set; }


        protected Shop()
        {
            ExtraProperties = new Dictionary<string, object>();
        }


        protected internal Shop(Guid id, [NotNull] string name, [NotNull] string shortName, [NotNull] string coverImage)
        {
            Id = id;
            SetName(name);
            SetShortName(shortName);
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

        internal void SetCoverImage([NotNull] string coverImage)
        {
            CoverImage = Check.NotNullOrWhiteSpace(coverImage, nameof(coverImage), ShopConsts.MaxCoverImageLength);
        }

        internal void SetDescription([CanBeNull] string desc)
        {
            Description = desc;
        }

    }
}
