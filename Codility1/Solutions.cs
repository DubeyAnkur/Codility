using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Codility
{
    class Solutions
    {
        public int[] solution(int N, int[] P, int[] Q)
        {
            // write your code in C# 5.0 with .NET 4.5 (Mono)
            int[] primes = new int[N + 1];
            int[] results = new int[P.Length];
            int[] tempQ = new int[N + 1];
            int[] FakeQ = new int[N + 1];
            int[] OnlyP = new int[N];
            int op = 0;

            int sq = Convert.ToInt32(Math.Floor(Math.Sqrt(N)));

            Stopwatch w = new Stopwatch();
            w.Start();
            for (int i = 2; i <= sq; i++)
            {
                if (primes[i] == 0)
                {
                    int k = i * i;
                    while (k <= N)
                    {
                        if (primes[k] == 0)
                        {
                            primes[k] = 1;
                        }
                        k = k + i;
                    }
                }
            }
            Console.WriteLine(w.ElapsedMilliseconds);
            w.Stop();
            w.Start();
            for (int i = 2; i <= N; i++)
            {
                if (primes[i] == 0)
                {
                    OnlyP[op] = i;
                    op++;
                }
            }
            Console.WriteLine(w.ElapsedMilliseconds);
            w.Stop();
            w.Start();
            //for (int i = 2; i <= sq; i++)
            //{
            //    if (primes[i] == 0)
            //    {
            //        for (int j = i; j < N; j++)
            //        {
            //            if (primes[j] == 0 && (i*j)<=N)
            //            {
            //                tempQ[i*j] = 1;
            //            }
            //        }
            //    }
            //}
            for (int i = 0; i <= op; i++)
            {
                for (int j = i; j <= op; j++)
                {
                    double d = ((double)OnlyP[i]) * ((double)OnlyP[j]);
                    if (d <= N)
                    {
                        tempQ[OnlyP[i] * OnlyP[j]] = 1;
                    }
                }
            }
            for (int i = 1; i < tempQ.Length; i++)
            {
                FakeQ[i] = FakeQ[i - 1] + tempQ[i];
            }
            Console.WriteLine(w.ElapsedMilliseconds);
            w.Stop();
            w.Start();
            for (int i = 1; i < tempQ.Length; i++)
            {
                if (tempQ[i] ==1)
                    Factor(i);
            }
            //for (int i = 0; i < P.Length; i++)
            //{
            //    int rCount = 0;
            //    int k = P[i];
            //    while (k <= Q[i])
            //    {
            //        if (tempQ[k] == 1)
            //            rCount++;
            //        k++;
            //    }
            //    results[i] = rCount;
            //}
            for (int i = 0; i < P.Length; i++)
            {
                results[i] = FakeQ[Q[i]] - FakeQ[P[i]] + tempQ[P[i]];
            }
            Console.WriteLine(w.ElapsedMilliseconds);
            w.Stop();
            return results;
        }



        public void Factor(int number)
        {
            List<int> factors = new List<int>();
            int max = (int)Math.Sqrt(number);  //round down
            Console.Write(" Num : " + number + " ");
            for (int factor = 1; factor <= max; ++factor)
            { //test from 1 to the square root, or the int below it, inclusive.
                if (number % factor == 0)
                {
                    Console.Write("\t\t" + factor);
                    //factors.add(factor);
                    if (factor != number / factor)
                    { // Don't add the square root twice!  Thanks Jon
                        Console.Write("\t\t" + (number / factor));
                    }
                }
            }
            Console.WriteLine();
            //return factors;
        }
    }

}
