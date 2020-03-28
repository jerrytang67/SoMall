using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using TT.Abp.Mall.Application.Products.Dtos;
using TT.Abp.Mall.Domain.Products;
using TT.Extensions;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace TT.Abp.Mall.Application.Products
{
    public class ProductSpuAppService
        : CrudAppService<ProductSpu, ProductSpuDto, Guid, PagedAndSortedResultRequestDto, SpuCreateOrUpdateDto, SpuCreateOrUpdateDto>, IProductSpuAppService
    {
        private readonly IRepository<ProductCategory, Guid> _categoryRepository;

        public ProductSpuAppService(
            IRepository<ProductSpu, Guid> repository,
            IRepository<ProductCategory, Guid> categoryRepository
        ) : base(repository)
        {
            _categoryRepository = categoryRepository;
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

        /// <summary>
        /// 获取编辑
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<GetForEditOutput<SpuCreateOrUpdateDto>> GetForEdit(EntityDto<Guid> input)
        {
            var find = await Repository.FirstOrDefaultAsync(z => z.Id == input.Id);

            var schema = JToken.FromObject(new { });

            var categoryList = await _categoryRepository.GetListAsync();
            schema["categoryId"] = categoryList.GetSelection("number", "categoryId", @"{0}", new[] {"Name"}, "Id");

            return new GetForEditOutput<SpuCreateOrUpdateDto>(ObjectMapper.Map<ProductSpu, SpuCreateOrUpdateDto>(find), schema);
        }


        protected override IQueryable<ProductSpu> CreateFilteredQuery(PagedAndSortedResultRequestDto input)
        {
            return base.CreateFilteredQuery(input).Include(x => x.Category);
        }
    }
}