using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using DotNetCore.CAP;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Serilog;
using TT.Abp.Cms.Domain;
using TT.Abp.Mall.Application.Products;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace TT.Abp.Cms.Application
{
    public interface ICmsCategoryAppService : ICrudAppService<CategoryDto, Guid, PagedAndSortedResultRequestDto,
        CategoryCreateOrUpdate, CategoryCreateOrUpdate>
    {
        Task<GetForEditOutput<CategoryCreateOrUpdate>> GetForEdit(Guid id);
        Task DianZan(Guid id);
    }

    public class CmsCategoryAppService : CrudAppService<Category, CategoryDto, Guid, PagedAndSortedResultRequestDto,
        CategoryCreateOrUpdate, CategoryCreateOrUpdate>, ICmsCategoryAppService
    {
        private readonly ICapPublisher _capBus;
        private readonly IRepository<CategoryEvent, Guid> _eventRepository;

        public CmsCategoryAppService(
            IRepository<Category, Guid> repository,
            IRepository<CategoryEvent, Guid> eventRepository,
            ICapPublisher capBus) : base(repository)
        {
            _eventRepository = eventRepository;
            _capBus = capBus;
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

            await Repository.InsertAsync(entity, true);

            return MapToGetOutputDto(entity);
        }


        [Authorize]
        public async Task<GetForEditOutput<CategoryCreateOrUpdate>> GetForEdit(Guid id)
        {
            var find = await Repository
                .FirstOrDefaultAsync(z => z.Id == id);

            var schema = JToken.FromObject(new { });

            return new GetForEditOutput<CategoryCreateOrUpdate>(
                ObjectMapper.Map<Category, CategoryCreateOrUpdate>(find ?? new Category()), schema);
        }

        [HttpGet]
        public async Task DianZan(Guid id)
        {
            var find = await Repository
                .FirstOrDefaultAsync(z => z.Id == id);

            find.AddZan();

            Log.Warning(JsonConvert.SerializeObject(find));

            // await _capBus.PublishAsync("cms.category.zan",  find);
            await _capBus.PublishAsync("cms.category.zan", ObjectMapper.Map<Category, CategoryDto>(find));
        }


        [HttpPut]
        public override async Task<CategoryDto> UpdateAsync(Guid id, CategoryCreateOrUpdate input)
        {
            //await _eventBus.PublishAsync(new CategoryUpdateEventDate(0, id, input));
            return await base.UpdateAsync(id, input);
        }
    }


    public class CategoryCreateOrUpdate
    {
        [NotNull] public string Name { get; set; }
    }


    /// <summary>
    ///     <see cref="Category" />
    /// </summary>
    public class CategoryDto : EntityDto<Guid>
    {
        public string Name { get; set; }

        public int Zan { get; set; }
    }
}