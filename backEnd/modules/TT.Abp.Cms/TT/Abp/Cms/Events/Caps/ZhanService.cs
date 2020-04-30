using System;
using System.Threading.Tasks;
using DotNetCore.CAP;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TT.Abp.Cms.Application;
using TT.Abp.Cms.Domain;
using TT.Abp.Cms.Events.Locals;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;

namespace TT.Abp.Cms.Events.Caps
{
    public class CmsCapService : ICapSubscribe, ITransientDependency
    {
        private readonly IRepository<Category, Guid> _repository;
        private readonly UnitOfWorkManager _unitOfWorkManager;

        public CmsCapService(
            IRepository<Category, Guid> repository,
            UnitOfWorkManager unitOfWorkManager
        )
        {
            _repository = repository;
            _unitOfWorkManager = unitOfWorkManager;
        }

        [CapSubscribe("cms.category.zan")]
        public async Task ZanHandler(CategoryDto input)
        {
            using (var uow = _unitOfWorkManager.Begin(requiresNew: true))
            {
                var find = await _repository.FirstOrDefaultAsync(x => x.Id == input.Id);

                find.AddZan();    
                
                await uow.SaveChangesAsync();
            }
        }
    }
}