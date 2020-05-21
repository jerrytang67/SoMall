using System;
using System.ComponentModel.DataAnnotations;
using TT.Abp.AuditManagement.Domain;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace TT.Abp.AuditManagement.Application
{
    public class AuditFlowAppService : CrudAppService<AuditFlow, AuditFlowDto, Guid, PagedResultRequestDto, AuditFlowCreateOrEditDto, AuditFlowCreateOrEditDto>
    {
        public AuditFlowAppService(IRepository<AuditFlow, Guid> repository) : base(repository)
        {
        }
    }

    public class AuditFlowCreateOrEditDto
    {
        [Required] public string AuditName { get; set; }
        public bool Enable { get; set; }
        [Required] public string ProviderName { get; set; }
        public string ProviderKey { get; set; }
    }

    /// <summary>
    /// <see cref="AuditFlow"/>
    /// </summary>
    public class AuditFlowDto : CreationAuditedEntityDto<Guid>
    {
        public string AuditName { get; set; }
        public bool Enable { get; set; }
        public virtual string ProviderName { get; set; }
        public virtual string ProviderKey { get; set; }
    }
}