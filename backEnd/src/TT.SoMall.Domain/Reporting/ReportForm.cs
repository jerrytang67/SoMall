using System;
using Volo.Abp;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace TT.SoMall.Reporting
{
    public class ReportForm : FullAuditedEntity<Guid>, ISoftDelete, IMultiTenant
    {
        public string Name { get; set; }

        public Guid? TenantId { get; }
    }
}