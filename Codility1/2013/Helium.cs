using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codility._2013
{
    class Helium
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

            int lH = 1, r= 1;
            while(lH < N)
            {
                if (lH > r)
                    r = lH;
                while (r < N && S[r] == S[r - lH])
                    r++;
                Z[lH] = r-lH;
                int k = lH;
                k++;

                while (k<N && k <= r && k + Z[k - lH] < r)
                {
                    Z[k] = Z[k - lH];
                    k++;
                }
                lH = k;
            }

            int rZ = N - 1;
            int lZ = N- 1;
            while (result < N / 3 && rZ >= N / 3)
            {
                while (Z[rZ] == 0 || Z[rZ] + rZ != N)
                    rZ--;
                int temp = N - rZ;

                lZ = Math.Min(rZ*2 - N, lZ);
                while (lZ > 0 && Z[lZ] < temp)
                    lZ--;
                if (lZ > 0 && Z[lZ] >= temp && lZ + temp <= rZ && lZ - temp >= 0)
                {
                    result = temp;
                }
                rZ--;
            }

            return result;
        }
    }
}
