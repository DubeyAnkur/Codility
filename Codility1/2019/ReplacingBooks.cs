using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codility._2019
{
    class ReplacingBooks
    {
        public class KeepCount: IComparable
        {
            public int Value;
            public int Count;
            public KeepCount(int value, int count)
            {
                Value = value;
                Count = count;
            }

            public int CompareTo(object obj)
            {
                return ((KeepCount)obj).Count.CompareTo(this.Count); //Desc
            }
        }
        public int solution(int[] A, int K)
        {
            int maxLength = 1;
            int[] B = new int[A.Length];

            for (int i = 0; i < A.Length; i++)
            {
                B[i] = A[i];
            }

            Array.Sort(B);
            int start = int.MinValue;
            List<KeepCount> lst = new List<KeepCount>();

            int count = 0;
            for (int i = 0; i < B.Length; i++)
            {
                if (start != B[i])
                {
                    lst.Add(new KeepCount(start, count));
                    start = B[i];
                    count = 1;
                }
                else
                    count++;
            }
            lst.Add(new KeepCount(start, count));

            lst.Sort();

            foreach (var val in lst)
            {
                int value = val.Value;

                if (maxLength >= val.Count + K)
                    return maxLength;

                int i = 0, j = 0;
                int kTemp = K;

                while (j < A.Length)
                {
                    if (A[j] == value)
                    { j++; continue; }
                    else if (kTemp > 0)
                    { j++; kTemp--; continue; }

                    maxLength = Math.Max(maxLength, j - i);

                    while (kTemp == 0 && i < j)
                    {
                        if (A[i] != value)
                            kTemp++;
                        i++;
                    }
                    if (kTemp == 0 && j - i == 0)
                    { j++; i++; }
                }
                maxLength = Math.Max(maxLength, j - i);
            }

            return maxLength;
        }
    }
}
