using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codility._2012
{
    class Tau
    {
        public int solution(int[][] C)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            int result = 0;
            int M = C.Length;
            int N = C[0].Length;

            int[,] DP = new int[2 * N, 2 * M];
            int[,] CP = new int[2 * N, 2 * M];

            for (int i = 0; i < 2 * N; i++)
            {
                for (int j = 0; j < 2 * M; j++)
                {
                    int X = i % N;
                    int Y = j % M;
                    CP[i, j] = C[X][Y];
                }
            }

            //-------->
            for (int i = 0; i < 2 * N; i++)
            {
                for (int j = 0; j < 2 * M; j++)
                {
                    if (j > 0)
                        DP[i, j] = DP[i, j - 1] + CP[i, j];
                    else
                        DP[i, j] = CP[i, j];
                }
            }
            //Down this time.
            for (int i = 1; i < 2 * N; i++)
            {
                for (int j = 0; j < 2 * M; j++)
                {
                    DP[i, j] = DP[i, j] + DP[i - 1, j];
                }
            }

            int sum = 0;
            for (int x = 0; x < N; x++)
            {
                for (int y = 0; y < M; y++)
                {
                    for (int i = x; i < N + x; i++)
                    {
                        for (int j = y; j < M + y; j++)
                        {
                            int Total = DP[i, j];
                            int A = x > 0 ? DP[x - 1, j] : 0;
                            int B = y > 0 ? DP[i, y - 1] : 0;
                            int F = x > 0 && y > 0 ? DP[x - 1, y - 1] : 0;

                            sum = Total - A - B + F;
                            if (sum > result)
                                result = sum;
                        }
                    }
                }
            }

            return result;
        }
    }
}
