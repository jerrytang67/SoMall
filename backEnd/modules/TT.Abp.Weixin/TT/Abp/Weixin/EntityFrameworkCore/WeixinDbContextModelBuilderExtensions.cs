using Microsoft.EntityFrameworkCore;
using TT.Abp.Weixin.Domain;
using Volo.Abp;

namespace TT.Abp.Weixin.EntityFrameworkCore
{
    public static class WeixinDbContextModelBuilderExtensions
    {
        public static void ConfigureWeixinManagement(this ModelBuilder builder)
        {
            builder.Entity<WechatUserinfo>(b =>
            {
                b.ToTable(WeixinConsts.DbTablePrefix + "WechatUserinfos", WeixinConsts.DbSchema);

                b.HasKey(x => new {x.openid, x.appid});

                b.Property(x => x.appid).IsRequired().HasMaxLength(WeixinConsts.MaxOpenidLength);
                b.Property(x => x.openid).IsRequired().HasMaxLength(WeixinConsts.MaxOpenidLength);
                b.Property(x => x.unionid).HasMaxLength(WeixinConsts.MaxOpenidLength);
                b.Property(x => x.nickname).HasMaxLength(WeixinConsts.MaxOpenidLength);
                b.Property(x => x.headimgurl).HasMaxLength(WeixinConsts.MaxImageLength);
                b.Property(x => x.city).HasMaxLength(WeixinConsts.MaxImageLength);
                b.Property(x => x.province).HasMaxLength(WeixinConsts.MaxImageLength);
                b.Property(x => x.country).HasMaxLength(WeixinConsts.MaxImageLength);
            });
        }
    }
}