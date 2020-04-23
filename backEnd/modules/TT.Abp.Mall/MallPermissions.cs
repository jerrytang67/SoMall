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

        public static class ProductOrders
        {
            public const string Default = GroupName + ".ProductOrder";
            public const string Delete = Default + ".Delete";
            public const string Update = Default + ".Update";
        }

        public static class Coupons
        {
            public const string Default = GroupName + ".Coupons";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
            public const string Update = Default + ".Update";
        }

        public static class RealNameInfos
        {
            public const string Default = GroupName + ".RealNameInfos";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
            public const string Update = Default + ".Update";
        }

        public static class PayOrders
        {
            public const string Default = GroupName + ".PayOrders";
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
            var mallGroup = context.AddGroup(MallPermissions.GroupName, L("Permission:Mall"));

            var users = mallGroup.AddPermission(MallPermissions.Users.Default, L("Permission:MallUsers"));
            users.AddChild(MallPermissions.Users.Update, L("Permission:Edit"));
            users.AddChild(MallPermissions.Users.Delete, L("Permission:Delete"));
            users.AddChild(MallPermissions.Users.Create, L("Permission:Create"));

            var addresses = mallGroup.AddPermission(MallPermissions.Addresses.Default, L("Permission:Addresses"));
            addresses.AddChild(MallPermissions.Addresses.Update, L("Permission:Edit"));
            addresses.AddChild(MallPermissions.Addresses.Delete, L("Permission:Delete"));
            addresses.AddChild(MallPermissions.Addresses.Create, L("Permission:Create"));

            var orders = mallGroup.AddPermission(MallPermissions.ProductOrders.Default, L("Permission:ProductOrders"));
            orders.AddChild(MallPermissions.ProductOrders.Update, L("Permission:Edit"));
            orders.AddChild(MallPermissions.ProductOrders.Delete, L("Permission:Delete"));

            var coupons = mallGroup.AddPermission(MallPermissions.Coupons.Default, L("Permission:Coupons"));
            coupons.AddChild(MallPermissions.Coupons.Update, L("Permission:Edit"));
            coupons.AddChild(MallPermissions.Coupons.Delete, L("Permission:Delete"));
            coupons.AddChild(MallPermissions.Coupons.Create, L("Permission:Create"));

            var realNameInfos = mallGroup.AddPermission(MallPermissions.RealNameInfos.Default, L("Permission:RealNameInfos"));
            realNameInfos.AddChild(MallPermissions.RealNameInfos.Update, L("Permission:Edit"));
            realNameInfos.AddChild(MallPermissions.RealNameInfos.Delete, L("Permission:Delete"));
            realNameInfos.AddChild(MallPermissions.RealNameInfos.Create, L("Permission:Create"));

            mallGroup.AddPermission(MallPermissions.PayOrders.Default, L("Permission:PayOrders"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<MallResource>(name);
        }
    }
}