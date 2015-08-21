using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Codility
{
    class HR
    {
        public int palindromeSubStrs(string str)
        {
            Dictionary<string, int> m = new Dictionary<string, int>();

            int n = str.Length;

            int[,] R = new int[2, n + 1];

            str = "@" + str + "#";

            for (int j = 0; j <= 1; j++)
            {
                int rp = 0;
                R[j, 0] = 0;

                int i = 1;
                while (i <= n)
                {
                    while (str[i - rp - 1] == str[i + j + rp])
                        rp++;  

                    R[j, i] = rp;
                    int k = 1;
                    while ((R[j, i - k] != rp - k) && (k < rp))
                    {
                        R[j, i + k] = Math.Min(R[j, i - k], rp - k);
                        k++;
                    }
                    rp = Math.Max(rp - k, 0);
                    i += k;
                }
            }

            str = str.Substring(1, n);

            m[str[0].ToString()] = 1;
            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j <= 1; j++)
                    for (int rp = R[j, i]; rp > 0; rp--)
                        m[str.Substring(i - rp - 1, 2 * rp + j)] = 1;
                m[str[i].ToString()] = 1;
            }

            return m.Count;
        }
    }
}
