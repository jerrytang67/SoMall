using System;
using System.Threading.Tasks;
using TT.Abp.Shops.Application.Dtos;
using Volo.Abp.Application.Dtos;

namespace TT.Abp.Mall.Application.Shops
{
    public interface IMallShopAppService
    {
        Task<MallShopDto> GetAsync(Guid id);

        Task<ListResultDto<MallShopDto>> GetListAsync();

        Task ShopSync(ShopSyncRequestDto input);
    }
}