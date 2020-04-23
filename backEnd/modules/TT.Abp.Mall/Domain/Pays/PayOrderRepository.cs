using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TT.Abp.Mall.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace TT.Abp.Mall.Domain.Pays
{
    public interface IPayOrderRepository : IBasicRepository<PayOrder, Guid>
    {
        IQueryable<PayOrder> GetQuery(Guid? shopId = null);

        Task<PayOrder> FindAsync(string billNo);
        Task<List<PayOrder>> GetListAsync(string appName);
    }


    public class EfCorePayOrderRepository : EfCoreRepository<IMallDbContext, PayOrder, Guid>, IPayOrderRepository
    {
        public EfCorePayOrderRepository(IDbContextProvider<IMallDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public IQueryable<PayOrder> GetQuery(Guid? shopId)
        {
            return DbSet.WhereIf(shopId.HasValue, x => x.ShopId == shopId);
        }

        public virtual async Task<PayOrder> FindAsync(string billNo)
        {
            return await DbSet
                .FirstOrDefaultAsync(
                    s => s.BillNo == billNo
                );
        }

        public virtual async Task<List<PayOrder>> GetListAsync(string appName)
        {
            return await DbSet
                .Where(
                    s => s.AppName == appName
                ).ToListAsync();
        }
    }
}