using System;
using System.Diagnostics.CodeAnalysis;
using Volo.Abp;

namespace TT.Abp.ShopManagement.Domain
{
    public interface IShopData
    {
        Guid Id { get; set; }
        Guid TenantId { get; set; }
        string Name { get; set; }

        string ShortName { get; set; }

        string LogoImage { get; set; }

        string Description { get; set; }

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
    }
}