using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codility.MS
{
    class LevelOrderTravers
    {
        public LevelOrderTravers()
        {
            tempR = new Queue<MS.DLNode>();
            tempL = new Queue<MS.DLNode>();
        }
        public DLNode Init()
        {
            DLNode A1 = new DLNode(1);
            DLNode A2 = new DLNode(2);
            DLNode A3 = new DLNode(3);
            DLNode A4 = new DLNode(4);
            DLNode A5 = new DLNode(5);
            DLNode A6 = new DLNode(6);
            DLNode A7 = new DLNode(7);

            A1.Left = A2;
            A1.Right = A3;
            A2.Left = A4;
            A2.Right = A5;
            A3.Left = A6;
            A3.Right = A7;

            return A1;
        }

        public Queue<DLNode> tempR;
        public Queue<DLNode> tempL;
        public void PrintTravers(bool direct)
        {
            Queue<DLNode> temp;
            Queue<DLNode> next;

            if (tempR.Count == 0 && tempL.Count == 0)
                return;

            if (direct)
            {
                temp = tempR;
                next = tempL;
            }
            else
            {
                temp = tempL;
                next = tempR;
            }

            while (temp.Count> 0)
            {
                DLNode root = temp.Dequeue();
                Console.Write(root.Value + " ");
                if (direct)
                {
                    if (root.Left !=null) next.Enqueue(root.Left);
                    if (root.Right != null) next.Enqueue(root.Right);
                }
                else
                {
                    if (root.Right != null) next.Enqueue(root.Right);
                    if (root.Left != null) next.Enqueue(root.Left);
                }
            }
            PrintTravers(!direct);
        }

        public void InOrder(DLNode root)
        {
            
            if (root.Left != null)
                InOrder(root.Left);
            
            if (root.Right != null)
                InOrder(root.Right);

            Console.Write(root.Value + " ");
        }

        public class vertex
        {
            List<vertex> childs;
            Hashtable edgeweight;
        }


        public void BFS(DLNode root)
        {
            Queue<DLNode> bfsQ = new Queue<DLNode>();
            bfsQ.Enqueue(root);

            while (bfsQ.Count > 0)
            {
                DLNode temp = bfsQ.Dequeue();
                Console.Write(temp.Value + " ");
                if (temp.Left !=null) bfsQ.Enqueue(temp.Left);
                if (temp.Right != null) bfsQ.Enqueue(temp.Right);
            }
        }

        public class KTNode<K, T> where K: IComparable<K>, new()
        {
            K kNode;
            T tNode;

            public KTNode()
            {
                kNode = default(K);
                tNode = default(T);
            }

            public void Fill(K _k, T _t)
            {
                kNode = _k;
                tNode = _t;
            }
        }

        public void TryingIt()
        {
            KTNode<int, string> f = new KTNode<int, string>();

        }
    }
}
