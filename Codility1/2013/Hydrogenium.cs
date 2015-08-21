using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codility._2013
{
    class Hydrogenium
    {
        public int solution(int[] A, int[] B, int[] C, int[] D)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            int result = Int32.MaxValue;
            int N = D.Length;
            //int[] DP = new int[N];

            int[,] LookUp = new int[N,N];

            if (D[0] != -1)
                return 0;
            // Initialize
            for (int i = 0; i < N; i++ )
            {
                for (int j = 0; j < N; j++)
                {
                    LookUp[i, j] = Int32.MaxValue;
                }
            }

            // Fill it up
            for (int i = 0; i < A.Length; i++)
            {
                if (LookUp[A[i], B[i]] > C[i])
                    LookUp[A[i], B[i]] = C[i];

                if (LookUp[B[i], A[i]] > C[i])
                    LookUp[B[i], A[i]] = C[i];
            }

            //Start Traverse
            var Main = new Tuple<int, int, int>[N]; // Distance, End, Start
            int minVal = Int32.MaxValue;
            int minInd = 0;
            bool[] Explored = new bool[N];
            //int[] RT = new int[N];

            for (int i = 1; i < N; i++)
            {
                Main[i] = new Tuple<int, int, int>(LookUp[0, i], i, 0);
                if(minVal > LookUp[0, i])
                {
                    minVal = LookUp[0, i];
                    minInd = i;
                    //RT[i] = minVal;
                }
            }
            Explored[0] = true;
            int[] Prev = new int[N];
            Prev[minInd] = minVal;

            for (int i = 1; i < N; i++ )
            {
                Explored[minInd] = true; // 2
                minVal = Int32.MaxValue;
                int curr = minInd;
                for (int j = 0; j < N; j++ )
                {
                    if(Explored[j] == false) // j = 1; 
                    {
                        var temp = Main[j]; // temp = 5,1,0 
                        int fake = LookUp[curr, j] == Int32.MaxValue? Int32.MaxValue : Prev[curr] + LookUp[curr, j];
                        if(fake < temp.Item1 )
                        {
                            temp = new Tuple<int, int, int>(fake, temp.Item2, curr);
                            Main[j] = temp;
                            Prev[j] = fake;
                            if (D[j] > fake && result > fake)
                                result = fake;
                        }
                        if(minVal > fake)
                        {
                            minVal = fake;
                            minInd = j;
                        }
                    }
                }
            }
            if (result == Int32.MaxValue)
                result = -1;

            return result;
        }
    }
}
