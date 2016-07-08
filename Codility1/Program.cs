using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Codility._2011;
using Codility._2012;
using Codility._2013;
using Codility._2014;
using Codility._2016;

namespace Codility
{
    class Program
    {
        static void Main(string[] args)
        {
            Peaks s = new Peaks();

            int[] A = new int[] { 1, 2, 3, 4, 3, 4, 1, 2, 3, 4, 6, 2 };
            int[] B = new int[] { 2, 2, 1, 1 };
            int[] C = new int[] { -1, 0, 1, -1 };

            Stopwatch w = new Stopwatch();
            w.Start();

            //Random(A);
            //Array.Sort(A);
            Print(A);
            Console.WriteLine("Start: ");

            int X = s.solution(A);
            Console.WriteLine("Result: " + X);
            double sec = w.ElapsedMilliseconds;
            w.Stop();
            Console.WriteLine("Total Time 1 (in ms):" + sec);
            Console.Read();
        }
        static void Random(int[] P)
        {
            int Min = -10;
            int Max = 10;

            Random R = new Random();
            for (int i = 0; i < P.Length; i++)
            {
                P[i] = R.Next(Min, Max);
            }
        }
        static void RandomData(int N, int[] P, int[] Q, int[] C)
        {
            int Min = 1;
            int Max = 1000000;

            Random R = new Random();
            for (int i = 0; i < P.Length; i++)
            {
                P[i] = R.Next(Min, Max);
                Q[i] = R.Next(Min, Max);
                C[i] = R.Next(Min, Max);
            }
        }
        static void Print(int[] A)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < A.Length; i++)
            {
                sb.Append(A[i] + ",");
            }
            Console.WriteLine(sb.ToString());
        }
        static void Ordered(int[] A, int Asc)
        {
            int x = -20;// 1000000000;
            if (Asc == 0)
            {
                for (int i = 0; i < A.Length; i++)
                {
                    A[i] = i + x;
                }
            }
            else if (Asc == 1)
            {
                int j = 0;
                for (int i = A.Length - 1; i >= 0; i--)
                {
                    A[j] = i + x;
                    j++;
                }
            }
            else
            {
                for (int i = 0; i < A.Length; i++)
                {
                    A[i] = x;
                }
            }
        }

        static string RandomString()
        {
            //var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            int max = 1000000; //1000000
            var chars = "ab";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, max)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            return result;
        }
        static void Random2D(int[][] A)
        {
            int Min = 1;
            int Max = 5;

            Random R = new Random();
            for (int i = 0; i < A.Length; i++)
            {
                int[] B = A[i];
                if (B == null)
                    B = new int[4];
                for (int j = 0; j < B.Length; j++)
                {
                    B[j] = R.Next(Min, Max);
                    Console.Write(B[j] + " ");
                }
                A[i] = B;
                Console.WriteLine();
            }
        }
    }
}
