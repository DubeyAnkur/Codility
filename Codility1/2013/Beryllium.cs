using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codility._2013
{
    class Beryllium
    {
        public int solution(int[] A)
        {
            int result = 0;
            int N = A.Length;
            int P = 0, Q = N - 1;
            Hashtable htP = new Hashtable();
            Hashtable htQ = new Hashtable();
            Hashtable htCom = new Hashtable();

            int[] B = new int[N];

            while (P < N)
            {
                if (!htCom.ContainsKey(A[P]))
                {
                    if (!htQ.ContainsKey(A[P]))
                    {
                        if (!htP.ContainsKey(A[P]))
                            htP.Add(A[P], 0);
                    }
                    else
                    {
                        htCom.Add(A[P], 0);
                        htQ.Remove(A[P]);

                        if (htP.Count == 0 && htQ.Count == 0)
                            B[P] = 1;
                    }
                }
                else
                {
                    if (htP.Count == 0 && htQ.Count == 0)
                        if (P > 0 && B[P - 1] > 0 && B[P] == 0)
                            B[P] = B[P - 1];
                        else
                            B[P] = B[P] + 1;
                }

                while (Q >= 0 && htQ.Count <= htP.Count)
                {
                    if (!htCom.ContainsKey(A[Q]))
                    {
                        if (!htP.ContainsKey(A[Q]))
                        {
                            if (!htQ.ContainsKey(A[Q]))
                                htQ.Add(A[Q], 0);
                        }
                        else
                        {
                            htCom.Add(A[Q], 0);
                            htP.Remove(A[Q]);

                            if (htP.Count == 0 && htQ.Count == 0)
                                B[P] = 1;
                        }
                    }
                    else
                    {
                        if (htP.Count == 0 && htQ.Count == 0)
                            if (P > 0 && B[P - 1] > 0 && B[P] == 0)
                                B[P] = B[P - 1];
                            else
                                B[P] = B[P] + 1;
                    }
                    Q--;
                }
                P++;
            }


            for (int i = 0; i < N; i++)
            {
                result += B[i];
                //Console.Write(B[i] + ",");
            }
            if (result > 1000000000)
                result = 1000000000;

            return result;
        }

        public bool EqualHTs(Hashtable ht1, Hashtable ht2)
        {
            return true;
        }
    }
}
