using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using TT.Abp.Shops;
using TT.Abp.Shops.Domain;
using Volo.Abp;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace TT.Abp.VisitorManagement.Domain
{
    public class VisitorShop : AggregateRoot<Guid>, IShopData
    {
        [NotNull] public virtual string Name { get; private set; }
        [NotNull] public virtual string ShortName { get; private set; }
        [NotNull] public virtual string LogoImage { get; private set; }
        [NotNull] public virtual string CoverImage { get; set; }
        [CanBeNull] public virtual string Description { get; private set; }

        public virtual Guid? TenantId { get; }

        protected VisitorShop()
        {
            ExtraProperties = new Dictionary<string, object>();
        }

        public VisitorShop(IShopData shopData) : base(shopData.Id)
        {
            TenantId = shopData.TenantId;
            UpdateInternal(shopData);
            ExtraProperties = new Dictionary<string, object>();
        }

        public virtual bool Update(IShopData shopData)
        {
            if (Id != shopData.Id)
            {
                throw new ArgumentException($"Given User's Id '{shopData.Id}' does not match to this User's Id '{Id}'");
            }

            if (TenantId != shopData.TenantId)
            {
                throw new ArgumentException(
                    $"Given User's TenantId '{shopData.TenantId}' does not match to this User's TenantId '{TenantId}'");
            }

            if (Equals(shopData))
            {
                return false;
            }

            UpdateInternal(shopData);
            return true;
        }

        protected virtual bool Equals(IShopData shopData)
        {
            return Id == shopData.Id &&
                   TenantId == shopData.TenantId &&
                   Name == shopData.Name &&
                   ShortName == shopData.ShortName &&
                   LogoImage == shopData.LogoImage &&
                   Description == shopData.Description;
        }

        private void UpdateInternal(IShopData shopData)
        {
            Name = shopData.Name;
            ShortName = shopData.ShortName;
            LogoImage = shopData.LogoImage;
            Description = shopData.Description;
        }
    }
}