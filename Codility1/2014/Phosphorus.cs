using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Codility._2014
{
    class Phosphorus
    {
        public int solution(int[] A, int[] B, int[] C)
        {
            int N = A.Length;
            int result = 0;
            Node[] nArr = new Node[N + 1];

            int[] count = new int[N + 1];

            for (int i = 0; i < N; i++)
            {
                Node a = (Node)nArr[A[i]];
                Node b = (Node)nArr[B[i]];

                if (a == null)
                {
                    a = new Node(A[i]);
                    nArr[A[i]] = a;
                }

                if (b == null)
                {
                    b = new Node(B[i]);
                    nArr[B[i]] = b;
                }

                a.ch.Add(b);
                b.ch.Add(a);

                count[A[i]]++;
                count[B[i]]++;
            }

            int[] state = new int[N + 1]; //0 = Not Traversed, 1 = Open, 2 = Guard, 3 = closed, 4, escape route, 5 = Prison,
            for (int i = 0; i < C.Length; i++)
            {
                state[C[i]] = 5;
            }

            int[] Trav = new int[N + 1];
            int ind = 0;
            for (int i = 0; i < N + 1; i++) // Add all leaf nodes.
            {
                if (count[i] == 1) //  || count[i] == 0
                {
                    if (state[i] == 5)
                        return -1;
                    state[i] = 1;

                    Trav[ind] = i;
                    ind++;
                }
            }

            for (int i = 0; i < ind; i++)
            {
                int k = Trav[i];
                Node No = nArr[k];
                if (No.ch.Count == 0)
                    continue;
                Node next = No.ch[0];

                if (state[next.Value] == 0)
                {
                    if (state[k] == 2)
                        state[next.Value] = 3;
                    else if (state[k] == 5)
                        state[next.Value] = 4;
                    else
                        state[next.Value] = state[k];
                }
                if (state[next.Value] == 1 )
                {
                    if (state[k] == 5 || state[k] == 4)
                    {
                        result++;
                        state[next.Value] = 2;
                    }
                }
                // if (state[next.Value] == 2) Do nothing as Guard is already placed.
                if (state[next.Value] == 3)
                {
                    if (state[k] == 5 || state[k] == 4)
                        state[next.Value] = 4;
                    else if (state[k] == 1)
                        state[next.Value] = 1;
                }
                if (state[next.Value] == 4)
                {
                    if (state[k] == 1)
                    {
                        result++;
                        state[next.Value] = 2;
                    }
                }
                if (state[next.Value] == 5)
                { 
                    if (state[k] == 1)
                        result++;
                }

                next.ch.Remove(No);
                if (next.ch.Count == 1)
                {
                    Trav[ind] = next.Value;
                    ind++;
                }
            }
            return result;
        }

        class Node
        {
            public int Value;
            public List<Node> ch;

            public Node(int val)
            {
                Value = val;
                ch = new List<Node>();
            }
        }
    }
}
