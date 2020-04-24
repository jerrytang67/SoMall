using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TT.Abp.Mall.Application;
using TT.Abp.Mall.Application.Products.Dtos;
using TT.Abp.Mall.EntityFrameworkCore;
using TT.Extensions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.ObjectMapping;

namespace TT.Abp.Mall.Domain.Products
{
    public interface IProductCategoryRepository : IBasicRepository<ProductCategory, Guid>
    {
        Task<List<ProductCategoryDto>> GetPublicListAsync(MallRequestDto input);
    }

    public class ProductCategoryRepository : EfCoreRepository<IMallDbContext, ProductCategory, Guid>, IProductCategoryRepository
    {
        private readonly IObjectMapper _mapper;

        public ProductCategoryRepository(
            IDbContextProvider<IMallDbContext> dbContextProvider,
            IObjectMapper mapper
        ) : base(dbContextProvider)
        {
            _mapper = mapper;
        }

        public async Task<List<ProductCategoryDto>> GetPublicListAsync(MallRequestDto input)
        {
            input.Sorting = input.Sorting.IsNullOrEmptyOrWhiteSpace() ? "sort desc" : input.Sorting;
            var list = await DbSet
                .Include(x => x.AppProductCategories)
                .WhereIf(input.ShopId.HasValue, x => x.ShopId == input.ShopId)
                .WhereIf(!input.AppName.IsNullOrEmptyOrWhiteSpace(), x => x.IsGlobal || x.AppProductCategories.Any(b => b.AppName == input.AppName))
                .OrderBy(input.Sorting)
                .ToListAsync();

            return _mapper.Map<List<ProductCategory>, List<ProductCategoryDto>>(list);
        }
    }
}