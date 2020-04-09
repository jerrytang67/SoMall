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
            public const string Default = GroupName + ".User";
            public const string Delete = Default + ".Delete";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
        }

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(MallPermissions));
        }
    }
}