using System;
using System.Collections.Generic;
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
        : CrudAppService<ProductSpu, ProductSpuDto, Guid, MallPagedAndSortedResultRequestDto, SpuCreateOrUpdateDto, SpuCreateOrUpdateDto>, IProductSpuAppService
    {
        private readonly IRepository<ProductSku, Guid> _skuRepository;
        private readonly IRepository<ProductCategory, Guid> _categoryRepository;

        public ProductSpuAppService(
            IRepository<ProductSpu, Guid> repository,
            IRepository<ProductSku, Guid> skuRepository,
            IRepository<ProductCategory, Guid> categoryRepository
        ) : base(repository)
        {
            _skuRepository = skuRepository;
            _categoryRepository = categoryRepository;
        }


        public override async Task<ProductSpuDto> CreateAsync(SpuCreateOrUpdateDto input)
        {
            var local = await Repository.FirstOrDefaultAsync(x => x.Code == input.Code || (x.Name == input.Name && x.CategoryId == input.CategoryId));

            if (local != null)
            {
                throw new UserFriendlyException("同分类下不能同名或商品编号相同");
            }

            var entity = MapToEntity(input);

            await Repository.InsertAsync(entity);

            foreach (var skuInput in input.Skus)
            {
                skuInput.SpuId = entity.Id;
                var sku = ObjectMapper.Map<SkuCreateOrUpdateDto, ProductSku>(skuInput);
                sku.NewId();
                await _skuRepository.InsertAsync(sku);
            }

            return MapToGetOutputDto(entity);
        }

        protected override IQueryable<ProductSpu> CreateFilteredQuery(MallPagedAndSortedResultRequestDto input)
        {
            return Repository
                .WhereIf(input.ShopId.HasValue, x => x.ShopId == input.ShopId);
        }

        public override async Task<ProductSpuDto> UpdateAsync(Guid id, SpuCreateOrUpdateDto input)
        {
            var local = await Repository.FirstOrDefaultAsync(x => (x.Code == input.Code || (x.Name == input.Name && x.CategoryId == input.CategoryId)) && x.Id != id);

            if (local != null)
            {
                throw new UserFriendlyException("同分类下不能同名或商品编号相同");
            }


            await CheckUpdatePolicyAsync();

            var entity = await Repository.Include(x => x.Skus).FirstOrDefaultAsync(x => x.Id == id);
            ObjectMapper.Map(input, entity);
            await Repository.UpdateAsync(entity, autoSave: true);

            var dbIds = entity.Skus.Select(x => x.Id).ToList();

            foreach (var skuInput in input.Skus)
            {
                var sku = entity.Skus.FirstOrDefault(x => x.Id == skuInput.Id);
                if (sku != null)
                {
                    dbIds.Remove(sku.Id);
                    skuInput.Id = sku.Id;
                    ObjectMapper.Map(skuInput, sku);
                    await _skuRepository.UpdateAsync(sku, autoSave: true);
                }
                else
                {
                    skuInput.SpuId = entity.Id;
                    sku = ObjectMapper.Map<SkuCreateOrUpdateDto, ProductSku>(skuInput);
                    sku.NewId();
                    await _skuRepository.InsertAsync(sku);
                }
            }

            //删除前端已删除的
            foreach (var noUsed in dbIds)
            {
                await _skuRepository.DeleteAsync(noUsed);
            }

            return MapToGetOutputDto(entity);
        }

        /// <summary>
        /// 获取编辑
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<GetForEditOutput<SpuCreateOrUpdateDto>> GetForEdit(Guid id)
        {
            var find = await Repository.Include(x => x.Skus).FirstOrDefaultAsync(z => z.Id == id);

            var schema = JToken.FromObject(new { });

            var categoryList = await _categoryRepository.GetListAsync();
            schema["categoryId"] = categoryList.GetSelection("string", "categoryId", @"{0}", new[] {"Name"}, "Id");

            return new GetForEditOutput<SpuCreateOrUpdateDto>(
                ObjectMapper.Map<ProductSpu, SpuCreateOrUpdateDto>(find ?? new ProductSpu()
                {
                    Skus = new List<ProductSku>()
                    {
                        new ProductSku("name")
                    }
                }), schema);
        }


        public override Task<ProductSpuDto> GetAsync(Guid id)
        {
            return base.GetAsync(id);
        }

        protected IQueryable<ProductSpu> CreateFilteredQuery(PagedAndSortedResultRequestDto input)
        {
            return Repository.Include(x => x.Category);
        }
    }
}