using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TT.Abp.Mall.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Users;
using Volo.Abp.Users.EntityFrameworkCore;

namespace TT.Abp.Mall.Domain.Users
{
    public interface IMallUserRepository : IUserRepository<MallUser>
    {
        Task<List<MallUser>> GetUsersAsync(int maxCount, string filter, CancellationToken cancellationToken = default);
    }

    public class EfCoreMallUserRepository : EfCoreUserRepositoryBase<IMallDbContext, MallUser>, IMallUserRepository
    {
        public EfCoreMallUserRepository(IDbContextProvider<IMallDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<List<MallUser>> GetUsersAsync(int maxCount, string filter, CancellationToken cancellationToken = default)
        {
            return await DbSet
                .WhereIf(!string.IsNullOrWhiteSpace(filter), x => x.UserName.Contains(filter))
                .Take(maxCount).ToListAsync(cancellationToken);
        }
    }
}