using System;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using TT.Abp.ShopManagement;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace TT.Abp.VisitorManagement.Domain
{
    public class Form : AuditedAggregateRoot<Guid>, ISoftDelete, IMultiTenant, IMayHaveShop
    {
        [NotNull] public string Title { get; internal set; }
        [NotNull] public string Description { get; internal set; }

        public Form(string title, string description, Guid? tenantId = null)
        {
            Title = title;
            Description = description;
            TenantId = tenantId;
            FormItems = new Collection<FormItem>();
            VisitorLogs = new Collection<VisitorLog>();
        }

        public virtual Collection<FormItem> FormItems { get; protected set; }
        public virtual Collection<VisitorLog> VisitorLogs { get; protected set; }
        
        public bool IsDeleted { get; set; }
        public Guid? TenantId { get; protected set; }
        public Guid? ShopId { get; set; }

        internal void SetTitle([NotNull] string title)
        {
            Title = Check.NotNullOrWhiteSpace(title, nameof(title), VisitorConsts.MaxTitleLength);
        }

        internal void SetDescription([NotNull] string description)
        {
            Description = description;
        }

        public virtual void AddFormItem(Guid itemId)
        {
            FormItems.Add(new FormItem(Id, itemId));
        }

        public virtual void AddVisitorLog(Guid visitorLogId)
        {
            VisitorLogs.Add(new VisitorLog(visitorLogId, TenantId, ShopId));
        }
    }
}