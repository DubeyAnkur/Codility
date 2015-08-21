using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codility._2013
{
    class Carbo
    {
        public int solution(string S)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            if (S.Length == 0)
                return 0;
            int result = 0;
            int N = S.Length;
            int[] Z = new int[S.Length];
            Z[0] = N;

            int lH = 1, r = 1;
            while (lH < N)
            {
                if (lH > r)
                    r = lH;
                while (r < N && S[r] == S[r - lH])
                    r++;
                Z[lH] = r - lH;
                int k = lH;
                k++;

                while (k < N && k <= r && k + Z[k - lH] < r)
                {
                    Z[k] = Z[k - lH];
                    k++;
                }
                lH = k;
            }
            int[] A = new int[S.Length + 1];
            for (int i = 0; i < Z.Length; i++ )
            {
                A[Z[i]] += 1;
            }
            for (int i = A.Length -2; i > 0 ; i--)
            {
                A[i] += A[i + 1];
            }
            for (int i = 0; i < A.Length; i++ )
            {
                if (result < i * A[i])
                    result = i*A[i];
            }
            if (result > 1000000000)
                result = 1000000000;

            return result;
        }
    }
}
