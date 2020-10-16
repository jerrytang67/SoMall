using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TT.Abp.Mall.Domain.Shops;
using TT.Abp.Shops.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace TT.Abp.Mall.EntityFrameworkCore
{
    public class EfCoreMallShopRepository : EfCoreShopRepositoryBase<IMallDbContext, MallShop>, IMallShopRepository
    {
        public EfCoreMallShopRepository(IDbContextProvider<IMallDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }


        public Task<List<MallShop>> GetShopsAsync(int maxCount, string filter, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<MallShop>> GetShopsAsync(List<Guid> ids, CancellationToken cancellationToken = default)
        {
            return await DbSet.Where(x => ids.Contains(x.Id)).ToListAsync(cancellationToken: cancellationToken);
        }
    }
}