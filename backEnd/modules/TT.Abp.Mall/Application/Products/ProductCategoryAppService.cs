using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TT.Abp.Mall.Application.Products.Dtos;
using TT.Abp.Mall.Domain.Products;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace TT.Abp.Mall.Application.Products
{
    public class ProductCategoryAppService
        : CrudAppService<ProductCategory, ProductCategoryDto, Guid, PagedAndSortedResultRequestDto, CategoryCreateOrUpdateDto, CategoryCreateOrUpdateDto>
    {
        public ProductCategoryAppService(IRepository<ProductCategory, Guid> repository) : base(repository)
        {
        }
    }

    public class ProductSpuAppService
        : CrudAppService<ProductSpu, ProductSpuDto, Guid, PagedAndSortedResultRequestDto, SpuCreateOrUpdateDto, SpuCreateOrUpdateDto>
    {
        public ProductSpuAppService(IRepository<ProductSpu, Guid> repository) : base(repository)
        {
        }

        public override async Task<ProductSpuDto> CreateAsync(SpuCreateOrUpdateDto input)
        {
            var local = await Repository.FirstOrDefaultAsync(x => x.Code == input.Code || (x.Name == input.Name && x.CategoryId == input.CategoryId));

            if (local != null)
            {
                throw new UserFriendlyException("同分类下不能同名或商品编号相同");
            }

            return await base.CreateAsync(input);
        }

        public override async Task<ProductSpuDto> UpdateAsync(Guid id, SpuCreateOrUpdateDto input)
        {
            var local = await Repository.FirstOrDefaultAsync(x => (x.Code == input.Code || (x.Name == input.Name && x.CategoryId == input.CategoryId)) && x.Id != id);

            if (local != null)
            {
                throw new UserFriendlyException("同分类下不能同名或商品编号相同");
            }

            return await base.UpdateAsync(id, input);
        }

        protected override IQueryable<ProductSpu> CreateFilteredQuery(PagedAndSortedResultRequestDto input)
        {
            return base.CreateFilteredQuery(input).Include(x => x.Category);
        }
    }

    public class ProductSkuAppService
        : CrudAppService<ProductSku, ProductSkuDto, Guid, PagedAndSortedResultRequestDto, SkuCreateOrUpdateDto, SkuCreateOrUpdateDto>
    {
        public ProductSkuAppService(IRepository<ProductSku, Guid> repository) : base(repository)
        {
        }
    }
}