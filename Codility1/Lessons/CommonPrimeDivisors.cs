using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codility
{
    class CommonPrimeDivisors
    {
        public int solution1(int[] A, int[] B)
        {
            // write your code in C# 5.0 with .NET 4.5 (Mono)
            int result = 0;
            for (int i = 0; i < A.Length;i++)
            {
                int a = A[i];
                int b = B[i];
                int gcd = findMe(a,b, 1);

                //Console.WriteLine("A: " + a + " B: " + b + " C: " + gcd);
                if ((gcd % (a / gcd) == 0) && (gcd % (b / gcd) == 0))
                    result++;
            }
            return result;
        }

        public int findMe(int a, int b, int res)
        {
            if (a ==b)
                return res * a;
            if (a % 2 == 0 && b % 2 == 0)
                return findMe(a/2, b/2, 2 * res);
            else if(a%2 ==0)
                return findMe(a / 2, b, res);
            else if (b % 2 == 0)
                return findMe(a, b / 2, res);
            else if(a>b)
                return findMe(a - b, b, res);
            else
                return findMe(a, b - a, res);
        }

        //Some other solution to find Fabonacci numbers. May be.
        public int[] solution(int[] A, int[] B)
        {
            // write your code in C# 5.0 with .NET 4.5 (Mono)
            double phi = (1 + Math.Sqrt(5)) / 2;
            double nphi = (1 - Math.Sqrt(5)) / 2;
            int[] result = new int[A.Length];
            for (int i = 0; i < A.Length; i++)
            {
                int n = A[i];
                double fn = (Math.Pow(phi, n) - Math.Pow(nphi, n)) / Math.Sqrt(5);
                result[i] = Convert.ToInt32(fn % (Math.Pow(2, B[i])));
            }
            return result;
        }


        // Solution available in Java below:
        public int solution4(int[] A, int[] B)
        {
            // write your code in Java SE 8
            int Z = A.Length;
            int count = 0;
            for (int i = 0; i < Z; i++)
            {
                int a = A[i];
                int b = B[i];
                // we know that if two numbers have the same prime divisors then
                // the gcd of both numbers and the result of each number divided by
                // gcd must have the same prime divisors too.
                int gcdOfBoth = gcd(a, b);
                int divisorOfA = a / gcdOfBoth;
                int gcdOfA = gcd(gcdOfBoth, divisorOfA);
                while (gcdOfA != 1)
                {
                    divisorOfA /= gcdOfA;
                    gcdOfA = gcd(gcdOfBoth, divisorOfA);
                }
                int divisorOfB = b / gcdOfBoth;
                int gcdOfB = gcd(gcdOfBoth, divisorOfB);
                while (gcdOfB != 1)
                {
                    divisorOfB /= gcdOfB;
                    gcdOfB = gcd(gcdOfBoth, divisorOfB);
                }
                if (divisorOfA == 1 && divisorOfB == 1)
                    count++;
            }
            return count;
        }

        // calculate the greatest common divisor using non-recursively method
        public int gcd(int a, int b)
        {
            int temp;
            while (a % b != 0)
            {
                temp = b;
                b = a % b;
                a = temp;
            }
            return b;
        }
    }
}
