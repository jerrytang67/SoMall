using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;
using Volo.Abp.Users;

namespace TT.Abp.Mall.Domain.Users
{
    public interface IMallUserLookupService : IUserLookupService<MallUser>
    {
    }

    public class MallUserLookupService : UserLookupService<MallUser, IMallUserRepository>, IMallUserLookupService
    {
        public MallUserLookupService(
            IMallUserRepository userRepository,
            IUnitOfWorkManager unitOfWorkManager)
            : base(
                userRepository,
                unitOfWorkManager)
        {
        }

        protected override MallUser CreateUser(IUserData externalUser)
        {
            return new MallUser(externalUser);
        }
    }

    public interface IMallUserRepository : IBasicRepository<MallUser, Guid>, IUserRepository<MallUser>
    {
        Task<List<MallUser>> GetUsersAsync(int maxCount, string filter, CancellationToken cancellationToken = default);
    }
}