using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codility.MS
{
    public class DLNode
    {
        public int Value;
        public DLNode Left;
        public DLNode Right;
        public DLNode(int val)
        {
            Value = val;
        }
    }
    public class TreeToDL
    {
        public DLNode Inint()
        {
            DLNode A = new DLNode(10);
            DLNode B = new DLNode(12);
            DLNode C = new DLNode(15);
            DLNode D = new DLNode(25);
            DLNode E = new DLNode(30);
            DLNode F = new DLNode(36);

            A.Left = B;
            A.Right = C;
            B.Left = D;
            B.Right = E;
            C.Left = F;

            return A;
        }

        public DLNode DLLast;
        public void Convert(DLNode curr)
        {
            if (curr == null)
                return;
            Convert(curr.Left);

            if (DLLast == null)
                DLLast = curr;
            else
            {
                DLLast.Right = curr;
                curr.Left = DLLast;
                DLLast = curr;
            }
            Convert(curr.Right);
        }

        public DLNode Start(DLNode root)
        {
            Convert(root);
            DLNode temp = DLLast;
            while (temp.Left != null)
                temp = temp.Left;

            return temp;
        }
    }
}
