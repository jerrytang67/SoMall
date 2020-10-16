using System;
using JetBrains.Annotations;
using TT.Abp.Cms.Events.Locals;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace TT.Abp.Cms.Domain
{
    public class Category : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        // public Category()
        // {
        //     this.SetProperty("new", "123");
        // }

        [NotNull] public string Name { get; set; }

        public int Zan { get; protected set; }

        public Guid? TenantId { get; protected set; }

        public void AddZan()
        {
            Zan += 1;
            AddLocalEvent(new CategoryEventData(this));
        }

        // public override string ToString()
        // {
        //     return this.GetType().ToString();
        // }
    }

    public class CategoryEvent : CreationAuditedEntity<Guid>, IMultiTenant
    {
        public CategoryEventType EventType { get; set; }

        public Guid? TenantId { get; protected set; }
    }

    public enum CategoryEventType
    {
        Unknow = 0,
        Category = 1
    }
}