using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace TT.Abp.Mall.Domain.Products
{
    public class AppProductSpu : CreationAuditedEntity, IMultiTenant
    {
        private AppProductSpu()
        {
        }


        public AppProductSpu(string appName, Guid productSpuId, Guid? tenantId)
        {
            AppName = appName;
            ProductSpuId = productSpuId;
            TenantId = tenantId;
        }

        public virtual string AppName { get; protected set; }

        public virtual Guid ProductSpuId { get; set; }

        public override object[] GetKeys()
        {
            return new object[] {AppName, ProductSpuId};
        }

        public virtual Guid? TenantId { get; protected set; }

        public virtual ProductSpu ProductSpu { get; set; }
    }
}