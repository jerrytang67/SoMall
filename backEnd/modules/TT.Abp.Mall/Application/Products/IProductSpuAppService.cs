using System;
using System.Threading.Tasks;
using TT.Abp.Mall.Application.Products.Dtos;
using TT.Abp.Mall.Domain.Shares;
using Volo.Abp.Application.Services;

namespace TT.Abp.Mall.Application.Products
{
    public interface IProductSpuAppService : ICrudAppService<
        ProductSpuDto,
        Guid,
        MallRequestDto,
        SpuCreateOrUpdateDto,
        SpuCreateOrUpdateDto>
    {
        Task<GetForEditOutput<SpuCreateOrUpdateDto>> GetForEdit(Guid id);

        Task<QrDetail> GetQr(MallRequestDto input);
    }
}