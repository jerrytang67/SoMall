using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace TT.Abp.Mall.Application.Products.Dtos
{
    public interface IProductCategoryAppService : ICrudAppService<
        ProductCategoryDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CategoryCreateOrUpdateDto,
        CategoryCreateOrUpdateDto>
    {

    }

    public interface IProductSpuAppService : ICrudAppService<
        ProductSpuDto,
        Guid,
        PagedAndSortedResultRequestDto,
        SpuCreateOrUpdateDto,
        SpuCreateOrUpdateDto>
    {

    }

    public interface IProductSkuAppService : ICrudAppService<
       ProductSkuDto,
       Guid,
       PagedAndSortedResultRequestDto,
       SkuCreateOrUpdateDto,
       SkuCreateOrUpdateDto>
    {

    }
}
