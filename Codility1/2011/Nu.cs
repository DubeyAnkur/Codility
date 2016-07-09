using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codility._2011
{
    class Nu
    {
        public int old_solution(int[] A, int[] B, int[] P, int[] Q, int[] R, int[] S)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            int[] K = new int[P.Length];
            for (int i = 0; i < P.Length; i++)
            {
                int u = Q[i] - P[i];
                int v = S[i] - R[i];
                int N = (u + v + 2) / 2;

                int[] AP = new int[u + 1];
                int[] BP = new int[v + 1];
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
            return K[K.Length / 2];
        }

        public int solution(int[] A, int[] B, int[] P, int[] Q, int[] R, int[] S)
        {
            int n = A.Length;
            int m = B.Length;
            int k = P.Length;
            int[] medx = new int[k];
            for (int i = 0; i < k; i++)
            {
                medx[i] = median(P[i], Q[i], R[i], S[i], A, B);
            }
            Array.Sort(medx);
            return medx[k / 2];
        }

        public int median(int p, int q, int r, int s, int[] A, int[] B)
        {
            int x = q - p + 1;
            int y = s - r + 1;
            int z = Math.Abs(x - y) / 2;
            if (x > y)
            {
                if (A[p + z] >= B[s])
                    return A[p + z];
                else if (A[q - z] <= B[r])
                    return A[q - z];
                else
                    return (med(p + z, q - z, r, s, A, B));
            }
            else
            {
                if (B[r + z] >= A[q])
                    return B[r + z];
                else if (B[s - z] <= A[p])
                    return B[s - z];
                else
                    return (med(p, q, r + z, s - z, A, B));
            }
        }

        public int med(int p, int q, int r, int s, int[] A, int[] B)
        {
            int x = q - p + 1;
            int y = s - r + 1;
            if (x + y <= 5)
            {
                int[] medi = new int[q + 1 + s + 1];

                int index = 0;
                for (int an = p; an < q + 1; an++)
                {
                    medi[index] = A[an];
                    index++;
                }
                for (int an = r; an < s + 1; an++)
                {
                    medi[index] = B[an];
                    index++;
                }
                //int[] medi = A.Skip(p).Take(q + 1).Concat(B.Skip(r).Take(s + 1)).ToArray();
                Array.Sort(medi);
                return medi[(x + y) / 2];
            }
            else {
                int d = (x + y) / 4;
                if (A[p + d] < B[s - d])
                    return (med(p + d, q, r, s - d, A, B));
                else
                    return (med(p, q - d, r + d, s, A, B));
            }
        }
    }
}
