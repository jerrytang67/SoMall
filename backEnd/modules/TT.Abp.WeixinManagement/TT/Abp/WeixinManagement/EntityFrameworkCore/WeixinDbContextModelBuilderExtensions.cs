using Microsoft.EntityFrameworkCore;
using TT.Abp.WeixinManagement.Domain;
using Volo.Abp;

namespace TT.Abp.WeixinManagement.EntityFrameworkCore
{
    public static class WeixinDbContextModelBuilderExtensions
    {
        public static void ConfigureWeixinManagement(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            builder.Entity<WechatUserinfo>(b =>
            {
                b.ToTable(WeixinConsts.DbTablePrefix + "VisitorLogs", WeixinConsts.DbSchema);

                b.Property(x => x.appid).IsRequired().HasMaxLength(WeixinConsts.MaxOpenidLength);
                b.Property(x => x.openid).IsRequired().HasMaxLength(WeixinConsts.MaxOpenidLength);
                b.Property(x => x.unionid).HasMaxLength(WeixinConsts.MaxOpenidLength);
                b.Property(x => x.nickname).HasMaxLength(WeixinConsts.MaxOpenidLength);
                b.Property(x => x.headimgurl).HasMaxLength(WeixinConsts.MaxImageLength);
                b.Property(x => x.city).HasMaxLength(WeixinConsts.MaxImageLength);
                b.Property(x => x.province).HasMaxLength(WeixinConsts.MaxImageLength);
                b.Property(x => x.country).HasMaxLength(WeixinConsts.MaxImageLength);

                b.HasKey(x => new {x.openid, x.appid});
            });
        }
    }
}