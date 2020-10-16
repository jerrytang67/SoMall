using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TT.Abp.Shops;
using TT.SoMall.Users;
using Volo.Abp;
using Volo.Abp.Users;

namespace TT.SoMall.EntityFrameworkCore
{
    public static class SoMallDbContextModelCreatingExtensions
    {
        public static void ConfigureSoMall(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));
        }

        public static void ConfigureCustomUserProperties<TUser>(this EntityTypeBuilder<TUser> b)
            where TUser : class, IUser
        {
            b.Property<string>(nameof(AppUser.Nickname)).HasMaxLength(ShopConsts.MaxNameLength);
            b.Property<string>(nameof(AppUser.HeadImgUrl)).HasMaxLength(ShopConsts.MaxImageLength);

            //b.Property<string>(nameof(AppUser.MyProperty))...
        }
    }
}