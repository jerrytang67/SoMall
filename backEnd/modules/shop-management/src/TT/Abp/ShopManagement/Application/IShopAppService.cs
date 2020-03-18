using System;
using System.Threading.Tasks;
using TT.Abp.ShopManagement.Application.Dtos;
using TT.Abp.ShopManagement.Domain;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace TT.Abp.ShopManagement.Application
{
    public interface IShopAppService : IApplicationService
    {
        Task<PagedResultDto<ShopDto>> GetListAsync(PagedResultRequestDto input);

        Task<ShopDto> GetByShortNameAsync(string shortName);

        Task<ShopDto> GetAsync(Guid id);

        Task<ShopDto> CreateAsync(CreateShopDto input);

        Task<ShopDto> UpdateAsync(Guid id, UpdateShopDto input);

        Task DeleteAsync(Guid id);
    }
}