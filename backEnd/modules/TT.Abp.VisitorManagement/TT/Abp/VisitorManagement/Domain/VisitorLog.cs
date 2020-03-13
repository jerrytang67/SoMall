using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
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

        [ForeignKey("FormId")] public virtual Form Form { get; set; }

        [ForeignKey("CredentialId")] public virtual Credential Credential { get; set; }

        public VisitorLog(Guid id, Guid? tenantId, Guid? shopId)
        {
            Id = id;
            TenantId = tenantId;
            ShopId = shopId;
        }

        public bool IsDeleted { get; set; }
        public Guid? TenantId { get; }

        public Guid? ShopId { get; set; }
    }

    public class FormItem : CreationAuditedEntity
    {
        public Guid FromId { get; }

        public Guid ItemId { get; }

        public FormItem(Guid fromId, Guid itemId)
        {
            ItemId = itemId;
            FromId = fromId;
        }

        public VisitorEnums.FormItemType Type { get; set; }

        public int Sort { get; set; }

        [NotNull] public string Key { get; set; }

        [NotNull] public string PlaceHolder { get; set; }

        public string DefaultValue { get; set; }

        public override object[] GetKeys()
        {
            return new object[] {FromId, ItemId};
        }
    }
}