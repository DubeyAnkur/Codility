using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codility.MS
{
    class LRU
    {
        public DLNode queStart;
        public int QueSize = 4;
        public Hashtable ht;

        public LRU()
        {
            ht = new Hashtable();
        }
        public void AddToCache(int A)
        {
            if (ht.Contains(A))
            {
                DLNode temp = (DLNode)ht[A];
                if (temp.Left != null)
                    temp.Left.Right = temp.Right;
                if (temp.Right != null)
                    temp.Right.Left = temp.Left;

                temp.Right = queStart;
                queStart.Left = temp;
                queStart = temp;
            }
            else
            {
                DLNode newNode = new MS.DLNode(A);
                if (queStart != null)
                {
                    queStart.Left = newNode;
                    newNode.Right = queStart;
                }
                queStart = newNode;
            }
            if (ht.Count > QueSize)
            {
                DLNode remove = queStart;
                while (remove.Right != null)
                    remove = remove.Right;

                remove.Left.Right = null;
                ht.Remove(remove.Value);
            }
            //Done
        }
    }
}
