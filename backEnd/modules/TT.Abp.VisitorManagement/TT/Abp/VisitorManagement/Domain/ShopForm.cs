using System;
using System.ComponentModel.DataAnnotations.Schema;
using TT.Abp.ShopManagement.Domain;
using Volo.Abp.Domain.Entities.Auditing;

namespace TT.Abp.VisitorManagement.Domain
{
    public class ShopForm : CreationAuditedEntity
    {
        public ShopForm(Guid formId, Guid shopId)
        {
            ShopId = shopId;
            FormId = formId;
        }

        public Guid FormId { get; protected set; }
        public Guid ShopId { get; protected set; }

        public override object[] GetKeys()
        {
            return new object[] {FormId, ShopId};
        }


        [ForeignKey("ShopId")] public virtual VisitorShop VisitorShop { get; set; }

        [ForeignKey("FormId")] public virtual Form Form { get; set; }
    }
}