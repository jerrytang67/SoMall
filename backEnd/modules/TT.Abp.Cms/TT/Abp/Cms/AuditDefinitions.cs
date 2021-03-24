using TT.Abp.AuditManagement.Audits;
using TT.Abp.Cms.Localization;
using Volo.Abp;
using Volo.Abp.Localization;

namespace TT.Abp.Cms
{
    public class CmsAuditDefinitionProvider : AuditDefinitionProvider
    {
        public override void Define(IAuditDefinitionContext context)
        {
            context.Add(
                new AuditDefinition(CmsAudit.Test, L("Audit_Test")).WithProviders("G", "S", "T")
            );
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<CmsResource>(name);
        }
    }

    public static class CmsAudit
    {
        private const string GroupName = "Cms_";
        public const string Test = GroupName + "Test";
    }
}