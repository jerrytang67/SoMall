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
    public class VisitorShop : AggregateRoot<Guid>, IShop
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

        public VisitorShop(IShop shop) : base(shop.Id)
        {
            TenantId = shop.TenantId;
            UpdateInternal(shop);
            ExtraProperties = new Dictionary<string, object>();
        }

        public virtual bool Update(IShop shop)
        {
            if (Id != shop.Id)
            {
                throw new ArgumentException($"Given User's Id '{shop.Id}' does not match to this User's Id '{Id}'");
            }

            if (TenantId != shop.TenantId)
            {
                throw new ArgumentException(
                    $"Given User's TenantId '{shop.TenantId}' does not match to this User's TenantId '{TenantId}'");
            }

            if (Equals(shop))
            {
                return false;
            }

            UpdateInternal(shop);
            return true;
        }

        protected virtual bool Equals(IShop shop)
        {
            return Id == shop.Id &&
                   TenantId == shop.TenantId &&
                   Name == shop.Name &&
                   ShortName == shop.ShortName &&
                   LogoImage == shop.LogoImage &&
                   Description == shop.Description;
        }

        private void UpdateInternal(IShop shop)
        {
            Name = shop.Name;
            ShortName = shop.ShortName;
            LogoImage = shop.LogoImage;
            Description = shop.Description;
        }
    }
}