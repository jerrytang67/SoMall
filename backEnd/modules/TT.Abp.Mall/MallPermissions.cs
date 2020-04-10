using TT.Abp.Mall.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.Reflection;

namespace TT.Abp.Mall
{
    public class MallPermissions
    {
        public const string GroupName = "Mall";

        public static class Addresses
        {
            public const string Default = GroupName + ".Address";
            public const string Delete = Default + ".Delete";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
        }

        public static class Users
        {
            public const string Default = GroupName + ".MallUser";
            public const string Delete = Default + ".Delete";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
        }

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(MallPermissions));
        }
    }

    public class MallPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var bloggingGroup = context.AddGroup(MallPermissions.GroupName, L("Permission:Mall"));

            var users = bloggingGroup.AddPermission(MallPermissions.Users.Default, L("Permission:MallUsers"));
            users.AddChild(MallPermissions.Users.Update, L("Permission:Edit"));
            users.AddChild(MallPermissions.Users.Delete, L("Permission:Delete"));
            users.AddChild(MallPermissions.Users.Create, L("Permission:Create"));

            var addresses = bloggingGroup.AddPermission(MallPermissions.Addresses.Default, L("Permission:Addresses"));
            addresses.AddChild(MallPermissions.Addresses.Update, L("Permission:Edit"));
            addresses.AddChild(MallPermissions.Addresses.Delete, L("Permission:Delete"));
            addresses.AddChild(MallPermissions.Addresses.Create, L("Permission:Create"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<MallResource>(name);
        }
    }
}