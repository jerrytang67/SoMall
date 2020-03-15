using System;
using Microsoft.EntityFrameworkCore;
using TT.Abp.ShopManagement.Domain;
using TT.Abp.VisitorManagement.Domain;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace TT.Abp.VisitorManagement.EntityFrameworkCore
{
    public static class VisitorDbContextModelBuilderExtensions
    {
        public static void ConfigureVisitorManagement(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            builder.Entity<VisitorLog>(b =>
            {
                b.ToTable(VisitorConsts.DbTablePrefix + "VisitorLogs", VisitorConsts.DbSchema);
                b.ConfigureFullAuditedAggregateRoot();
                b.ConfigureByConvention();

                b.HasOne(s => s.Form).WithMany(g => g.VisitorLogs).HasForeignKey(s => s.FormId);
            });


            builder.Entity<Credential>(b =>
            {
                b.ToTable(VisitorConsts.DbTablePrefix + "Credentials", VisitorConsts.DbSchema);
                b.ConfigureCreationAuditedAggregateRoot();
                b.Property(x => x.Data).IsRequired().HasMaxLength(VisitorConsts.MaxImageLength);
            });

            builder.Entity<Form>(b =>
            {
                b.ToTable(VisitorConsts.DbTablePrefix + "Forms", VisitorConsts.DbSchema);
                b.ConfigureFullAuditedAggregateRoot();

                b.Property(x => x.Title).IsRequired().HasMaxLength(VisitorConsts.MaxTitleLength);
                b.Property(x => x.Description).HasMaxLength(VisitorConsts.MaxDescriptionLength);
                b.Property(x => x.Theme).HasDefaultValue(VisitorEnums.FormTheme.Default);

                b.HasMany<VisitorLog>().WithOne().HasForeignKey(qt => qt.FormId);
                b.HasMany<FormItem>().WithOne().HasForeignKey(qt => qt.FromId);
            });

            builder.Entity<FormItem>(b =>
            {
                b.ToTable(VisitorConsts.DbTablePrefix + "FormItems", VisitorConsts.DbSchema);

                b.Property(x => x.FromId).HasColumnName(nameof(FormItem.FromId));
                b.Property(x => x.ItemId).HasColumnName(nameof(FormItem.ItemId));
                b.Property(x => x.Label).IsRequired().HasMaxLength(VisitorConsts.MaxTitleLength);
                b.Property(x => x.Key).IsRequired().HasMaxLength(VisitorConsts.MaxTitleLength);
                b.Property(x => x.PlaceHolder).IsRequired().HasMaxLength(VisitorConsts.MaxTitleLength);
                b.Property(x => x.DefaultValue).HasMaxLength(VisitorConsts.MaxTitleLength);
                b.Property(x => x.ErrorText).HasMaxLength(VisitorConsts.MaxTitleLength);
                b.Property(x => x.IsRequired).HasDefaultValue(true);
                b.Property(x => x.IsDisable).HasDefaultValue(false);
                b.Property(x => x.IsMulti).HasDefaultValue(false);

                b.HasKey(x => new {x.FromId, x.ItemId});
            });

            builder.Entity<ShopForm>(b =>
            {
                b.ToTable(VisitorConsts.DbTablePrefix + "ShopForms", VisitorConsts.DbSchema);
                b.Property(x => x.FromId);
                b.Property(x => x.ShopId);
                b.HasKey(x => new {x.FromId, x.ShopId});
            });

            // many to many 
            builder.Entity<ShopForm>()
                .HasOne(bc => bc.Form)
                .WithMany(b => b.ShopForms)
                .HasForeignKey(bc => bc.FromId);
        }
    }
}