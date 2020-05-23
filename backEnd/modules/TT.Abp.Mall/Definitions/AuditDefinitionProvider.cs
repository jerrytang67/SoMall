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
                new AuditDefinition(MallManagementAudit.ProductRefund, L("Audit_Product_Refund")).WithProviders("G", "S", "T")
            );

            context.Add(
                new AuditDefinition(MallManagementAudit.PartnerAgree, L("Audit_Partner_Agree")).WithProviders("G", "S", "T")
            );
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<MallResource>(name);
        }
    }

    public static class MallManagementAudit
    {
        private const string GroupName = "Mall_";
        public const string ProductRefund = GroupName + "Product_Refund";
        public const string PartnerAgree = GroupName + "Partner_Agree";
    }
}