using System;
using System.Collections;
using System.Text;

namespace TT.HttpClient.Weixin.Signature
{
    public class ASCIISort : IComparer
    {
        /// <summary>创建新的ASCIISort实例</summary>
        /// <returns></returns>
        public static ASCIISort Create()
        {
            return new ASCIISort();
        }

        public int Compare(object x, object y)
        {
            byte[] bytes1 = Encoding.ASCII.GetBytes(x.ToString());
            byte[] bytes2 = Encoding.ASCII.GetBytes(y.ToString());
            int length1 = bytes1.Length;
            int length2 = bytes2.Length;
            int num1 = Math.Min(length1, length2);
            for (int index = 0; index < num1; ++index)
            {
                byte num2 = bytes1[index];
                byte num3 = bytes2[index];
                if ((int) num2 > (int) num3)
                    return 1;
                if ((int) num2 < (int) num3)
                    return -1;
            }

            if (length1 == length2)
                return 0;
            return length1 > length2 ? 1 : -1;
        }
    }
}