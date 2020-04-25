using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace TT.Extensions
{
    public static class SchemaExt
    {
        public static JArray GetSelection<T>(this IEnumerable<T> list, string type, string title, string labelFormat,
            string[] labelKeys, string valueKey, int? colspan = null, bool justEnum = true)
        {
            var selection = new JArray();
            foreach (var ct in list)
            {
                var args = new object[labelKeys.Length];
                for (var i = 0; i < labelKeys.Length; i++)
                {
                    if (labelKeys[i].IndexOf(".", StringComparison.Ordinal) > -1)
                    {
                        var a = typeof(T).GetProperty(labelKeys[i].Split('.')[0])?.GetValue(ct, null);
                        var _type = typeof(T).GetProperty(labelKeys[i].Split('.')[0])?.PropertyType;
                        var p2 = labelKeys[i].Split('.')[1];
                        var b = _type.GetProperty(p2).GetValue(a, null);
                        args[i] = b;
                    }
                    else
                    {
                        var label = typeof(T).GetProperty(labelKeys[i])?.GetValue(ct, null);
                        args[i] = label;
                    }
                }

                if (type == "string")
                {
                    selection.Add(new JObject
                    {
                        {"label", string.Format(labelFormat, args)},
                        {"value", typeof(T).GetProperty(valueKey)?.GetValue(ct, null).ToString()}
                    });
                }
                else
                {
                    //TODO:非str,先全转到int
                    selection.Add(new JObject
                    {
                        {"label", string.Format(labelFormat, args)},
                        {"value", Convert.ToInt32(typeof(T).GetProperty(valueKey)?.GetValue(ct, null))}
                    });
                }
            }

            return selection;
        }
    }
}