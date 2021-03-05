using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codility._2020
{
    class RectanglesStrip
    {
        public int solution(int[] A, int[] B)
        {
            Hashtable ht = new Hashtable();

            for (int i = 0; i < A.Length; i++)
            {
                if (ht.ContainsKey(A[i]))
                    ht[A[i]] = (int)ht[A[i]] + 1;
                else
                    ht[A[i]] = 1;

                if (A[i] != B[i])
                {
                    if (ht.ContainsKey(B[i]))
                        ht[B[i]] = (int)ht[B[i]] + 1;
                    else
                        ht[B[i]] = 1;
                }
            }

            int ret = 0;
            foreach (int val in ht.Values)
            {
                if (val > ret)
                    ret = val;
            }
            return ret;

        }
    }
}
