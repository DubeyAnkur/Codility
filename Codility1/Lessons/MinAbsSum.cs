using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codility
{
    class MinAbsSum
    {
        public int solution(int[] A)
        {
            // write your code in C# 5.0 with .NET 4.5 (Mono)
            int sum = 0;
            if (A.Length > 5000)
            {
                Array.Sort(A);
                for (int i = 0; i < A.Length; i++)
                {
                    if (A[i] < 0)
                        A[i] = A[i] * (-1);
                }
            }
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] > 0)
                    sum = sum + A[i];
                else
                    sum = sum + A[i] * (-1);
            }
            int maxSum = Convert.ToInt32(Math.Ceiling((decimal)sum / 2));

            bool[,] DP = new bool[maxSum + 1, A.Length];

            for (int j = 0; j < A.Length; j++)
            {
                DP[0, j] = true;
            }

            int temp = 0;
            for (int j = 0; j < A.Length; j++)
            {

                if (A[j] > 0)
                    temp = A[j];
                else
                    temp = A[j] * (-1);

                for (int i = 0; i < maxSum + 1; i++)
                {
                    if (j > 0)
                        DP[i, j] = DP[i, j - 1];

                    if (i + temp < maxSum)
                        DP[i + temp, j] = DP[i, j] || DP[i + temp, j];

                    if ((i + temp) == maxSum)
                        return maxSum - (sum / 2);
                }
            }

            for (int i = maxSum; i >= 0; i--)
            {
                if (DP[i, A.Length - 1] == true)
                    return (sum / 2) - i;
            }

            return 0;
        }

        public int new_solution(int[] A)
        {
            int N = A.Length;
            int M = 0;
            for (int i = 0; i < N; i++)
            {
                A[i] = Math.Abs(A[i]);
                M = Math.Max(A[i], M);
            }
            int S = 0;
            for (int i = 0; i < N; i++)
                S = S + A[i];

            int[] count = new int[M + 1];
            for (int i = 0; i < N; i++)
            {
                count[A[i]] += 1;
            }
            int[] dp = new int[S + 1];
            for (int i = 0; i < S + 1; i++)
            { dp[i] = -1; }

            dp[0] = 0;

            for (int a = 1; a < M + 1; a++)
            {
                if (count[a] > 0)
                {
                    for (int j = 0; j < S; j++)
                    {
                        if (dp[j] >= 0)
                            dp[j] = count[a];
                        else if (j >= a && dp[j - a] > 0)
                            dp[j] = dp[j - a] - 1;
                    }
                }
            }
            int result = S;
            for (int i = 0; i < (S / 2 + 1); i++)
            {
                if (dp[i] >= 0)
                    result = Math.Min(result, S - 2 * i);
            }
            return result;
        }
    }
}
