using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TT.SoMall.Products;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.Users;

namespace TT.SoMall.EntityFrameworkCore
{
    public static class SoMallDbContextModelCreatingExtensions
    {
        public static void ConfigureSoMall(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(SoMallConsts.DbTablePrefix + "YourEntities", SoMallConsts.DbSchema);

            //    //...
            //});

            builder.Entity<ProductCategory>(b =>
            {
                b.ToTable(SoMallConsts.DbTablePrefix + "ProductCategory", SoMallConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.Name).IsRequired().HasMaxLength(64);
                b.Property(x => x.Code).HasMaxLength(32);
            });

            builder.Entity<ProductSpu>(b =>
            {
                b.ToTable(SoMallConsts.DbTablePrefix + "ProductSpu", SoMallConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.Name).IsRequired().HasMaxLength(64);
                b.Property(x => x.Code).HasMaxLength(32);
            });

            builder.Entity<ProductSku>(b =>
            {
                b.ToTable(SoMallConsts.DbTablePrefix + "ProductSku", SoMallConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.Name).IsRequired().HasMaxLength(64);
                b.Property(x => x.Code).HasMaxLength(32);
            });




        }

        public static void ConfigureCustomUserProperties<TUser>(this EntityTypeBuilder<TUser> b)
            where TUser : class, IUser
        {
            //b.Property<string>(nameof(AppUser.MyProperty))...
        }
    }
}