using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codility._2012
{
    class Rho
    {

        public int[] solution(int A)
        {
            int[] DP = new int[A+1];
            Queue<Node> LookUp = new Queue<Node>();

            Node root = new Node(1, null, 1);
            DP[1] = 1;
            for (int i = 2; i < A + 1; i++)
            {
                DP[i] = int.MaxValue;
            }

            LookUp.Enqueue(root);
            Node result = root;

            while (true)
            {
                Node temp = LookUp.Dequeue();
                if (temp.value == A)
                {
                    result = temp;
                    break;
                }
                if (temp.value <= A)
                {
                    Node Parent = temp.parent;
                    while (Parent != null)
                    {
                        int X = temp.value + Parent.value;
                        if (X <= A)
                        {
                            if (DP[X] > temp.height + 1)
                            {
                                LookUp.Enqueue(new Node(X, temp, temp.height + 1));
                                DP[X] = temp.height + 1;
                            }

                        }
                        Parent = Parent.parent;
                    }
                    if (temp.value * 2 <= A)
                    {
                        LookUp.Enqueue(new Node(temp.value*2, temp, temp.height + 1)); // Doubling value
                        DP[temp.value * 2] = temp.height + 1;
                    }
                }
            }

            Stack<Node> st = new Stack<Node>();
            st.Push(result);
            while (st.Peek() != null && st.Peek().parent != null)
            {
                st.Push(st.Peek().parent);
            }
            int k = 0;
            int[] res = new int[st.Count];
            while (st.Count > 0)
            {
                res[k] = st.Pop().value;
                k++;
            }
            return res;
        }
        
        private class Node
        {
            public int value;
            public Node parent;
            public int height;
            public Node(int val, Node par, int h)
            {
                value = val;
                parent = par;
                height = h;
            }
        }

        public int[] solution2(int A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            int[] DP = new int[A + 1];
            int[] I = new int[A + 1];
            int[] J = new int[A + 1];


            DP[1] = 1;
            for (int i = 2; i < A + 1; i++)
            {
                DP[i] = int.MaxValue;
            }
            for (int i = 1; i < A + 1; i++)
            {
                for (int j = i; j < A + 1; j++)
                {
                    if (i + j < A + 1)
                    {
                        if (DP[i + j] > DP[j] + 1) //(DP[i + j] > DP[j] + 1)
                        {
                            DP[i + j] = DP[j] + 1; // DP[J[j]] + DP[I[i]] + 1
                            I[i + j] = i;
                            J[i + j] = j;
                        }
                    }
                }
            }
            Stack<int> R = new Stack<int>();
            R.Push(A);
            int k = 0;
            while (R.Peek() > 1)
            {
                R.Push(J[R.Peek()]);
            }
            int[] res = new int[R.Count];
            while (R.Count > 0)
            {
                res[k] = R.Pop();
                k++;
            }

            return res;
        }
        public int[] solution1(int A)
        {
            Node[] LookUp = new Node[A + 1];

            Node root = new Node(1, null, 1);
            LookUp[1] = root;

            int j = 1;
            while (j <= A && LookUp[A] == null)
            {
                Node temp = LookUp[j];
                if (temp != null)
                {
                    Node Parent = temp.parent;
                    while (Parent != null)
                    {
                        int X = temp.value + Parent.value;
                        if (X <= A && LookUp[X] == null)
                        {
                            LookUp[X] = new Node(X, temp, temp.height+1);
                        }
                        Parent = Parent.parent;
                    }
                    if (temp.value * 2 < A)
                        LookUp[temp.value * 2] = new Node(temp.value * 2, temp, temp.height + 1); // Doubling value
                }
                j++;
            }

            Stack<Node> st = new Stack<Node>();
            st.Push(LookUp[A]);
            while (st.Peek() != null && st.Peek().parent != null)
            {
                st.Push(st.Peek().parent);
            }
            int k = 0;
            int[] res = new int[st.Count];
            while (st.Count > 0)
            {
                res[k] = st.Pop().value;
                k++;
            }
            return res;
        }
    }
}
