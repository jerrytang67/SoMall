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
        Task<PagedResultDto<VisitorShopDto>> GetListAsync(PagedResultRequestDto input);

        Task<VisitorShopDto> GetByShortNameAsync(string shortName);

        Task<VisitorShopDto> GetAsync(Guid id);

        Task<VisitorShopDto> CreateAsync(VisitorShopCreateOrEditDto input);

        Task<VisitorShopDto> UpdateAsync(Guid id, VisitorShopCreateOrEditDto input);

        Task DeleteAsync(Guid id);
    }
}