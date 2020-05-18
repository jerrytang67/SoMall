using TT.Abp.AppManagement.Apps;
using TT.Abp.AuditManagement.Audits;
using TT.Abp.Mall.Localization;
using Volo.Abp.Localization;

namespace TT.Abp.Mall.Definitions
{
    public class MallAuditDefinitionProvider : AuditDefinitionProvider
    {
        public override void Define(IAuditDefinitionContext context)
        {
            context.Add(
                new AuditDefinition("Product_Refund", L("Audit_Product_Refund"))
            );

            context.Add(
                new AuditDefinition("Partner_Agree", L("Audit_Partner_Agree"))
            );
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<MallResource>(name);
        }
    }
}