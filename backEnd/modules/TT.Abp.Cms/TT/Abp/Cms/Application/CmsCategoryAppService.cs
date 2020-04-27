using System;
using TT.Abp.Cms.Domain;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace TT.Abp.Cms.Application
{
    public class CmsCategoryAppService : CrudAppService<Category, CategoryDto, Guid, PagedAndSortedResultRequestDto, Category, Category>
    {
        public CmsCategoryAppService(
            IRepository<Category, Guid> repository
            ) : base(repository)
        {
        }
    }

    public class CategoryDto : EntityDto<Guid>
    {
        public string Name { get; set; }
    }
}