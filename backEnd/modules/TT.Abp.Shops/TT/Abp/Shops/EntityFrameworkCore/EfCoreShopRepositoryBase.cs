using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace TT.Abp.Shops.EntityFrameworkCore
{
    public abstract class EfCoreShopRepositoryBase<TDbContext, TShop> : EfCoreRepository<TDbContext, TShop, Guid>, IShopRepository<TShop>
        where TDbContext : IEfCoreDbContext
        where TShop : class, IShop
    {
        protected EfCoreShopRepositoryBase(IDbContextProvider<TDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<TShop> FindByShortNameAsync(string shortName, CancellationToken cancellationToken = default)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.ShortName == shortName, cancellationToken);
        }

        public async Task<List<TShop>> GetListAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default)
        {
            return await DbSet.Where(x => ids.Contains(x.Id)).ToListAsync(cancellationToken);
        }
    }
}