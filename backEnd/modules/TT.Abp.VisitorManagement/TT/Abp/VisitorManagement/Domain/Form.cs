using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using TT.Abp.ShopManagement;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace TT.Abp.VisitorManagement.Domain
{
    public class Form : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        [NotNull] public string Title { get; internal set; }
        [NotNull] public string Description { get; internal set; }

        public VisitorEnums.FormTheme Theme { get; set; }

        public Form(Guid id, string title, string description, Guid? tenantId = null)
        {
            Id = id;
            Title = title;
            Description = description;
            TenantId = tenantId;
            FormItems = new Collection<FormItem>();
            VisitorLogs = new Collection<VisitorLog>();
            ShopForms = new Collection<ShopForm>();
        }

        public virtual Collection<FormItem> FormItems { get; set; }
        public virtual Collection<VisitorLog> VisitorLogs { get; set; }
        public Guid? TenantId { get; protected set; }

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

        public virtual void AddVisitorLog(Guid visitorLogId, Guid shopId)
        {
            VisitorLogs.Add(new VisitorLog(visitorLogId, Id, shopId, TenantId));
        }


        public virtual Collection<ShopForm> ShopForms { get; set; }
    }
}