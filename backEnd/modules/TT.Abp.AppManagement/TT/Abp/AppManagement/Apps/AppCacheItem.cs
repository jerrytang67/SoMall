using System;
using System.Collections.Generic;
using Volo.Abp.MultiTenancy;

namespace TT.Abp.AppManagement.Apps
{
    [Serializable]
    [IgnoreMultiTenancy]
    public class AppCacheItem
    {
        public AppCacheItem()
        {
        }

        public AppCacheItem(Dictionary<string, string> value)
        {
            Value = value;
        }

        public Dictionary<string, string> Value { get; set; }

        public static string CalculateCacheKey(string name, string providerName, string providerKey)
        {
            return "pn:" + providerName + ",pk:" + providerKey + ",n:" + name;
        }
    }
}