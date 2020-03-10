using System;
using Volo.Abp;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace TT.SoMall.Reporting
{
    public class ReportForm : Entity<Guid>, IAuditedObject<Guid>, ISoftDelete, IMultiTenant
    {
        public string Name { get; set; }


        public bool IsDeleted { get; set; }
        public Guid? TenantId { get; }
        public DateTime CreationTime { get; set; }
        public Guid? CreatorId { get; set; }
        public Guid Creator { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public Guid? LastModifierId { get; set; }
        public Guid LastModifier { get; set; }
    }
}