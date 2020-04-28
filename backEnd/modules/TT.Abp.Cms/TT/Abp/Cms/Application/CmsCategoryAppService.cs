using System;
using System.Diagnostics.CodeAnalysis;
using TT.Abp.Cms.Domain;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace TT.Abp.Cms.Application
{
    public class CmsCategoryAppService : CrudAppService<Category, CategoryDto, Guid, PagedAndSortedResultRequestDto, CategoryCreateOrUpdate, CategoryCreateOrUpdate>
    {
        public CmsCategoryAppService(
            IRepository<Category, Guid> repository
        ) : base(repository)
        {
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