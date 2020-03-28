using System;
using TT.Abp.Mall.Application.Products.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace TT.Abp.Mall.Application.Products
{
    public interface IProductSkuAppService : ICrudAppService<
        ProductSkuDto,
        Guid,
        PagedAndSortedResultRequestDto,
        SkuCreateOrUpdateDto,
        SkuCreateOrUpdateDto>
    {

    }
}