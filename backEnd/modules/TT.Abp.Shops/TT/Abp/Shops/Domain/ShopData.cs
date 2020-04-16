using System;

namespace TT.Abp.Shops.Domain
{
    public class ShopData : IShopData
    {
        public ShopData(Guid id, Guid? tenantId, string name, string shortName, string logoImage, string coverImage, string description)
        {
            Id = id;
            TenantId = tenantId;
            Name = name;
            ShortName = shortName;
            LogoImage = logoImage;
            CoverImage = coverImage;
            Description = description;
        }

        public Guid Id { get; }
        public Guid? TenantId { get; }
        public string Name { get; }
        public string ShortName { get; }
        public string LogoImage { get; }

        public string CoverImage { get; set; }

        public string Description { get; }
    }
}