using Microsoft.EntityFrameworkCore;
using TT.Abp.AppManagement.Domain;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace TT.Abp.AppManagement.EntityFrameworkCore
{
    [ConnectionStringName("AppManagement")]
    public interface IAppManagementDbContext : IEfCoreDbContext
    {
        DbSet<App> Apps { get; set; }
    }
}