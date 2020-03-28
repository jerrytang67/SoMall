using System;
using TT.Abp.Mall.Application.Products.Dtos;
using TT.Abp.Mall.Domain.Products;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace TT.Abp.Mall.Application.Products
{
    public class ProductSkuAppService
        : CrudAppService<ProductSku, ProductSkuDto, Guid, PagedAndSortedResultRequestDto, SkuCreateOrUpdateDto, SkuCreateOrUpdateDto>
    {
        public ProductSkuAppService(IRepository<ProductSku, Guid> repository) : base(repository)
        {
        }
    }
}