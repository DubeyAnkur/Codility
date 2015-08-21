using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Codility._2013
{
    class Omega
    {
        public int solution(int[] A, int[] B)
        {
            int N = A.Length;
            int M = B.Length;
            for (int i = 1; i < N; i++)
            {
                A[i] = Math.Min(A[i], A[i - 1]);
            }

            int cur = N - 1;
            int result = 0;
            for (int i = 0; i < M; i++)
            {
                if (cur < 0)
                    break;
                while (cur >= 0 && B[i] > A[cur])
                    cur--;
                if (cur >= 0)
                {
                    result++;
                    cur--;
                }

            }

            return result;
        }
    }
}
