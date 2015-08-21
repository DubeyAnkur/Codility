using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codility._2012
{
    class Chi
    {
        public int[] solution(int[] A, int[] B)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            int rMax = 0;
            for (int i = 0; i < A.Length; i++)
            {
                if (rMax < A[i])
                    rMax = A[i];
            }
            int[] H = new int[rMax+1];
            rMax = 0;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] > rMax)
                {
                    H[A[i]] = i;
                    rMax = A[i];
                }
            }
            for (int i = H.Length - 1; i >= 0; i--)
            {
                if (H[i] == 0 && i > A[0])
                    H[i] = H[i + 1];
            }

            for(int i = 0; i<B.Length; i++)
            {
                if (B[i] > H.Length - 1)
                    continue; // Fly away.
                if (B[i] <= A[0])
                    continue; // Ricochets away.

                int landing = H[B[i]] - 1;
                A[landing]++;
                if (H[A[landing]] > landing)
                    H[A[landing]] = landing;
            }
            return A;
        }
    }
}
