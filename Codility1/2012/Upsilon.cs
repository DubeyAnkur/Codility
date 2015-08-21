using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codility._2012
{
    class Upsilon
    {
        public int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            int height = 0;
            Node root = new Node(A[0], null);
            Node current = root;
            for (int i = 1; i < A.Length; i++)
            {
                Node newN;
                if (A[i] < current.val)
                {
                    Node temp = current.right;
                    newN = new Node(A[i], current);
                    newN.left = temp;
                    if (temp != null)
                        temp.parent = newN;
                    current.right = newN;
                }
                else //current.val < A[i] (they can not be equal)
                {
                    while (current != null && current.val < A[i])
                    {
                        current = current.parent;
                    }
                    newN = new Node(A[i], current);
                    if (current == null)
                    {
                        newN.left = root;
                        root.parent = newN;
                        root = newN;
                    }
                    else
                    {
                        newN.left = current.right;
                        newN.left.parent = newN;
                        current.right = newN;
                    }
                }
                current = newN;
            }

            height = findHeight(root);
            return height;
        }

        public class Node
        {
            public Node left;
            public Node right;
            public Node parent;
            public int val;
            public Node(int v, Node p)
            {
                val = v;
                parent = p;
            }
        }
        public int findHeight(Node N)
        {
            if (N == null)
                return 0;
            return Math.Max(findHeight(N.left), findHeight(N.right)) + 1;
        }
    }
}
