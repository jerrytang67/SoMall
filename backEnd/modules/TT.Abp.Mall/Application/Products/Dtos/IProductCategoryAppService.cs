using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace TT.Abp.MallManagement.Application.Products.Dtos
{
    public interface IProductCategoryAppService : ICrudAppService<
        ProductCategoryDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateCategoryDto,
        CreateUpdateCategoryDto>
    {

    }

    public interface IProductSpuAppService : ICrudAppService<
        ProductSpuDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateSpuDto,
        CreateUpdateSpuDto>
    {

    }

    public interface IProductSkuAppService : ICrudAppService<
       ProductSkuDto,
       Guid,
       PagedAndSortedResultRequestDto,
       CreateUpdateSkuDto,
       CreateUpdateSkuDto>
    {

    }
}
