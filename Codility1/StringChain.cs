using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codility
{
    public class StringChain
    {
        public int Solution(string[] A)
        {
            int result = 1;

            A = CustomSort(A); //Step 1: Sort A by length of string in desc.

            for (int i = 0; i < A.Length; i++)
            {
                if (result < A[i].Length)
                    result = Math.Max(result, FindMaxChain(A, i, 1));
            }
            return result;
        }

        int FindMaxChain(string[] A, int i, int recDepth)
        {
            //int depth = 1;
            for (int j = i + 1; j < A.Length; j++)
            {
                //if (depth > A[i].Length)
                //    return depth;

                if (A[i].Length - 1 == A[j].Length)
                {
                    int match = EditDistance(A[i], A[j]);
                    if (match == A[j].Length)
                        return FindMaxChain(A, j, recDepth + 1); // Need to rec it properly...
                }
            }
            //return depth;
            return recDepth;

        }

        int EditDistance(string X, string Y)
        {
            int[,] DP = new int[X.Length, Y.Length];

            for (int i = 0; i < X.Length; i++)
            {
                for (int j = 0; j < Y.Length; j++)
                {
                    int max = 0;
                    if (i == 0 && j == 0)
                        max = 0;
                    else if (i == 0)
                        max = DP[i, j - 1];
                    else if (j == 0)
                        max = DP[i - 1, j];
                    else
                        max = Math.Max(DP[i - 1, j], DP[i, j - 1]);

                    if (X[i] == Y[j]) // Should it be X[j] == Y[i]. Need to debug
                        max = max + 1;

                    DP[i, j] = max;
                }
            }
            return DP[X.Length - 1, Y.Length - 1];
        }

        private class Mystr : IComparable<Mystr>
        {
            public string s;
            public int len;
            public Mystr(string ms, int l)
            {
                s = ms;
                len = l;
            }
            public int CompareTo(Mystr other)
            {
                //return len.CompareTo(other.len);
                return other.len.CompareTo(len); // will it reverse sort it ?
            }

        }

        string[] CustomSort(string[] A) //Bad way of doing it.
        {
            List<Mystr> myList = new List<Mystr>();
            for (int i = 0; i < A.Length; i++)
            {
                Mystr m = new Mystr(A[i], A[i].Length);
                myList.Add(m);
            }
            myList.Sort();
            string[] B = new string[A.Length];

            for (int i = 0; i < A.Length; i++)
            {
                B[i] = myList[i].s;
            }

            return B;
        }
    }
}
