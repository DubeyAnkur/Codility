using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codility._2012
{
    class Pi
    {
        public int[] solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            int[] R = new int[A.Length];
            Stack<int> max = new Stack<int>();
            max.Push(0);
            for (int i = 0; i < A.Length; i++)
            {
                R[i] = Int32.MaxValue;
            }
            for (int i = 1; i < A.Length; i++)
            {
                if (A[max.Peek()] > A[i])
                {
                    R[i] = Math.Min(i - max.Peek(), R[i]);
                    max.Push(i);
                }
                else
                {
                    while (max.Count > 0 && A[max.Peek()] < A[i])
                    {
                        int temp = max.Pop();
                        R[temp] = Math.Min(i - temp, R[temp]);
                    }
                    max.Push(i);
                }
            }
            max = new Stack<int>();
            max.Push(A.Length - 1);
            for (int i = A.Length - 2; i >= 0; i--)
            {
                if (A[max.Peek()] > A[i])
                {
                    R[i] = Math.Min(max.Peek() - i, R[i]);
                    max.Push(i);
                }
                else
                {
                    while (max.Count > 0 && A[max.Peek()] < A[i])
                    {
                        int temp = max.Pop();
                        R[temp] = Math.Min(temp - i, R[temp]);
                    }
                    max.Push(i);
                }
            }

            for (int i = 0; i < A.Length; i++)
            {
                if (R[i] == Int32.MaxValue)
                    R[i] = 0;
            }
            return R;
        }
    }
}
