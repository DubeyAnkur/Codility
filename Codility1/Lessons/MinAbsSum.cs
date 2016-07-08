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
            for(int i=0;i<A.Length;i++)
            {
                if (A[i] > 0)
                    sum = sum + A[i];
                else
                    sum = sum + A[i] * (-1);
            }
            int maxSum = Convert.ToInt32(Math.Ceiling((decimal)sum/2));

            bool[,] DP = new bool[maxSum+1,A.Length];

            for(int j=0;j<A.Length;j++)
            {
                DP[0,j] = true;
            }

            int temp = 0;
            for(int j=0;j<A.Length;j++)
            {

                if (A[j] > 0)
                    temp = A[j];
                else
                    temp = A[j] * (-1);

                for (int i = 0; i < maxSum + 1; i++)
                {
                    if(j>0)
                        DP[i,j] = DP[i,j - 1];

                    if (i + temp < maxSum)
                        DP[i + temp, j] = DP[i, j] || DP[i + temp,j];

                    if ((i + temp) == maxSum)
                        return maxSum - (sum/2);
                }
            }

            for (int i = maxSum; i >= 0; i--)
            {
                if (DP[i, A.Length - 1] == true)
                    return (sum/2) - i;
            }

            return 0;
        }
    }
}
