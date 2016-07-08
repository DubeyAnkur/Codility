using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codility
{
    class MaxNonoverlappingSegments
    {
        public int solutionA(int[] A, int[] B)
        {
            // write your code in C# 5.0 with .NET 4.5 (Mono)
            int result = 1;
            int LastEnd = B[0];
            for (int i = 1; i < A.Length; i++)
            {
                if (A[i] > LastEnd)
                {
                    result++;
                    LastEnd = B[i];
                }
                //if(B[i] >=A[i+1] && B[i] <= B[i+1])
                //{
                //    result--;
                //    //there is overlap
                //}
            }
            //return A.Length + result;
            return result;
        }
        public int solution(int K, int[] A)
        {
            // write your code in C# 5.0 with .NET 4.5 (Mono)
            int result = 0;
            int temp = 0;
            for (int i = 0; i < A.Length; i++)
            {
                temp = temp + A[i];
                if (temp >= K)
                {
                    result++;
                    temp = 0;
                }
            }
            return result;
        }
    }
}
