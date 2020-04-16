using System;

namespace TT.Abp.Shops.Domain
{
    public interface IShopData
    {
        public Guid Id { get; }

        public Guid? TenantId { get; }
        public string Name { get; }
        public string ShortName { get; }
        public string LogoImage { get; }
        
        string CoverImage { get; set; }
        public string Description { get; }
    }
}