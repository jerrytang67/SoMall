using System;
using System.Linq;
using TT.Abp.Mall.Application.Products.Dtos;
using TT.Abp.Mall.Domain.Products;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace TT.Abp.Mall.Application.Products
{
    public class ProductCategoryAppService
        : CrudAppService<ProductCategory, ProductCategoryDto, Guid, MallRequestDto, CategoryCreateOrUpdateDto, CategoryCreateOrUpdateDto>
    {
        public ProductCategoryAppService(IRepository<ProductCategory, Guid> repository) : base(repository)
        {
        }

        protected override IQueryable<ProductCategory> CreateFilteredQuery(MallRequestDto input)
        {
            return base.CreateFilteredQuery(input)
                .WhereIf(input.ShopId.HasValue, x => x.ShopId == input.ShopId);
        }
    }
}