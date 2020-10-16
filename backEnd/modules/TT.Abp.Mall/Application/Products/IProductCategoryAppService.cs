using System;
using System.Threading.Tasks;
using TT.Abp.Mall.Application.Products.Dtos;
using Volo.Abp.Application.Services;

namespace TT.Abp.Mall.Application.Products
{
    public interface IProductCategoryAppService : ICrudAppService<
        ProductCategoryDto,
        Guid,
        MallRequestDto,
        CategoryCreateOrUpdateDto,
        CategoryCreateOrUpdateDto>
    {
        Task<GetForEditOutput<CategoryCreateOrUpdateDto>> GetForEdit(Guid id);
    }
}