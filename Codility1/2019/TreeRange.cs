using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codility._2019
{
    class TreeRange
    {
        class Node
        {
            public int Value;
            public List<Node> Childs;

            public Node(int value)
            {
                Value = value;
                Childs = new List<Node>();
            }
        }

        public int solution(int[] T)
        {
            int count = 0;
            Node[] AllNodes = new Node[T.Length];

            for (int i = 0; i < T.Length; i++)
            {
                Node temp1, temp2;

                if (AllNodes[i] == null)
                {
                    temp1 = new Node(i);
                    AllNodes[i] = temp1;
                }
                else
                    temp1 = AllNodes[i];

                if (AllNodes[T[i]] == null)
                {
                    temp2 = new Node(T[i]);
                    AllNodes[T[i]] = temp2;
                }
                else
                    temp2 = AllNodes[T[i]];
                if (temp1.Value != temp2.Value)
                {
                    //if(!temp1.Childs.Contains(temp2))
                        temp1.Childs.Add(temp2);
                    //if (!temp2.Childs.Contains(temp1))
                        temp2.Childs.Add(temp1);
                }
            }

            int[] min = new int[T.Length];
            int[] max = new int[T.Length];

            for (int i = 0; i < T.Length-1; i++)
            {
                List<Node> Path = new List<Node>();
                Path.Add(AllNodes[i]);
                if (RecurseDFS(AllNodes[i], i + 1, Path, i))
                {
                    min[i] = int.MaxValue;
                    max[i] = int.MinValue;

                    foreach (var ch in Path)
                    {
                        if (ch.Value < min[i])
                            min[i] = ch.Value;
                        if (ch.Value > max[i])
                            max[i] = ch.Value;
                    }
                }
            }

            //Main Count
            for (int i = 0; i < T.Length; i++)
            {
                int tempMax = int.MinValue;
                int tempMin = int.MaxValue;
                for (int j = i; j < T.Length; j++)
                {
                    if (i == j)
                        count++;
                    else
                    {
                        if (min[j - 1] >= i && max[j - 1] <= j && tempMax <=j && tempMin >= i) //min or max of [0] => 0 to 1; of [1] => 1 to 2.
                            count++;
                        else
                        {
                            if (tempMax < max[j - 1]) 
                                tempMax = max[j - 1];
                            if (tempMin > min[j - 1])
                                tempMin = min[j - 1];
                        }
                    }
                }
            }

            return count;
        }
        private bool RecurseDFS(Node current, int search, List<Node> Path, int Parent)
        {
            if (current.Value == search)
                return true;

            foreach(Node ch in current.Childs)
            {
                if (ch.Value != Parent)
                {
                    Path.Add(ch);
                    if (RecurseDFS(ch, search, Path, current.Value))
                        return true;
                }
            }

            Path.Remove(current);
            return false;
        }

    }
}
