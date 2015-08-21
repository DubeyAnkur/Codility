using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codility._2014
{
    class Sulphur
    {
        public int solution(int[] A, int[] B, int[] C)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            int N = A.Length;
            Thread[] ths = new Thread[N];

            for (int i = 0; i < N; i++)
            {
                Thread Curr = new Thread();
                ths[i] = Curr;
                Curr.Capacity = A[i] - B[i];
                if (A[i] < B[i])
                    return i;

                Thread prnt = null;
                if (C[i] > -1)
                    prnt = ths[C[i]];
                Curr.Parent = prnt;

                while (Curr.Parent != null)
                {
                    Curr = Curr.Parent;
                    Curr.Capacity -= B[i];
                    if (Curr.Capacity < 0)
                        return i;
                }
            }
            return N;
        }

        class Thread
        {
            public int Capacity;
            public Thread Parent;
        }
    }
}
