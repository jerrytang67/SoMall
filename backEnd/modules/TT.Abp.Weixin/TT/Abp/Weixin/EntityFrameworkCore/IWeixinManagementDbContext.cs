using Microsoft.EntityFrameworkCore;
using TT.Abp.Weixin.Domain;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace TT.Abp.Weixin.EntityFrameworkCore
{
    [ConnectionStringName("Weixin")]
    public interface IWeixinManagementDbContext : IEfCoreDbContext
    {
        DbSet<WechatUserinfo> WechatUserinfos { get; set; }
    }
}