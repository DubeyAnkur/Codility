using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codility._2012
{
    class Omicron
    {
        public int solution(int N, int M)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            double big = N;
            for (int i = 1; i < M; i++)
            {
                big = (big * N) % 10000103;
            }
            int fab = Fabonacci(big);
            return fab;
        }

        public int Fabonacci(double f)
        {
            int n = Convert.ToInt32(f);
            double phi = (1 + Math.Sqrt(5)) / 2;
            double nphi = (1 - Math.Sqrt(5)) / 2;
            double fn = (Math.Pow(phi, n) - Math.Pow(nphi, n)) / Math.Sqrt(5);

            return Convert.ToInt32(fn % 10000103);
        }
    }
}
