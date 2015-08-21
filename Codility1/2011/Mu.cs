using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codility._2011
{
    class Mu
    {
        public int solution(string S)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            // Covert all below in decimal.
            int P = 1410000017;
            int Z = 0;
            int N = 0;
            int F = 0;
            int X = 0;
            for (int j = 0; j < S.Length; j++)
            {
                Int32.TryParse(S[j].ToString(), out X);
                F = (10 * F + N + P - Z * (9 - X)) % P;
                if (X == 0)
                    Z += 1;
                N = (10 * N + X) % P;
            }
            return ((1 + F) % P);
        }
    }
}
