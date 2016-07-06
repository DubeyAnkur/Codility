using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codility._2016
{
    class Scandium
    {
        public string solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            string ret = "NO SOLUTION";
            double sum = 0;
            int N = A.Length;
            if (N == 1)
            {
                if (A[0] % 2 == 1)
                    return ret;
                else
                    return "0,0";
            }

            for (int i = 0; i < A.Length; i++)
            {
                sum = sum + A[i];
            }
            if (sum % 2 == 0)
                return "0," + (N-1);
            else
            {
                if (A[0] % 2 == 1)
                    return "1," + (N - 1);
                else if (A[N - 1] % 2 == 1)
                    return "0," + (N - 2);
                else
                {
                    if (N == 3)
                        return ret;
                    else
                    {
                        if (A[N - 2] % 2 == 1)
                            return "1," + (N - 3);
                        else if (A[1] % 2 == 1)
                            return "2," + (N - 2);
                        else
                            return ret;
                    }
                }
            }
            //return ret;
        }
    }
}
