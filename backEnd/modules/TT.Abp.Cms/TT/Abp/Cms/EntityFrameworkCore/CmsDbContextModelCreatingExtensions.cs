using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace TT.Abp.Cms.EntityFrameworkCore
{
    public static class CmsDbContextModelCreatingExtensions
    {
        public static void ConfigureCms(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            // builder.Entity<MallUser>(b =>
            // {
            //     b.ToTable(MallConsts.DbTablePrefix + "Users", MallConsts.DbSchema);
            //
            //     b.ConfigureAbpUser();
            //     b.ConfigureExtraProperties();
            // });
        }
    }
}