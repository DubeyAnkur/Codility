using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codility
{
    class CountTriangles
    {
        public int solution(int[] A)
        {
            // write your code in C# 5.0 with .NET 4.5 (Mono)
            int result =0;

            Array.Sort(A);

            for (int i = 0; i < A.Length - 2;i++ )
            {
                int z = 0;
                for(int j=i+1;j<A.Length-1;j++)
                {
                    while (z < A.Length && ((long)A[i] + (long)A[j]) > A[z])
                        z++;
                    result = result + z - j - 1;
                }
            }
            return result;
        }
    }
}
