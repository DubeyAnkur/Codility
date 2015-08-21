using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codility._2015
{
    class Argon
    {
        public int solution(int[] A)
        {
            int N = A.Length;
            int[] Ones = new int[N];
            int[] Zeros = new int[N];


            if (A[0] == 0)
                Zeros[0] = 1;
            else
                Ones[0] = 1;

            for(int i = 1; i<N; i++)
            {
                if (A[i] == 0)
                {
                    Zeros[i] = Zeros[i - 1] + 1;
                    Ones[i] = Ones[i - 1];
                }
                else
                {
                    Zeros[i] = Zeros[i - 1];
                    Ones[i] = Ones[i - 1] + 1;
                }
            }
            int totalOnes = Ones[N-1];
            int totalZeros = Zeros[N-1];

            int[] LM = new int[N];
            int[] RM = new int[N];

            if (A[N-1] == 1)
                RM[N - 1] = N-1;
            else
                RM[N - 1] = -1;


            for (int i = N-2; i >= 0; i--)
            {
                if (totalOnes - Ones[i] > totalZeros - Zeros[i])
                {
                    RM[i] = RM[i+1];
                }
            }


            return 0;        
        }
    }
}
