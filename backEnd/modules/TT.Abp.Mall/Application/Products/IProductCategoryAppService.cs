using System;
using TT.Abp.Mall.Application.Products.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace TT.Abp.Mall.Application.Products
{
    public interface IProductCategoryAppService : ICrudAppService<
        ProductCategoryDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CategoryCreateOrUpdateDto,
        CategoryCreateOrUpdateDto>
    {
    }
}