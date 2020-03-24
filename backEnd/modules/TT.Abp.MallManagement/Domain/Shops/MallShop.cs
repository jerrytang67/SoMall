using System;
using System.Collections.Generic;
using TT.Abp.Shops;
using Volo.Abp.Domain.Entities;

namespace TT.Abp.MallManagement.Domain.Shops
{
    public class MallShop : AggregateRoot<Guid>, IShopData
    {
        public MallShop()
        {
        }

        public MallShop(IShopData shopData) : base(shopData.Id)
        {
            TenantId = shopData.TenantId;
            UpdateInternal(shopData);
            ExtraProperties = new Dictionary<string, object>();
        }

        public string Name { get; set; }
        public string ShortName { get; set; }
        public string LogoImage { get; set; }

        public string Description { get; set; }

        public Guid? TenantId { get; }


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