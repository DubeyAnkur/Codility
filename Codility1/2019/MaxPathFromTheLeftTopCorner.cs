using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codility._2019
{
    class MaxPathFromTheLeftTopCorner
    {
        class Node
        {
            public int i;
            public int j;
            public int level;
            public String parent = "";
            public Node(int _i, int _j, int _level, String _parent)
            {
                i = _i;
                j = _j;
                level = _level;
                parent = _parent;
            }
        }
        public String solution_1(int[,] A)
        {
            // write your code in Java SE 8
            int N = A.GetLength(0);
            int M = A.GetLength(1);

            List<Node> deQ = new List<Node>();

            deQ.Add(new Node(0, 0, 1, ""));
            Node inHand = deQ[0];

            while (deQ.Count > 0)
            {
                inHand = deQ[0];
                deQ.RemoveAt(0);

                while (deQ.Count > 0 && inHand.level == deQ[0].level)
                {
                    if (A[inHand.i, inHand.j] < A[deQ[0].i, deQ[0].j])
                    {
                        inHand = deQ[0];
                        deQ.RemoveAt(0);
                    }
                    else if (A[inHand.i, inHand.j] > A[deQ[0].i, deQ[0].j])
                    {
                        deQ.RemoveAt(0);
                    }
                    else
                        break;
                }

                int right = -1;
                int down = -1;

                if (inHand.j + 1 < M)
                    right = A[inHand.i, inHand.j + 1];
                if (inHand.i + 1 < N)
                    down = A[inHand.i + 1, inHand.j];

                if (right >= down && right != -1)
                {
                    deQ.Add(new Node(inHand.i, inHand.j + 1, inHand.level + 1, inHand.parent + (A[inHand.i, inHand.j])));
                }
                if (down >= right && down != -1)
                {
                    deQ.Add(new Node(inHand.i + 1, inHand.j, inHand.level + 1, inHand.parent + (A[inHand.i, inHand.j])));
                }
            }
            return inHand.parent + (A[inHand.i, inHand.j]);
        }


        public String solution(int[,] A)
        {
            // write your code in Java SE 8


            List<Node> lst1 = new List<Node>();
            List<Node> lst2 = new List<Node>();

            lst1.Add(new Node(0, 0, 1, ""));
            Node inHand = lst1[0];

            while (lst1.Count > 0 || lst2.Count > 0)
            {
                while (lst1.Count > 0)
                {
                    inHand = lst1[0];
                    lst1.RemoveAt(0);

                    ProcessNode(lst1, lst2, inHand, A);
                }
                while (lst2.Count > 0)
                {
                    inHand = lst2[0];
                    lst2.RemoveAt(0);

                    ProcessNode(lst2, lst1, inHand, A);
                }
            }
            return inHand.parent + (A[inHand.i, inHand.j]);
        }

        void ProcessNode(List<Node> lst1, List<Node> lst2, Node inHand, int[,] A)
        {
            int right = -1;
            int down = -1;

            int N = A.GetLength(0);
            int M = A.GetLength(1);

            if (inHand.j + 1 < M)
                right = A[inHand.i, inHand.j + 1];
            if (inHand.i + 1 < N)
                down = A[inHand.i + 1, inHand.j];

            if (right >= down && right != -1)
            {
                if (lst2.Count > 0)
                {
                    if (A[inHand.i, inHand.j] > A[lst2[0].i, lst2[0].j])
                    {
                        lst2.RemoveAll(i => i.i > -1);
                        lst2.Add(new Node(inHand.i + 1, inHand.j, inHand.level + 1, inHand.parent + (A[inHand.i, inHand.j])));
                    }
                    else if (A[inHand.i, inHand.j] == A[lst2[0].i, lst2[0].j] && (inHand.i != lst2[lst2.Count - 1].i || inHand.j != lst2[lst2.Count - 1].j))
                        lst2.Add(new Node(inHand.i, inHand.j + 1, inHand.level + 1, inHand.parent + (A[inHand.i, inHand.j])));
                }
                else
                    lst2.Add(new Node(inHand.i, inHand.j + 1, inHand.level + 1, inHand.parent + (A[inHand.i, inHand.j])));
            }
            if (down >= right && down != -1)
            {
                if (lst2.Count > 0)
                {
                    if (A[inHand.i, inHand.j] > A[lst2[0].i, lst2[0].j])
                    {
                        lst2.RemoveAll(i => i.i > -1);
                        lst2.Add(new Node(inHand.i + 1, inHand.j, inHand.level + 1, inHand.parent + (A[inHand.i, inHand.j])));
                    }
                    else if (A[inHand.i, inHand.j] == A[lst2[0].i, lst2[0].j] && (inHand.i != lst2[lst2.Count - 1].i || inHand.j != lst2[lst2.Count - 1].j))
                        lst2.Add(new Node(inHand.i + 1, inHand.j, inHand.level + 1, inHand.parent + (A[inHand.i, inHand.j])));
                }
                else
                    lst2.Add(new Node(inHand.i + 1, inHand.j, inHand.level + 1, inHand.parent + (A[inHand.i, inHand.j])));
            }
        }
    }
}
