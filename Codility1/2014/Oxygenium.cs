using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codility._2014
{
    class Oxygenium
    {
        public int solution(int K, int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            int l = 0, r = 0;
            int min = 0, max = 0;
            int N = A.Length;
            int result = 0;
            int[] B = new int[N];
            while (l <= N -1 ) // move l and update B[l] along with it.
            {
                while (r < N) //Find r for which l.....r-1 has min & max which are within K. r is pointing to min/max which makes diff more than K.
                {
                    if (A[r] > A[max])
                        max = r;

                    if (A[r] < A[min])
                        min = r;

                    if (A[max] - A[min] > K)
                        break;
                    r++;
                }

                int temp = Math.Min(max, min);

                while (l <= temp) // Till first min/max we can move l
                {
                    B[l] = r - l;
                    l++;
                }

                // l.... min .... (max & r)
                // Now temp = l = min;

                if (max == temp && max < N) // Now that one of min/max is removed, we have to find a temporary one.
                {
                    max = Math.Min(l, N-1);
                    while (max < r && max < N-1 && A[max] - A[min] < K)
                        max++;
                }
                if (min == temp && min < N)
                {
                    min = Math.Min(l, N - 1);
                    while (min < r && min < N - 1 && A[max] - A[min] < K)
                        min++;
                }
            }

            for (int i = 0; i < N; i++)
            {
                result = result + B[i];
                Console.Write(B[i] + ",");
            }
            if (result > 1000000000)
                result = 1000000000;

            return result;
        }
    }
}
