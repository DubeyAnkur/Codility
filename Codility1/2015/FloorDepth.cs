using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codility._2015
{
    class FloorDepth
    {
        public int solution(int[] A)
        {
            int maxDepth = 0;

            int localMinIndex = 0;
            int i = 0, j = 0;
            while (j < A.Length)
            {
                if (A[j] < A[localMinIndex])
                {
                    localMinIndex = j;
                }
                else if (A[i] < A[j])
                {
                    maxDepth = Math.Max(maxDepth, A[i] - A[localMinIndex]);
                    i = j;
                    localMinIndex = j;
                }
                else if (A[i] >= A[j])
                {
                    if(localMinIndex < j)
                        maxDepth = Math.Max(maxDepth, A[j] - A[localMinIndex]);
                }

                j++;
            }

            return maxDepth;
        }
    }
}
