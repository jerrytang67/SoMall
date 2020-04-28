using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TT.Abp.AppManagement.Domain;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace TT.Abp.AppManagement.EntityFrameworkCore
{
    public static class AppManagementDbExtensions
    {
        public static void ConfigureAppManagement(this ModelBuilder builder)
        {
            builder.Entity<App>(b =>
            {
                b.ToTable(AppManagementConsts.DbTablePrefix + "Apps", AppManagementConsts.DbSchema);

                b.ConfigureFullAuditedAggregateRoot();

                b.Property(x => x.Name).IsRequired().HasMaxLength(AppManagementConsts.MaxNameLength);
                b.Property(x => x.ClientName).IsRequired().HasMaxLength(AppManagementConsts.MaxNameLength);
                b.Property(x => x.Value).HasConversion(
                    v => JsonConvert.SerializeObject(v,
                        new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore}),
                    v => JsonConvert.DeserializeObject<Dictionary<string, string>>(v,
                        new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore}));

                b.Property(x => x.ProviderKey).HasMaxLength(AppManagementConsts.ProviderKeyLength);
                b.Property(x => x.ProviderName).HasMaxLength(AppManagementConsts.ProviderNameLength);
            });
        }
    }
}