using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using TT.Abp.AppManagement.Apps;
using TT.Abp.Mall.Application.Products.Dtos;
using TT.Abp.Mall.Definitions;
using TT.Abp.Mall.Domain.Products;
using TT.Extensions;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace TT.Abp.Mall.Application.Products
{
    public class ProductCategoryAppService
        : CrudAppService<
            ProductCategory,
            ProductCategoryDto,
            Guid, MallRequestDto,
            CategoryCreateOrUpdateDto,
            CategoryCreateOrUpdateDto
        >, IProductCategoryAppService
    {
        private readonly IRepository<AppProductCategory> _appCategoriesRepository;
        private readonly IAppDefinitionManager _appDefinitionManager;

        public ProductCategoryAppService(
            IRepository<ProductCategory, Guid> repository,
            IRepository<AppProductCategory> appCategoriesRepository,
            IAppDefinitionManager appDefinitionManager
        ) : base(repository)
        {
            base.GetListPolicyName = MallPermissions.Products.Default;
            base.CreatePolicyName = MallPermissions.Products.Create;
            base.UpdatePolicyName = MallPermissions.Products.Update;
            base.DeletePolicyName = MallPermissions.Products.Delete;

            _appCategoriesRepository = appCategoriesRepository;
            _appDefinitionManager = appDefinitionManager;
        }


        [Authorize]
        public async Task<GetForEditOutput<CategoryCreateOrUpdateDto>> GetForEdit(Guid id)
        {
            var find = await Repository
                .Include(x => x.AppProductCategories)
                .FirstOrDefaultAsync(z => z.Id == id);

            var schema = JToken.FromObject(new { });

            var apps = _appDefinitionManager.GetAll();
            schema["apps"] = apps.GetSelection("string", "appName", @"{0}", new[] {"Name"}, "Name");

            return new GetForEditOutput<CategoryCreateOrUpdateDto>(
                ObjectMapper.Map<ProductCategory, CategoryCreateOrUpdateDto>(find ?? new ProductCategory()), schema);
        }


        public override async Task<ProductCategoryDto> UpdateAsync(Guid id, CategoryCreateOrUpdateDto input)
        {
            await CheckUpdatePolicyAsync();

            var entity = await Repository.Include(x => x.AppProductCategories).FirstOrDefaultAsync(x => x.Id == id);

            foreach (var jo in input.Apps)
            {
                var appName = jo["value"] + "";
                var value = Convert.ToBoolean(jo["checked"]);
                if (value)
                {
                    if ((entity.AppProductCategories ?? new List<AppProductCategory>()).All(x => x.AppName != appName))
                    {
                        await _appCategoriesRepository.InsertAsync(new AppProductCategory(
                            appName, id, entity.TenantId), autoSave: true);
                    }
                }
                else
                {
                    if (entity.AppProductCategories != null && entity.AppProductCategories.Count > 0)
                    {
                        var existCate = entity.AppProductCategories.FirstOrDefault(x => x.AppName == appName);
                        if (existCate != null)
                            await _appCategoriesRepository.DeleteAsync(existCate, autoSave: true);
                    }
                }
            }

            MapToEntity(input, entity);
            await Repository.UpdateAsync(entity, autoSave: true);

            return MapToGetOutputDto(entity);
        }


        protected override IQueryable<ProductCategory> CreateFilteredQuery(MallRequestDto input)
        {
            return base.CreateFilteredQuery(input)
                .Include(x => x.AppProductCategories)
                .WhereIf(input.ShopId.HasValue, x => x.ShopId == input.ShopId);
        }
    }
}