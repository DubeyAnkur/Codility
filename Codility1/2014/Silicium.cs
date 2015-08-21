using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codility._2014
{
    class Silicium
    {
        public int solution(int X, int Y, int K, int[] A, int[] B)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            int N = A.Length;
            int result = 0;
            int[] Hor = new int[N + 1];
            int[] Ver = new int[N + 1];
            
            Hor[0] = A[0];
            for (int i = 1; i < N; i++)
                Hor[i] = A[i] - A[i - 1];
            Hor[N] = X - A[N - 1];

            Ver[0] = B[0];
            for (int i = 1; i < N; i++)
                Ver[i] = B[i] - B[i - 1];
            Ver[N] = Y - B[N - 1];

            Array.Sort(Hor);
            Array.Sort(Ver);

            int begin = 0;
            int end = Hor[N] * Ver[N];
            int Max = (N + 1) * (N + 1);

            while (begin <= end)
            {
                int mid = (begin + end) / 2;
                int lower = FindCountLessThanMid(mid, Hor, Ver);
                if (lower > Max - K)
                    end = mid-1;
                else
                {
                    begin = mid + 1;
                    result = mid;
                }
            }
            return result;
        }
        public int FindCountLessThanMid(int mid, int[] Hor, int[] Ver)
        {
            int ret = 0;
            int j = Hor.Length;
            for (int i = 0; i < Hor.Length; i++)
            {
                while (j-1 >= 0 && Hor[i] * Ver[j-1] >= mid)
                    j = j - 1;
                ret = ret + j;
            }
            return ret;
        }
    }
}
