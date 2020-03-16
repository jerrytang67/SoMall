using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using TT.Abp.ShopManagement;
using Volo.Abp;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace TT.Abp.VisitorManagement.Domain
{
    // 访客记录
    public class VisitorLog : AuditedAggregateRoot<Guid>, ISoftDelete, IMultiTenant, IMayHaveShop
    {
        public Guid FormId { get; set; }

        public string FormJson { get; set; }

        public Guid? CredentialId { get; set; }

        [ForeignKey("FormId")]
        public virtual Form Form { get; set; }

        public virtual Credential Credential { get; set; }

        public VisitorLog(Guid id, Guid? tenantId, Guid? shopId)
        {
            Id = id;
            TenantId = tenantId;
            ShopId = shopId;
        }

        public bool IsDeleted { get; set; }
        public Guid? TenantId { get; protected set; }
        public Guid? ShopId { get; set; }
    }
}