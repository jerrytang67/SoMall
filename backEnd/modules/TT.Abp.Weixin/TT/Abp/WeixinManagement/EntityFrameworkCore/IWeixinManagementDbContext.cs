using Microsoft.EntityFrameworkCore;
using TT.Abp.WeixinManagement.Domain;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace TT.Abp.WeixinManagement.EntityFrameworkCore
{
    [ConnectionStringName("WeixinManagement")]
    public interface IWeixinManagementDbContext : IEfCoreDbContext
    {
        DbSet<WechatUserinfo> WechatUserinfos { get; set; }
    }
}