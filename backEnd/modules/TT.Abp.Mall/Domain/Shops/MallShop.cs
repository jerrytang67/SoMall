using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TT.Abp.Shops;
using TT.Abp.Shops.Domain;
using Volo.Abp.Data;
using Volo.Abp.Domain.Entities;

namespace TT.Abp.Mall.Domain.Shops
{
    public class MallShop : AggregateRoot<Guid>, IShop, IUpdateShopData
    {
        public MallShop()
        {
            ExtraProperties = new ExtraPropertyDictionary();
        }

        public MallShop(IShopData shop) : base(shop.Id)
        {
            TenantId = shop.TenantId;
            UpdateInternal(shop);
            ExtraProperties = new ExtraPropertyDictionary();
        }

        public string Name { get; internal set; }
        public string ShortName { get; internal set; }
        public string LogoImage { get; internal set; }
        public string CoverImage { get; set; }
        public string Description { get; private set; }
        public Guid? TenantId { get; internal set; }

        /// <summary>
        /// 营业时间
        /// </summary>
        public string BussinessHours { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }

        public double? Lat { get; set; }
        public double? Lng { get; set; }

      

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

        protected void UpdateInternal(IShopData shop)
        {
            Name = shop.Name;
            ShortName = shop.ShortName;
            LogoImage = shop.LogoImage;
            CoverImage = shop.CoverImage;
            Description = shop.Description;
        }
    }
}