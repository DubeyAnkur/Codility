using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codility._2014
{
    class Aluminium
    {
        public int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            int result = A[0];
            int N = A.Length;
            int[] left = new int[N];
            int[] right = new int[N];

            left[0] = Int32.MinValue;
            for (int i = 1; i < N; i++)
                left[i] = Math.Max(left[i - 1], A[i - 1]);

            right[N-1] = Int32.MinValue;
            for (int i = N - 2; i >= 0; i--)
                right[i] = Math.Max(right[i + 1], A[i + 1]);

            result = Navigate(A, left, right);
            Array.Reverse(A);

            left[0] = Int32.MinValue;
            for (int i = 1; i < N; i++)
                left[i] = Math.Max(left[i - 1], A[i - 1]);

            right[N - 1] = Int32.MinValue;
            for (int i = N - 2; i >= 0; i--)
                right[i] = Math.Max(right[i + 1], A[i + 1]);

            result = Math.Max(Navigate(A, left, right), result);

            return result;
        }

        public int Navigate(int[] A, int[] left, int[] right)
        {
            int result = A[0];
            int N = A.Length;

            int l = 0, r = 0, sum = 0, tempSum = 0, min = 0, max = Int32.MinValue;
            while (r < N)
            {
                min = Math.Min(Math.Min(min, A[r]), 0);
                max = Math.Max(left[l], right[r]);
                sum = sum + A[r];
                tempSum = sum + max - min;
                if (result < tempSum)
                    result = tempSum;
                r++;

                if (tempSum <= 0 || A[l] < 0)
                {
                    l = r;
                    sum = 0;
                    min = 0;
                }
            }
            return result;
        }

    }
}
