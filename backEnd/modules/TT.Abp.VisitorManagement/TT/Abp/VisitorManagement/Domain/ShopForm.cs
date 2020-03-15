using System;
using System.ComponentModel.DataAnnotations.Schema;
using TT.Abp.ShopManagement.Domain;
using Volo.Abp.Domain.Entities.Auditing;

namespace TT.Abp.VisitorManagement.Domain
{
    public class ShopForm : CreationAuditedEntity
    {
        public ShopForm(Guid fromId, Guid shopId)
        {
            ShopId = shopId;
            FromId = fromId;
        }

        public Guid FromId { get; protected set; }
        public Guid ShopId { get; protected set; }

        public override object[] GetKeys()
        {
            return new object[] {FromId, ShopId};
        }


        [ForeignKey("ShopId")] public virtual Shop Shop { get; set; }
        public virtual Form Form { get; set; }
    }
}