using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace TT.Abp.ShopManagement.Domain
{
    public interface IShopManager : IDomainService
    {
        Task<Shop> CreateAsync([NotNull] string name);

        Task ChangeNameAsync([NotNull] Shop tenant, [NotNull] string name);
    }
}
