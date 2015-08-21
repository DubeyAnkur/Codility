using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codility._2011
{
    class Nu
    {
        public int solution(int[] A, int[] B, int[] P, int[] Q, int[] R, int[] S)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            int[] K = new int[P.Length];
            for(int i=0;i<P.Length; i++)
            {
                int u = Q[i] - P[i];
                int v = S[i] - R[i];
                int N = (u + v + 2)/2;

                int[] AP = new int[u+1];
                int[] BP = new int[v+1];
                for (int k = 0; k <= u; k++)
                {
                    AP[k] = A[P[i] + k];
                }
                for (int k = 0; k <= v; k++)
                {
                    BP[k] = B[R[i] + k];
                }

                u = 0;
                v = 0;
                int j = 0;
                //int max = 0;
                while (j < N)
                {
                    if (AP[u] > BP[v])
                    {
                        if (v < BP.Length)
                            v++;
                        else
                            u++;
                    }
                    else
                    {
                        if (u < AP.Length)
                            u++;
                        else
                            v++;
                    }
                    j++;
                }
                if (v > BP.Length)
                    K[i] = AP[u];
                else if (u > AP.Length)
                    K[i] = BP[v];
                else
                {
                    K[i] = Math.Min(AP[u], BP[v]);
                }
            }

            Array.Sort(K);
            return K[K.Length/2];
        }
    }
}
