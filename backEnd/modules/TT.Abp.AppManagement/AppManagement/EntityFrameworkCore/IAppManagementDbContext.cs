using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace TT.Abp.AppManagement.AppManagement.EntityFrameworkCore
{
    [ConnectionStringName("AppManagement")]
    public interface IAppManagementDbContext : IEfCoreDbContext
    {
    }
}