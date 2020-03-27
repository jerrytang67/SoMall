using Microsoft.EntityFrameworkCore;
using TT.Abp.Weixin.Domain;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace TT.Abp.Weixin.EntityFrameworkCore
{
    [ConnectionStringName("Weixin")]
    public class WeixinManagementDbContext : AbpDbContext<WeixinManagementDbContext>, IWeixinManagementDbContext
    {
        public DbSet<WechatUserinfo> WechatUserinfos { get; set; }

        public WeixinManagementDbContext(DbContextOptions<WeixinManagementDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureWeixinManagement();
        }
    }
}