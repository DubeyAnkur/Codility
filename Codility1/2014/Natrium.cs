using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codility._2014
{
    class Natrium
    {
        public int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            int result = 0;
            Stack<int> des = new Stack<int>();

            for (int i = 0; i < A.Length; i++)
            {
                if (i == 0 || A[i] < A[des.Peek()])
                    des.Push(i);
            }
            for (int i = A.Length - 1; i >= 0; i--)
            {
                //if (i == A.Length - 1 || A[i] > A[asc.peek()])
                //    asc.Push(i);
                while(des.Count > 0 && A[des.Peek()] <= A[i])
                {
                    result = Math.Max(result, i - des.Peek());
                    des.Pop();
                }
            }
            return result;
        }
    }
}
