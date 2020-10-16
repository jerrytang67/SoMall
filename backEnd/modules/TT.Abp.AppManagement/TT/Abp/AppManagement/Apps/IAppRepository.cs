using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TT.Abp.AppManagement.Domain;
using Volo.Abp.Domain.Repositories;

namespace TT.Abp.AppManagement.Apps
{
    public interface IAppRepository : IBasicRepository<App, Guid>
    {
        Task<App> FindAsync(string name, string providerName, string providerKey);

        Task<List<App>> GetListAsync(string providerName, string providerKey);
    }
}