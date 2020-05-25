using System;
using Newtonsoft.Json;

namespace TT.Extensions
{
    public static class JsonExt
    {
        public static T TryConvert<T>(this string input)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(input);
            }
            catch (Exception)
            {
                return default;
            }
        }
    }
}