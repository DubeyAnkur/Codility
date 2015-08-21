using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codility._2012
{
    class Sigma
    {
        public int solution(int[] H)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            Stack<int> st = new Stack<int>();
            st.Push(H[0]);
            int result = 0;
            for(int i =1; i<H.Length; i++)
            {
                if(st.Peek() < H[i])
                    st.Push(H[i]);
                else if(st.Peek() > H[i])
                {
                    while (st.Count > 0 && st.Peek() > H[i] )
                    {
                        st.Pop();
                        result++;
                    }
                    if (st.Count == 0 || st.Peek() < H[i])
                        st.Push(H[i]);
                }
            }
            while (st.Count > 0)
            {
                st.Pop();
                result++;
            }
            return result;
        }
    }
}
