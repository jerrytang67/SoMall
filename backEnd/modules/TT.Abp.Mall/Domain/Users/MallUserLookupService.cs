using Volo.Abp.Uow;
using Volo.Abp.Users;

namespace TT.Abp.Mall.Domain.Users
{
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
}