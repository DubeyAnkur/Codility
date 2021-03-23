using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codility._2020
{
    class CoverBuildings
    {
        public int solution(int[] H)
        {
            int[] left = new int[H.Length];
            int[] right = new int[H.Length];

            int maxHeight = 0;
            for (int i = 0; i < H.Length; i++)
            {
                if (H[i] > maxHeight)
                    maxHeight = H[i];

                left[i] = maxHeight * (i + 1);
            }

            maxHeight = 0;
            for (int i = H.Length-1; i >=0 ; i--)
            {
                if (H[i] > maxHeight)
                    maxHeight = H[i];

                right[i] = maxHeight * (H.Length - i);
            }

            int minArea = 0;

            if (H.Length == 1)
                minArea = left[0];
            else
                minArea = int.MaxValue;

            for (int i = 0; i < H.Length-1; i++)
            {
                if (left[i] + right[i + 1] < minArea)
                    minArea = left[i] + right[i + 1];
            }
            return minArea;

        }
    }
}
