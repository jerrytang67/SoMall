using System;
using System.ComponentModel.DataAnnotations.Schema;
using TT.Abp.Mall.Domain.Products;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace TT.Abp.Mall.Domain.Partners
{
    public class PartnerProduct : CreationAuditedEntity, IMultiTenant
    {
        public Guid PartnerId { get; set; }
        public Guid SpuId { get; set; }

        public int Count { get; set; } = 0;

        public decimal? Price { get; set; }

        public int State { get; set; } = 1; //0禁用 1启用 2置顶

        [ForeignKey("PartnerId")] public virtual Partner Partner { get; set; }

        [ForeignKey("SpuId")] public virtual ProductSpu ProductSpu { get; set; }

        public Guid? TenantId { get; protected set; }

        public override object[] GetKeys()
        {
            return new object[] {PartnerId, SpuId};
        }
    }
}