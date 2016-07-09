using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codility
{
    class NailingPlanks
    {
        public int solution(int[] A, int[] B, int[] C)
        {
            // write your code in C# 5.0 with .NET 4.5 (Mono)
            int MaxM = 0;
            int Nailed = 0;
            for(int i=0;i<A.Length;i++)
            {
                for(int j=0;j<C.Length;j++)
                {
                    if (C[j] >= A[i] && C[j] <= B[i])
                    {
                        Nailed++;
                        if (MaxM < j)
                            MaxM = j;
                        break;
                    }
                    else if (j == C.Length - 1)
                        return -1;
                }
            }
            if (Nailed == A.Length)
                return MaxM + 1;
            else
                return -1;
        }


        //1. Sort the nails by there position.
        //2. Find the nail which can go inside the plant and has smallest index in sorted array.
        //3. Then get all the nails which can go inside plan by movind up in sorted array.
        //4. For all the nails which can go inside this plant. The one with minimum original index (before sort). Thats the one we need. 


        //Better Solution in Java
        public int solution4(int[] A, int[] B, int[] C)
        {
            // write your code in Java SE 8
            // the main algorithm is that getting the minimal index of nails which
            // is needed to nail every plank by using the binary search
            int N = A.Length;
            int M = C.Length;
            // two dimension array to save the original index of array C
            //int[][] sortedNail = new int[M][2]; // Works in Java
            int[,] sortedNail = new int[M,2];
            for (int i = 0; i < M; i++)
            {
                sortedNail[i,0] = C[i];
                sortedNail[i,1] = i;
            }
            // use the lambda expression to sort two dimension array
            //Array.Sort(sortedNail, (int x[], int y[])->x[0] - y[0]);
            Sort<Array>(sortedNail, 0);
            int result = 0;
            for (int i = 0; i < N; i++)
            {
                result = getMinIndex(A[i], B[i], sortedNail, result);
                if (result == -1)
                    return -1;
            }
            return result + 1;
        }
        // for each plank , we can use binary search to get the minimal index of the
        // sorted array of nails, and we should check the candidate nails to get the
        // minimal index of the original array of nails.
        public int getMinIndex(int startPlank, int endPlank, int[,] nail, int preIndex)
        {
            int min = 0;
            int max = nail.Length - 1;
            int minIndex = -1;
            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (nail[mid,0] < startPlank)
                    min = mid + 1;
                else if (nail[mid,0] > endPlank)
                    max = mid - 1;
                else {
                    max = mid - 1;
                    minIndex = mid;
                }
            }
            if (minIndex == -1)
                return -1;
            int minIndexOrigin = nail[minIndex,1];
            // this check is to get the minimal index of the original array of nails
            for (int i = minIndex; i < nail.Length; i++)
            {
                if (nail[i,0] > endPlank)
                    break;
                minIndexOrigin = Math.Min(minIndexOrigin, nail[i,1]);
                // we need the maximal index of nails to nail every plank, so the
                // smaller index can be omitted
                if (minIndexOrigin <= preIndex)
                    return preIndex;
            }
            return minIndexOrigin;
        }

        private static void Sort<T>(int[,] data, int col)
        {
            throw new NotImplementedException();

            //Comparer<int> comparer = Comparer<int>.Default;
            //Array.Sort<int[]>(data, (x, y) => comparer.Compare(x[col], y[col]));
        }
    }
}
