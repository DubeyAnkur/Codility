using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codility
{
    class Peaks
    {
        public int solution(int[] A)
        {
            // write your code in C# 5.0 with .NET 4.5 (Mono)
            int[] peeks = new int[A.Length];
            int N = A.Length;
            for (int i = 1; i < N; i++)
            {
                //Console.WriteLine(i);
                if (i == N - 1)
                {
                    peeks[i] = peeks[i - 1];
                    break;
                }
                if (A[i] > A[i - 1] && A[i] > A[i + 1])
                    peeks[i] = peeks[i - 1] + 1;
                else
                    peeks[i] = peeks[i - 1];
            }
            //for (int i = 0; i < N; i++)
            //    Console.WriteLine(peeks[i]);

            if (peeks[N-1] == 0)
                return 0;

            int root = Convert.ToInt32(Math.Floor(Math.Sqrt(A.Length)));
            int result = 0;

            for (int i = 2; i <N; i++) // i=2 will never work But for k = N/2
            {
                if (N % i == 0)
                {
                    //i is one of the factor. Lets check if it is valid k.
                    bool valid = true;
                    int j = 0;
                    int internal_peeks = 0;
                    for (; j < N - 1; j += i)
                    {
                        int pj, pj1;
                        if (j == 0) pj = peeks[j];
                        else pj = peeks[j - 1];

                        if (j + i >= N) pj1 = peeks[j + i - 1];
                        else pj1 = peeks[j + i];

                        if (pj1 - pj == 0)
                        {
                            valid = false;
                            break;
                        }
                        internal_peeks = pj1 - pj;
                        if (internal_peeks == 0)
                            internal_peeks = pj1 - pj;

                        if (internal_peeks != (pj1 - pj))
                        {
                            valid = false;
                            break;
                        }
                        //else if (j + i >= N - 1) result++;
                    }
                    if (valid == true)
                    { return N / i; }

                }
            }
            return 1; // This should never be the case.
        }
    }
}
