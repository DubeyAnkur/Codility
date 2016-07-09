using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codility
{
    class NumberSolitaire
    {
        public int solution(int[] A)
        {
            // write your code in C# 5.0 with .NET 4.5 (Mono)
            int TotalResult = A[0];
            int value = 0;
            int counter = 0;

            int[] DP = new int[6];

            for (int i = 1; i < A.Length; i++ )
            {
                if (A[i] >= 0 || i==A.Length-1)
                {
                    if(value !=0)
                    {
                        int max = -10001;
                        for(int j = 0;j<6; j++)
                        {
                            if(max<DP[j])
                                max = DP[j];
                        }
                        value = 0;
                        TotalResult = TotalResult + A[i] + max;
                    }
                    else
                    {
                        TotalResult = TotalResult + A[i];   
                    }
                    counter = 0;
                    DP = new int[6];
                }
                else
                {
                    if(counter<5)
                        DP[counter] = A[i];
                    else if(counter==5)
                    {
                        DP[counter] = A[i];
                        value = A[i];
                    }
                    else
                    {
                        int max = -10001;
                        for(int j = 0;j<6; j++)
                        {
                            if(max<DP[j])
                                max = DP[j];
                        }
                        DP[counter%6] = max + A[i];
                        value = max;
                    }
                }
                counter++;
            }
            return TotalResult;
        }
        public int solution2(int[] A)
        {
            // write your code in C# 5.0 with .NET 4.5 (Mono)
            int TotalResult = A[0];
            int value = 0;
            int counter = 0;
            int[] DP = new int[6];

            for (int i = 1; i < A.Length; i++)
            {
                if (A[i] >= 0 || i == A.Length - 1)
                {
                    if (value != 0)
                    {
                        int max = -10001;
                        for (int j = 0; j < 6; j++)
                        {
                            if (max < DP[j])
                                max = DP[j];
                        }
                        value = 0;
                        TotalResult = TotalResult + A[i] + max;
                    }
                    else
                    {
                        TotalResult = TotalResult + A[i];
                    }
                    counter = 0;
                    //DP = new int[6];
                }
                else
                {
                    if (counter < 5)
                        DP[counter] = A[i];
                    else if (counter == 5)
                    {
                        DP[counter] = A[i];
                        value = A[i];
                    }
                    else
                    {
                        int max = -10001;
                        for (int j = 0; j < 6; j++)
                        {
                            if (max < DP[j])
                                max = DP[j];
                        }
                        DP[counter % 6] = max + A[i];
                        value = max;
                    }
                }
                counter++;
            }
            return TotalResult;
        }

        public int New_solution(int[] A)
        {
            int result = 0;
            int[] DP = new int[A.Length];
            DP[0] = A[0];
            for (int i = 0; i < A.Length; i++)
            {
                int max = int.MinValue;
                int j = 1;
                while (j <= 6 && i - j >= 0)
                {
                    int temp = DP[i - j] + A[i];
                    if (temp > max)
                        max = temp;
                    j++;
                }
                if(i > 0)
                    DP[i] = max;
            }
            result = DP[A.Length - 1];
            return result;
        }
    }
}
