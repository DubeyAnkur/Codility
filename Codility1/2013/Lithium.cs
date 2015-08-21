using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codility._2013
{
    class Lithium
    {
        public int solution(int[][] A, int P)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            for(int i = 0;i<A.Length; i++)
            {
                int[] B = A[i];
                Array.Sort(B);
                A[i] = B;
            }


            //Only for print:
            Console.WriteLine("Sorted: ");
            for (int i = 0; i < A.Length; i++)
            {
                int[] B = A[i];
                for (int j = 0; j < B.Length; j++)
                    Console.Write(B[j] + " ");
                Console.WriteLine();
            }


            for (int i = 0; i < A.Length; i++)
            {
                int K = A[i][0];
                for (int j = 0; j < A[0].Length; j++)
                {
                    A[i][j] = A[i][j] - K;
                }
            }

            //Only for print:
            Console.WriteLine("Rearranged: ");
            for (int i = 0; i < A.Length; i++)
            {
                int[] B = A[i];
                for (int j = 0; j < B.Length; j++)
                    Console.Write(B[j] + " ");
                Console.WriteLine();
            }

            string[] str = new string[A.Length];
            for (int i = 0; i < A.Length; i++)
            {
                string s = "";
                for (int j = 0; j < A[0].Length; j++)
                {
                    s = s + A[i][j] + ",";
                }
                str[i] = s;
            }
            Array.Sort(str);

            // Only for print:
            for (int i = 0; i < A.Length; i++)
            {
                Console.WriteLine(str[i]);
            }
            int result = 0;
            int pair = 0;

            for (int i = 1; i < A.Length; i++)
            {
                if (str[i] == str[i - 1])
                {
                    pair++;
                    result = result + pair;
                }
                else
                    pair = 0;
            }

            return result;
        }


        //A[0, 0] = 1; A[0, 1] = 2;
        //A[0, 0] = 2; A[0, 1] = 4;
        //A[0, 0] = 4; A[0, 1] = 3;
        //A[0, 0] = 2; A[0, 1] = 3;
        //A[0, 0] = 1; A[0, 1] = 3;

        //A[0] = new int[] { 1, 2 };
        //A[1] = new int[] { 2, 4 };
        //A[2] = new int[] { 4, 3 };
        //A[3] = new int[] { 2, 3 };
        //A[4] = new int[] { 1, 3 };
    }
}
