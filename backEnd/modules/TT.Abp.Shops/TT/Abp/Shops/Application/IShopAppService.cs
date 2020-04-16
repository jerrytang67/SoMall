using System;
using System.Threading.Tasks;
using TT.Abp.Shops.Application.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace TT.Abp.Shops.Application
{
    public interface IShopAppService : IApplicationService
    {
        Task<PagedResultDto<ShopDto>> GetListAsync(PagedResultRequestDto input);

        Task<ShopDto> GetByShortNameAsync(string shortName);

        Task<ShopDto> GetAsync(Guid id);

        Task<ShopDto> CreateAsync(VisitorShopCreateOrEditDto input);

        Task<ShopDto> UpdateAsync(Guid id, VisitorShopCreateOrEditDto input);

        Task DeleteAsync(Guid id);
    }
}