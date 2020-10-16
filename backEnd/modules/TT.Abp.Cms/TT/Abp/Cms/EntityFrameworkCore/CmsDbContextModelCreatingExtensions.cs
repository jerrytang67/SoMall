using Microsoft.EntityFrameworkCore;
using TT.Abp.Cms.Domain;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace TT.Abp.Cms.EntityFrameworkCore
{
    public static class CmsDbContextModelCreatingExtensions
    {
        public static void ConfigureCms(this ModelBuilder builder)
        {
            //Check.NotNull(builder, nameof(builder));

            builder.Entity<Category>(b =>
            {
                b.ToTable(CmsConsts.DbTablePrefix + "Categories", CmsConsts.DbSchema);

                b.ConfigureFullAuditedAggregateRoot();

                b.Property(x => x.Name).IsRequired().HasMaxLength(32);
            });
        }
    }

    public static class CmsConsts
    {
        public const string DbTablePrefix = "Cms.";
        public const string DbSchema = null;
    }
}