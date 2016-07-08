using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codility
{
    class MinAbsSumOfTwo
    {
        public int solution(int[] A)
        {
            // write your code in C# 5.0 with .NET 4.5 (Mono)
            int result = int.MaxValue;
            Array.Sort(A);

            for (int i = 0; i < A.Length;i++)
            {
                int search = A[i]*(-1);
                int mid = 0;
                int begin = 0;
                int end = A.Length - 1;
                int close = 0;
                while(begin<end)
                {
                    mid = (begin + end)/2;
                    if (A[mid] > search)
                    {
                        end = mid - 1;
                        close = mid;
                    }
                    else if (A[mid] < search)
                    {
                        begin = mid + 1;
                        close = mid;
                    }
                    else return 0;
                }
                int left = close == 0 ? int.MaxValue : Convert.ToInt32(Math.Sqrt(Math.Pow((A[i] + A[close - 1]), 2)));
                int centre = Convert.ToInt32(Math.Sqrt(Math.Pow((A[i] + A[close]), 2)));
                int right = close == A.Length - 1 ? int.MaxValue : Convert.ToInt32(Math.Sqrt(Math.Pow((A[i] + A[close + 1]), 2)));
                
                int min = Math.Min(left, right);
                min = Math.Min(min, centre);
                if (result > min)
                    result = min;
            }
            return result;
        }
    }
}
