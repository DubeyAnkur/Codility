using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codility.MS
{

    public class LinkList
    {
        public LinkList Next;
        public LinkList Mad;
        public string Value;

        public LinkList(string val)
        {
            Value = val;
        }
    }
    public class Mad_Pointer
    {
        public LinkList Init()
        {
            LinkList A = new LinkList("A");
            LinkList B = new LinkList("B");
            LinkList C = new LinkList("C");
            LinkList D = new LinkList("D");

            A.Next = B;
            B.Next = C;
            C.Next = D;

            A.Mad = C;
            B.Mad = C;
            C.Mad = B;
            D.Mad = A;

            return A;
        }

        public LinkList Copy(LinkList root)
        {
            LinkList curr = root;
            LinkList newNode;

            while (curr != null)
            {
                LinkList A1 = new LinkList(curr.Value);
                A1.Next = curr.Next;
                curr.Next = A1;
                curr = A1.Next;
            }

            curr = root;

            while (curr != null)
            {
                curr.Next.Mad = curr.Mad;
                curr = curr.Next.Next;
            }

            newNode = root.Next;
            curr = root;
            LinkList temp;

            while (curr.Next != null)
            {
                temp = curr.Next;
                curr.Next = curr.Next.Next;
                curr = temp;
            }

            return newNode;
        }
    }
}
