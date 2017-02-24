using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codility.MS
{
    class BinarySearch
    {
        public int[] Init()
        {
            int[] A = new int[100];
            for (int i = 0; i < 100; i++)
            {
                A[i] = i;
            }
            return A;
        }

        public int Search(int[] A, int item)
        {
            int start = 0;
            int end = A.Length;
            int i;

            while (start != end)
            {
                i = (start + end) / 2;
                if (A[i] == item)
                    return i;

                if (A[i] < item)
                    start = i;
                else
                    end = i;
            }
            return -1;
        }
    }

}
