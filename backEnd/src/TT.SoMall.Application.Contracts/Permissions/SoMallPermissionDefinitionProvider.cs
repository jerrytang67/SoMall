using TT.SoMall.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace TT.SoMall.Permissions
{
    public class SoMallPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(SoMallPermissions.GroupName);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(SoMallPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<SoMallResource>(name);
        }
    }
}
