using Microsoft.EntityFrameworkCore;
using TT.Abp.AccountManagement.Domain;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace TT.Abp.AccountManagement.EntityFrameworkCore
{
    [ConnectionStringName("AccountManagement")]
    public interface IAccountManagementDbContext : IEfCoreDbContext
    {
        DbSet<RealNameInfo> RealNameInfos { get; set; }
    }
}