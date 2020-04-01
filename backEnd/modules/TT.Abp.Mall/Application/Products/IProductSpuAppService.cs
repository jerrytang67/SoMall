using System;
using System.Threading.Tasks;
using TT.Abp.Mall.Application.Products.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace TT.Abp.Mall.Application.Products
{
    public interface IProductSpuAppService : ICrudAppService<
        ProductSpuDto,
        Guid,
        PagedAndSortedResultRequestDto,
        SpuCreateOrUpdateDto,
        SpuCreateOrUpdateDto>
    {
        Task<GetForEditOutput<SpuCreateOrUpdateDto>> GetForEdit(Guid id);
    }
}