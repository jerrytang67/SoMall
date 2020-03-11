using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TT.Abp.ShopManagement.Domain
{
    public static class ShopConsts
    {
        public const int MaxNameLength = 64;

        public const int MaxShortNameLength = 16;

        public const int MaxCoverImageLength = 256;

        public static string DbTablePrefix = "SoMall_";

        public static string DbSchema = null;
    }
}
