using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codility._2019
{
    class LeaderSliceInc
    {
        public int[] solution(int K, int M, int[] A)
        {
            List<int> ret = new List<int>();
            int N = A.Length;
            for (int a = 0; a < N && a < K; a++)
            {
                A[a] = A[a] + 1;
            }

            int[] Count = new int[M+2];
            bool[] Leader = new bool[M+2];

            for (int a = 0; a < N; a++)
            {
                Count[A[a]] = Count[A[a]] + 1;
                if (Count[A[a]] > N / 2)
                    Leader[A[a]] = true;
            }

            int i = 1;
            int j = K;

            while (j<N)
            {
                A[i - 1] = A[i - 1] - 1;
                A[j] = A[j] + 1;

                Count[A[i - 1]+1]--;
                Count[A[i - 1]]++;

                Count[A[j]]++;
                Count[A[j] - 1]--;

                if(Count[A[i - 1]]> N/2)
                    Leader[A[i - 1]] = true;

                if (Count[A[j]] > N / 2)
                    Leader[A[j]] = true;

                i++; j++;
            }

            for (int k = 0; k < M+2; k++)
            {
                if (Leader[k] || Count[k] > N / 2)
                    ret.Add(k);
            }

            return ret.ToArray();
        }
    }
}
