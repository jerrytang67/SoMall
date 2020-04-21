using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TT.Abp.AppManagement.Domain;
using TT.Abp.AppManagement.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace TT.Abp.AppManagement.Apps
{
    public class EfCoreAppRepository : EfCoreRepository<IAppManagementDbContext, App, Guid>, IAppRepository
    {
        public EfCoreAppRepository(IDbContextProvider<IAppManagementDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public virtual async Task<App> FindAsync(string name, string providerName, string providerKey)
        {
            return await DbSet
                .FirstOrDefaultAsync(
                    s => s.Name == name && s.ProviderName == providerName && s.ProviderKey == providerKey
                );
        }

        public virtual async Task<List<App>> GetListAsync(string providerName, string providerKey)
        {
            return await DbSet
                .Where(
                    s => s.ProviderName == providerName && s.ProviderKey == providerKey
                ).ToListAsync();
        }
    }
}