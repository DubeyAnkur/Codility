using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codility
{
    class NailingPlanks
    {
        public int solution(int[] A, int[] B, int[] C)
        {
            // write your code in C# 5.0 with .NET 4.5 (Mono)
            int MaxM = 0;
            int Nailed = 0;
            for(int i=0;i<A.Length;i++)
            {
                for(int j=0;j<C.Length;j++)
                {
                    if (C[j] >= A[i] && C[j] <= B[i])
                    {
                        Nailed++;
                        if (MaxM < j)
                            MaxM = j;
                        break;
                    }
                    else if (j == C.Length - 1)
                        return -1;
                }
            }
            if (Nailed == A.Length)
                return MaxM + 1;
            else
                return -1;
        }
    }
}
