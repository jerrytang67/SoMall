using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TT.Extensions;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace TT.Abp.AuditManagement.Audits
{
    public class AuditCrudAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput>
        : CrudAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput>
        where TEntity : class, IEntity<TPrimaryKey>, INeedAudit
        where TEntityDto : IEntityDto<TPrimaryKey>
        where TUpdateInput : IEntityDto<TPrimaryKey>, INeedAuditBase
        where TCreateInput : INeedAuditBase
    {
        private readonly IAuditProvider _auditProvider;
        private readonly AuditManager _auditManager;

        public string CurrentAuditName { get; set; }

        public AuditCrudAppService(
            IRepository<TEntity, TPrimaryKey> repository,
            IServiceProvider serviceProvider
        ) : base(repository)
        {
            _auditProvider = serviceProvider.GetRequiredService<IAuditProvider>();
            _auditManager = serviceProvider.GetRequiredService<AuditManager>();
        }

        public virtual async Task StartAudit(TEntityDto input)
        {
            if (CurrentAuditName.IsNullOrEmptyOrWhiteSpace())
            {
                throw new UserFriendlyException("CurrentAuditName is not set");
            }

            var dbEntity = await GetEntityByIdAsync(input.Id);

            if (dbEntity == null)
            {
                throw new UserFriendlyException("NotFind");
            }

            dbEntity.AuditFlowId = await _auditProvider.GetOrNullAsync(CurrentAuditName);
            await _auditManager.StartAudit<TEntity, TPrimaryKey>(dbEntity);
        }

        public virtual async Task Agree()
        {
            await Task.CompletedTask;
        }
    }
}