using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codility.Lessons
{
    class Flags
    {
        public int solution(int[] A)
        {
            int[] peeks = new int[A.Length];
            int N = A.Length;
            int TotalFlags = 0;
            int result = 0;
            int i;
            for (i = 1; i < A.Length - 1; i++)
            {
                if (A[i] > A[i - 1] && A[i] > A[i + 1])
                {
                    peeks[i] = 1;
                    TotalFlags++;
                }
            }
            int MaxF = Math.Min(TotalFlags, Convert.ToInt32(Math.Floor(Math.Sqrt(A.Length))));

            if (MaxF <= 1)
                return MaxF;

            int[] next = NextPeak(A, peeks);

            i = 1;
            while ((i - 1) * i <= N)
            {
                int pos = 0;
                int num = 0;
                while (pos < N && num < i)
                {
                    pos = next[pos];
                    if (pos == -1)
                        break;
                    num++;
                    pos += i;
                }
                result = Math.Max(result, num);
                i++;
            }
            return result;
        }

        public int[] NextPeak(int[] A, int[] peaks)
        {

            int N = A.Length;
            int[] next = new int[N];
            next[N - 1] = -1;
            for (int i = N - 2; i >= 0; i--)
            {
                if (peaks[i] == 1)
                    next[i] = i;
                else
                    next[i] = next[i + 1];

            }
            return next;
        }

        public int N2Solution(int[] A)
        {
            int result = 0;
            
            int N = A.Length;
            int[] Peeks = new int[N];
            for (int i = 1; i < N - 1; i++)
            {
                if (A[i] > A[i - 1] && A[i] > A[i + 1])
                    Peeks[i] = 1;
            }

            for (int i = 0; i < N; i++)
            {
                int flags = i;
                for (int j = 0; j < N; j++)
                {
                    if (Peeks[j] == 1)
                    {
                        flags--;
                        j = j + i;
                    }

                    if (flags == 0)
                    {
                        result = i;
                        break;
                    }
                }
            }
            return result; 
        }


        public int NLogNsolution(int[] A)
        {
            int result = 0;

            int N = A.Length;
            int[] Peeks = new int[N];
            for (int i = 1; i < N - 1; i++)
            {
                if (A[i] > A[i - 1] && A[i] > A[i + 1])
                    Peeks[i] = 1;
            }

            int l = 0;
            int r = N;
            while(l<N && r>0 && l<r)
            {
                int i = (l + r) / 2;

                int flags = i;
                for (int j = 0; j < N; j++)
                {
                    if (Peeks[j] == 1)
                    {
                        flags--;
                        j = j + i;
                    }

                    if (flags == 0)
                    {
                        result = i;
                        break;
                    }
                }
                if (flags == 0 && i != l)
                    l = i;
                else
                    r = i;
            }
            return result;

        }

        public int NSolution(int[] A)
        {
            int result = 0;

            int N = A.Length;
            int[] Peeks = new int[N];
            int TotalFlags = 0;
            for (int i = 1; i < N - 1; i++)
            {
                if (A[i] > A[i - 1] && A[i] > A[i + 1])
                {
                    Peeks[i] = 1;
                    TotalFlags++;
                }

            }

            int[] nextPeek = new int[N];
            nextPeek[N - 1] = -1;

            int next = -1;
            for (int i = N - 2; i >= 0; i--)
            {
                if (Peeks[i] == 1)
                {
                    next = i;
                }
                nextPeek[i] = next;
            }

            for (int i = 1; i <= Math.Sqrt(N); i++)
            {
                int flagsPlaced = 0;
                int currentPos = 0;
                while (currentPos < N && nextPeek[currentPos] > 0 && flagsPlaced < i)
                {
                    currentPos = nextPeek[currentPos];
                    if (nextPeek[currentPos] == -1)
                        break;
                    flagsPlaced++;
                    currentPos = currentPos + i;
                }
                result = Math.Max(result, flagsPlaced);
            }

            return result;
        }
    }

}
