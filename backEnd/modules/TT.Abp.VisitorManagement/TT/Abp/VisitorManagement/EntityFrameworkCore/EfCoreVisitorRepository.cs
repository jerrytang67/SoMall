using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TT.Abp.Shops.EntityFrameworkCore;
using TT.Abp.VisitorManagement.Domain;
using Volo.Abp.EntityFrameworkCore;

namespace TT.Abp.VisitorManagement.EntityFrameworkCore
{
    public class EfCoreVisitorShopRepository : EfCoreShopRepositoryBase<IVisitorManagementDbContext, VisitorShop>, IVisitorShopRepository
    {
        public EfCoreVisitorShopRepository(IDbContextProvider<IVisitorManagementDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public Task<List<VisitorShop>> GetShopsAsync(int maxCount, string filter, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}