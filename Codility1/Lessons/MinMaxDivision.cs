using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codility
{
    class MinMaxDivision
    {
        public int solution(int K, int M, int[] A)
        {
            // write your code in C# 5.0 with .NET 4.5 (Mono)
            int begin = -1;
            int end = -1;
            //int result = -1;
            int max = int.MinValue;
            int sum = 0;
            int mid = 0;
            for (int i = 0; i < A.Length; i++)
            {
                sum += A[i];
                if (max < A[i])
                    max = A[i];
            }
            begin = Math.Max(Convert.ToInt32(Math.Floor((decimal) sum/K)), max);
            end = sum;
            int result = 0;

            while(begin<=end)
            {
                mid = (begin + end)/2;
                if(Check(A,mid) <=K)
                {
                    result = mid;
                    end = mid - 1;
                }
                else
                {
                    begin = mid + 1;
                }
            }
            return result;
        }

        public int Check(int[] A, int mid)
        {
            int sum = 0;
            int result = 1;
            for(int i=0;i<A.Length;i++)
            {
                if(mid >= sum + A[i])
                    sum = sum + A[i];
                else
                {
                    sum = A[i];
                    result++;
                }
            }
            return result;
        }
    }
}
