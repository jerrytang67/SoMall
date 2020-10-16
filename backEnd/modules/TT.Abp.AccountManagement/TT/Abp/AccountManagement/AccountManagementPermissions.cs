using TT.Abp.AccountManagement.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.Reflection;

namespace TT.Abp.AccountManagement
{
    public class AccountManagementPermissions
    {
        public const string GroupName = "AccountManagement";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(AccountManagementPermissions));
        }

        public static class RealNameInfos
        {
            public const string Default = GroupName + ".RealNameInfos";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
            public const string Update = Default + ".Update";
        }
    }

    public class MallPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var accountGroup = context.AddGroup(AccountManagementPermissions.GroupName, L("Permission:AccountManagement"));

            var realNameInfos = accountGroup.AddPermission(AccountManagementPermissions.RealNameInfos.Default, L("Permission:RealNameInfos"));
            realNameInfos.AddChild(AccountManagementPermissions.RealNameInfos.Update, L("Permission:Edit"));
            realNameInfos.AddChild(AccountManagementPermissions.RealNameInfos.Delete, L("Permission:Delete"));
            realNameInfos.AddChild(AccountManagementPermissions.RealNameInfos.Create, L("Permission:Create"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<AccountResource>(name);
        }
    }
}