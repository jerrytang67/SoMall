using Microsoft.EntityFrameworkCore;
using TT.Abp.ShopManagement.Domain;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace TT.Abp.ShopManagement.EntityFrameworkCore
{
    public static class ShopDbContextModelCreatingExtensions
    {
        public static void ConfigureShop(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            builder.Entity<Shop>(b =>
            {
                b.ToTable(ShopConsts.DbTablePrefix + "Shops", ShopConsts.DbSchema);

                b.ConfigureByConvention();

                b.Property(x => x.Name).IsRequired().HasMaxLength(ShopConsts.MaxNameLength);
                b.Property(x => x.ShortName).IsRequired().HasMaxLength(ShopConsts.MaxShortNameLength);
                b.Property(x => x.LogoImage).IsRequired().HasMaxLength(ShopConsts.MaxImageLength);
                b.Property(x => x.CoverImage).IsRequired().HasMaxLength(ShopConsts.MaxImageLength);
            });
        }
    }
}