using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace TT.Abp.Mall.Domain.Products
{
    public class AppProductCategory : CreationAuditedEntity, IMultiTenant
    {
        private AppProductCategory()
        {
        }

        public AppProductCategory(string appName, Guid productCategoryId, Guid? tenantId)
        {
            AppName = appName;
            ProductCategoryId = productCategoryId;
            TenantId = tenantId;
        }

        public string AppName { get; protected set; }
        public Guid ProductCategoryId { get; protected set; }

        public virtual int Sort { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }

        public Guid? TenantId { get; protected set; }

        public override object[] GetKeys()
        {
            return new object[] {AppName, ProductCategoryId};
        }
    }
}