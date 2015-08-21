using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codility._2011
{
    class Iota
    {
        public class Node
        {
            public int value;
            public int depth;
            public List<int> childs;

            public Node(int v, List<int> ch)
            {
                value = v;
                childs = ch;
            }
        }

        public int solution(int[] A)
        {
            // write your code in C# 5.0 with .NET 4.5 (Mono)
            int depth = A.Length;
            Hashtable ht  = new Hashtable();
            for (int i = 0; i < A.Length; i++ )
            {
                Node n;
                if (ht.ContainsKey(A[i]))
                    n = (Node)ht[A[i]];
                else
                {
                    n = new Node(A[i], new List<int>());
                    ht.Add(A[i], n);
                }

                if(i>0)
                    n.childs.Add(A[i-1]);
                if (i < A.Length-1)
                    n.childs.Add(A[i + 1]);
            }

            int lookUp = A[A.Length - 1];
            Queue<int> Q = new Queue<int>();

            int val = 0;
            Q.Enqueue(A[val]);
            ((Node)ht[A[val]]).depth = 1;

            while (Q.Any())
            {
                val = Q.Dequeue();
                if (ht.ContainsKey(val))
                {
                    Node n = (Node) ht[val];

                    if (n.value == lookUp)
                        return n.depth;
                    ht.Remove(val);

                    foreach (int j in n.childs)
                    {
                        if (ht.ContainsKey(j))
                        {
                            Node x = (Node) ht[j];
                            if (x.depth  == 0)
                                x.depth = n.depth + 1;
                            Q.Enqueue(j);
                            //ht.Remove(j);
                        }
                    }
                }
            }
            return depth;
        }

        public int solution2(int[] T, int[] D)
        {
            // write your code in C# 5.0 with .NET 4.5 (Mono)
            int maxT = 0;
            for (int i = 0; i < T.Length; i++)
            {
                if (maxT < T[i])
                    maxT = T[i];
            }
            int[] per = new int[maxT + 1];
            per[1] = 1;
            for (int i = 2; i <= maxT; i++)
            {
                double d = (double)i*per[i - 1];
                if (d > 1410000016)
                    d = d % 1410000017;
                per[i] = Convert.ToInt32(d);
            }
            double result = 1;
            for (int i = 0; i < T.Length; i++)
            {
                double d = per[T[i]];
                d = d/(per[D[i]]*per[T[i] - D[i]]);
                result = result*d;
                if (result > 1410000016)
                    result = result % 1410000017;
                
            }
            return Convert.ToInt32(result);
        }
    }
}
