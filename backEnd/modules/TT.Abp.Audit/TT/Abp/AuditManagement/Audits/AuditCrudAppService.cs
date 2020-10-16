using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TT.Abp.Shops;
using TT.Extensions;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Features;

namespace TT.Abp.AuditManagement.Audits
{
    public class AuditCrudAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput>
        : CrudAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput>
        where TEntity : class, IEntity<TPrimaryKey>, INeedAudit
        where TEntityDto : IEntityDto<TPrimaryKey>
        where TUpdateInput : IEntityDto<TPrimaryKey>, INeedAuditBase
        where TCreateInput : INeedAuditBase
    {
        private readonly ICurrentShop _currentShop;
        private readonly IAuditProvider _auditProvider;
        private readonly AuditManager _auditManager;

        public string CurrentAuditName { get; set; }

        public AuditCrudAppService(
            IRepository<TEntity, TPrimaryKey> repository,
            IServiceProvider serviceProvider
        ) : base(repository)
        {
            _currentShop = serviceProvider.GetRequiredService<ICurrentShop>();
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

            if (dbEntity is IMultiShop && HasShopIdProperty(dbEntity))
            {
                var propertyInfo = dbEntity.GetType().GetProperty(nameof(IMultiShop.ShopId));

                if (propertyInfo != null)
                {
                    if (propertyInfo.GetValue(dbEntity) is Guid shopId)
                    {
                        _currentShop.Change(shopId);
                    }    
                }
            }

            dbEntity.AuditFlowId = await _auditProvider.GetOrNullAsync(CurrentAuditName);
            await _auditManager.StartAudit<TEntity, TPrimaryKey>(dbEntity);
        }

        public virtual async Task Agree()
        {
            await Task.CompletedTask;
        }


        protected virtual bool HasShopIdProperty(TEntity entity)
        {
            return entity.GetType().GetProperty(nameof(IMultiShop.ShopId)) != null;
        }
    }
}