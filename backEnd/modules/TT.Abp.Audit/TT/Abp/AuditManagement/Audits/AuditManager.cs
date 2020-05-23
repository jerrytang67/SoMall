using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TT.Abp.AuditManagement.Domain;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;

namespace TT.Abp.AuditManagement.Audits
{
    public class AuditManager : ITransientDependency
    {
        public readonly IRepository<AuditFlow, Guid> _auditFlowRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public AuditManager(
            IRepository<AuditFlow, Guid> auditFlowRepository,
            IUnitOfWorkManager unitOfWorkManager
        )
        {
            _auditFlowRepository = auditFlowRepository;
            _unitOfWorkManager = unitOfWorkManager;
        }

        [UnitOfWork]
        public virtual async Task StartAudit<T, TPrimaryKey>(T entity) where T : INeedAudit, IEntity<TPrimaryKey>
        {
            var auditFlow = await _auditFlowRepository.FirstOrDefaultAsync(x => x.Id == entity.AuditFlowId);

            entity.Audit = auditFlow.NodesMaxIndex;
            entity.AuditStatus = null;

            await _unitOfWorkManager.Current.SaveChangesAsync();

            // TODO:发送通知的东西 
            await Task.CompletedTask;
        }
    }
}