using System;
using System.Collections;
using System.Text;

namespace TT.HttpClient.Weixin.Signature
{
    public class ASCIISort : IComparer
    {
        public int Compare(object x, object y)
        {
            var bytes1 = Encoding.ASCII.GetBytes(x.ToString());
            var bytes2 = Encoding.ASCII.GetBytes(y.ToString());
            var length1 = bytes1.Length;
            var length2 = bytes2.Length;
            var num1 = Math.Min(length1, length2);
            for (var index = 0; index < num1; ++index)
            {
                var num2 = bytes1[index];
                var num3 = bytes2[index];
                if (num2 > num3)
                    return 1;
                if (num2 < num3)
                    return -1;
            }

            if (length1 == length2)
                return 0;
            return length1 > length2 ? 1 : -1;
        }

        /// <summary>创建新的ASCIISort实例</summary>
        /// <returns></returns>
        public static ASCIISort Create()
        {
            return new ASCIISort();
        }
    }
}