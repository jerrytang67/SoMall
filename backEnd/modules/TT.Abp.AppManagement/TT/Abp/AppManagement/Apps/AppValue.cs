using System;
using Volo.Abp;

namespace TT.Abp.AppManagement.Apps
{
    [Serializable]
    public class AppValue : NameValue
    {
        public AppValue()
        {
        }

        public AppValue(string name, string value)
        {
            Name = name;
            Value = value;
        }
    }
}