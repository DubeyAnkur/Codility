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
                return "0," + (N - 1);
            else
            {
                if (A[N - 1] % 2 == 1)
                    return "0," + (N - 2);
                else if (A[0] % 2 == 1)
                {
                    if (N <= 4) // Need to fix this defect.
                        return "1," + (N - 1);
                    else
                    {
                        string x = StartOver(A);
                        return x;
                    }
                }
                else
                {
                    if (N == 3)
                        return ret;
                    else
                    {
                        //
                        string x = StartOver(A);
                       
                        return x;
                    }
                }
            }
        }
        public string StartOver(int[] A)
        {
            int[] count = new int[A.Length];
            int N = A.Length;
            string solution1 = "";
            int length1 = int.MaxValue;
            int start1 = int.MaxValue;

            string solution2 = "";
            int length2 = int.MaxValue;
            int start2 = int.MaxValue;

            int total = 0;
            for (int i = 1; i < A.Length; i++)
            {
                if (A[i] % 2 == 1)
                    count[i] = count[i - 1] + 1;
                else
                    count[i] = count[i - 1];
                total = count[i];
            }
            bool flag1 = false;
            for (int i = 1; i < A.Length; i++)
            {
                if (count[i] == 1 && flag1 == false)
                {
                    flag1 = true;
                    int left = i;
                    int right = 0;

                    int k = N - 1;
                    while (k >= 0 && A[k] % 2 == 0 && right < left)
                    {
                        right++;
                        k--;
                    }
                    if (right == left)
                    {
                        length1 = k - i; // N - left + 1
                        solution1 = String.Format("{0},{1}", i + 1, k);
                        start1 = i + 1;
                    }
                    else
                    {
                        int j = i + 1;
                        while (j < k && A[j] % 2 == 0 && right < left)
                        {
                            right++;
                            j++;
                        }
                        if (right == left)
                        {
                            length1 = k - j + 1; // N - left + 1
                            solution1 = String.Format("{0},{1}", j, k);
                            start1 = j;
                        }
                    }
                }
                if (total - count[i] == 0)
                {
                    int left = 0;
                    int j = i - 1;
                    int right = N - i - 1;
                    while (j >= 0 && A[j] % 2 == 0 && left < right)
                    {
                        left++;
                        j--;
                    }
                    if (right == left)
                    {
                        length2 = i - left;
                        solution2 = String.Format("{0},{1}", 0, length2 - 1);
                        start2 = 0;
                    }
                    else
                    {
                        int k = 0;
                        while (k < N && A[k] % 2 == 0 && left < right)
                        {
                            left++;
                            k++;
                        }
                        if (right == left)
                        {
                            length2 = j - k + 1;
                            solution2 = String.Format("{0},{1}", k, j);
                            start2 = k;
                        }
                    }
                    break;
                }
            }
            if (length1 == length2 && length2 == 0)
            {
                return "NO SOLUTION";
            }
            if (start1 < start2) // No <=
                return solution1;
            else
                return solution2;
        }




        public string ProperCheck(int[] A)
        {
            int[] count = new int[A.Length];
            int N = A.Length;
            int total = 0;
            int temp1 = int.MaxValue;
            string ret1 = "";

            int temp2 = int.MaxValue;
            string ret2 = "";

            int min = int.MaxValue;
            // First item has to be Even, as its checked before calling this function.
            for (int i = 1; i < A.Length; i++)
            {
                if (A[i] % 2 == 1)
                    count[i] = count[i - 1] + 1;
                else
                    count[i] = count[i - 1];
                total = count[i];
            }

            for (int i = 1; i < A.Length; i++)
            {

                if (count[i] == 1 && i >= 2)
                {
                    temp1 = i - 2;
                    ret1 = "0," + (i - 2);
                    if (N - i > 2 && A[i + 1] % 2 == 1 && A[i + 2] % 2 == 1 && N - i - 2 < i)
                    {
                        temp1 = (N) - (i + 3);
                        ret1 = String.Format("{0},{1}", (i + 3), (N - 1));
                    }
                }
                else if (total - count[i] == 0 && N - 1 >= i - 2)
                {
                    temp2 = N - i - 2;
                    ret2 = String.Format("{0},{1}", (i + 2), (N - 1));

                    if (i > 2 && A[i - 1] % 2 == 1 && A[i - 2] % 2 == 1 && temp2 > i - 2)
                    {
                        temp2 = (i - 2);
                        ret2 = String.Format("{0},{1}", 0, (i - 2));
                    }
                    break;
                }
            }
            //Final Check
            if (temp1 <= temp2)
                return ret1;
            else
                return ret2;

        }

        public string BetterApproach(int[] A)
        {
            int[] count = new int[A.Length];
            int N = A.Length;
            int total = 0;
            int temp1 = int.MaxValue;
            string ret1 = "";
            string ret = "NO SOLUTION";

            int temp2 = int.MaxValue;
            string ret2 = "";

            int min = int.MaxValue;
            // First item has to be Even, as its checked before calling this function.
            for (int i = 1; i < A.Length; i++)
            {
                if (A[i] % 2 == 1)
                    count[i] = count[i - 1] + 1;
                else
                    count[i] = count[i - 1];
                total = count[i];
            }

            for (int i = 1; i < A.Length; i++)
            {

                if (count[i] == 1)
                {
                    int right = 0;
                    bool flag = false;
                    for (int j = i + 1; j < N; j++)
                    {
                        if (A[j] % 2 == 0 && flag == false)
                            right++;
                        else if (A[j] % 2 == 1 && flag == false)
                            flag = true;
                        else if (A[j] % 2 == 1 && flag == true)
                        {
                            flag = false;
                            right++;
                        }
                        //else not needed as we have to ignore those evens.
                    }
                    //Left = i;
                    if (i == right)
                        return ret;
                    else if (i > right)
                        return ret;
                }
                else if (total - count[i] == 0)
                {

                    break; //No need to check for future values.
                }
            }
            return ret;
        }
        public string FindReplace(int start, int num, int[] A)
        {
            string val = "";
            int move = 0;
            bool flag = false;
            while (move <= num)
            {
                if (A[start] % 2 == 0 && flag == false)
                    move++;
                else if (A[start] % 2 == 1 && flag == false)
                    flag = true;
                else if (A[start] % 2 == 1 && flag == true)
                {
                    flag = false;
                    move++;
                }
            }

            return String.Format("{0},{1}", start, start + move);
        }


    }
}