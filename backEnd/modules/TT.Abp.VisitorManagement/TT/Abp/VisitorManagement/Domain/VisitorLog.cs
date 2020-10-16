using System;
using System.ComponentModel.DataAnnotations.Schema;
using TT.Abp.Shops;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace TT.Abp.VisitorManagement.Domain
{
    // 访客记录
    public class VisitorLog : FullAuditedAggregateRoot<Guid>, IMultiTenant, IMayHaveShop
    {
        public VisitorLog(Guid id, Guid formId, Guid? shopId, Guid? tenantId = null)
        {
            Id = id;
            FormId = formId;
            TenantId = tenantId;
            ShopId = shopId;
        }

        public string FormJson { get; set; }

        public Guid? CredentialId { get; set; }

        [ForeignKey("FormId")] public virtual Form Form { get; set; }

        public virtual Credential Credential { get; set; }

        public Guid FormId { get; protected set; }

        public double? Lat { get; set; }
        public double? Lng { get; set; }
        public DateTimeOffset? LeaveTime { get; set; }

        public Guid? ShopId { get; set; }

        public Guid? TenantId { get; protected set; }
    }
}