using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using TT.Abp.Cms.Domain;
using TT.Abp.Mall.Application.Products;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace TT.Abp.Cms.Application
{
    public class CmsCategoryAppService : CrudAppService<
        Category,
        CategoryDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CategoryCreateOrUpdate,
        CategoryCreateOrUpdate>
    {
        public CmsCategoryAppService(
            IRepository<Category, Guid> repository
        ) : base(repository)
        {
            // base.GetListPolicyName = CmsPermissions.Categories.Default;
            base.CreatePolicyName = CmsPermissions.Categories.Create;
            base.UpdatePolicyName = CmsPermissions.Categories.Update;
            base.DeletePolicyName = CmsPermissions.Categories.Delete;
        }



        public override async Task<CategoryDto> CreateAsync(CategoryCreateOrUpdate input)
        {
            await CheckCreatePolicyAsync();

            var entity = MapToEntity(input);

            TryToSetTenantId(entity);

            await Repository.InsertAsync(entity, autoSave: true);

            return MapToGetOutputDto(entity);
        }

        // [Authorize]
        public async Task<GetForEditOutput<CategoryCreateOrUpdate>> GetForEdit(Guid id)
        {
            var find = await Repository
                .FirstOrDefaultAsync(z => z.Id == id);

            var schema = JToken.FromObject(new { });

            return new GetForEditOutput<CategoryCreateOrUpdate>(
                ObjectMapper.Map<Category, CategoryCreateOrUpdate>(find ?? new Category()), schema);
        }
    }

    public class CategoryCreateOrUpdate
    {
        [NotNull] public string Name { get; set; }
    }

    public class CategoryDto : EntityDto<Guid>
    {
        public string Name { get; set; }
    }
}