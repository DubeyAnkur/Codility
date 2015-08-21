using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codility._2013
{
    class Nitrogenium
    {
        public Nitrogenium()
        {

        }

        public int[] solution1(int[] A, int[] B)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            int[] result = new int[B.Length];
            int N = A.Length;
            int maxVal = 0;

            for (int i = 0; i < N; i++)
            {
                if (maxVal < A[i])
                    maxVal = A[i];
            }

            int[] lMax = new int[maxVal + 2];
            int[] lMin = new int[maxVal + 2];

            int max = 0;
            int min = 0;

            while (max < N && min < N)
            {
                while (max + 1 < N && A[max] <= A[max + 1])
                    max++;
                if (min < N)
                {
                    lMax[A[max]] += 1;
                    min = max + 1;
                }
                while (min + 1 < N && A[min] >= A[min + 1])
                    min++;
                if (min < N)
                {
                    if (min < N- 1)
                        lMin[A[min]] += 1;
                    max = min + 1;
                }
            }
            lMin[0] = lMin[0] + 1;
            for (int i = 1; i < lMin.Length; i++)
            {
                lMin[i] = lMin[i - 1] + lMin[i] - lMax[i];
            }
            for (int i = 0; i < B.Length; i++)
            {
                if (B[i] > maxVal)
                    result[i] = 0;
                else
                    result[i] = lMin[B[i]];
            }
            return result;
        }

        public int[] solution(int[] A, int[] B)
        {
            int N = A.Length;
            Int32 M = B.Length;
            Int32 size = Math.Max(A.Max(), B.Max());
            int[] island = new int[size + 2];
            for (int i = 1; i < N; i++)
            {
                if (A[i - 1] > A[i])
                {
                    island[A[i - 1]] += 1;
                    island[A[i]] -= 1;
                }
            }
            island[A[N - 1]] += 1;
            for (int i = size; i >= 0; i--)
            {
                island[i] += island[i + 1];
            }
            int[] result = new int[M];
            for (int i = 0; i < M; i++)
                result[i] = island[B[i] + 1];

            return result;

        }


            //while (true)
            //{
            //    Random(A);
            //    Random(B);
            //    Print(A);
            //    Console.WriteLine("Start: ");


            //    int[] C = s.solution(A, B); //ababbabaababbababa
            //    int[] D = s.solution1(A, B); //ababbabaababbababa
            //    for (int i = 0; i < C.Length; i++)
            //    {
            //        if (C[i] != D[i])
            //        {
            //            Console.Read();
            //            Console.WriteLine("Found It...");
            //        }
            //    }
            //}
    }
}
