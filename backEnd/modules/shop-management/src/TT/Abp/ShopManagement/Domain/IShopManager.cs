using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace TT.Abp.ShopManagement.Domain
{
    public interface IShopManager : IDomainService
    {
        Task<VisitorShop> CreateAsync([NotNull] string name);

        Task ChangeNameAsync([NotNull] VisitorShop tenant, [NotNull] string name);
    }
}
