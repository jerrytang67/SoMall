using System;
using System.Collections.Generic;
using TT.Abp.Shops;
using TT.Abp.Shops.Domain;
using Volo.Abp.Domain.Entities;

namespace TT.Abp.Mall.Domain.Shops
{
    public class MallShop : AggregateRoot<Guid>, IShop, IUpdateShopData
    {
        public MallShop()
        {
            ExtraProperties = new Dictionary<string, object>();
        }

        public MallShop(IShopData shop) : base(shop.Id)
        {
            TenantId = shop.TenantId;
            UpdateInternal(shop);
            ExtraProperties = new Dictionary<string, object>();
        }

        public string Name { get; set; }
        public string ShortName { get; set; }
        public string LogoImage { get; set; }
        public string CoverImage { get; set; }
        public string Description { get; set; }
        public Guid? TenantId { get; }


        public virtual bool Update(IShopData shop)
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

        protected virtual bool Equals(IShopData shop)
        {
            return Id == shop.Id &&
                   TenantId == shop.TenantId &&
                   Name == shop.Name &&
                   ShortName == shop.ShortName &&
                   LogoImage == shop.LogoImage &&
                   CoverImage == shop.CoverImage &&
                   Description == shop.Description;
        }

        private void UpdateInternal(IShopData shop)
        {
            Name = shop.Name;
            ShortName = shop.ShortName;
            LogoImage = shop.LogoImage;
            CoverImage = shop.CoverImage;
            Description = shop.Description;
        }
    }
}