using TT.Abp.Mall.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.Reflection;

namespace TT.Abp.Mall.Definitions
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

        public static class MallUsers
        {
            public const string Default = GroupName + ".MallUser";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
            public const string Update = Default + ".Update";
        }

        public static class Products
        {
            public const string Default = GroupName + ".Products";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
            public const string Update = Default + ".Update";
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

        public static class Swipers
        {
            public const string Default = GroupName + ".Swipers";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
            public const string Update = Default + ".Update";
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

            var users = mallGroup.AddPermission(MallPermissions.MallUsers.Default, L("Permission:MallUsers"));
            users.AddChild(MallPermissions.MallUsers.Update, L("Permission:Edit"));
            users.AddChild(MallPermissions.MallUsers.Delete, L("Permission:Delete"));
            users.AddChild(MallPermissions.MallUsers.Create, L("Permission:Create"));

            var addresses = mallGroup.AddPermission(MallPermissions.Addresses.Default, L("Permission:Addresses"));
            addresses.AddChild(MallPermissions.Addresses.Update, L("Permission:Edit"));
            addresses.AddChild(MallPermissions.Addresses.Delete, L("Permission:Delete"));
            addresses.AddChild(MallPermissions.Addresses.Create, L("Permission:Create"));


            var products = mallGroup.AddPermission(MallPermissions.Products.Default, L("Permission:Products"));
            products.AddChild(MallPermissions.Products.Update, L("Permission:Edit"));
            products.AddChild(MallPermissions.Products.Delete, L("Permission:Delete"));
            products.AddChild(MallPermissions.Products.Create, L("Permission:Create"));


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

            var swipers = mallGroup.AddPermission(MallPermissions.Swipers.Default, L("Permission:Swipers"));
            swipers.AddChild(MallPermissions.Swipers.Update, L("Permission:Edit"));
            swipers.AddChild(MallPermissions.Swipers.Delete, L("Permission:Delete"));
            swipers.AddChild(MallPermissions.Swipers.Create, L("Permission:Create"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<MallResource>(name);
        }
    }
}