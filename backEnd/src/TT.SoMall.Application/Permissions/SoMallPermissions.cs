using System;

namespace TT.SoMall.Permissions
{
    public static class SoMallPermissions
    {
        public const string GroupName = "SoMall";

        //Add your own permission names. Example:
        //public const string MyPermission1 = GroupName + ".MyPermission1";

        public static string[] GetAll()
        {
            //Return an array of all permissions
            return Array.Empty<string>();
        }
    }
}