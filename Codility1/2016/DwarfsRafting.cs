using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codility
{
    class DwarfsRafting
    {
        public int solution(int N, string S, string T)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            int[,] boat = new int[N, N];

            if (S.Length > 0)
            {
                foreach (string word in S.Split(' '))
                {
                    int row = Convert.ToInt32(word.Substring(0, word.Length - 1));
                    int col = Convert.ToInt32(Convert.ToChar(word.Substring(word.Length - 1, 1))) - 64;

                    boat[row - 1, col - 1] = 1; //Barrel
                }
            }
            if (T.Length > 0)
            {
                foreach (string word in T.Split(' '))
                {
                    int row = Convert.ToInt32(word.Substring(0, word.Length - 1));
                    int col = Convert.ToInt32(Convert.ToChar(word.Substring(word.Length - 1, 1))) - 64;

                    boat[row - 1, col - 1] = 2; //Dwaft
                }
            }

            int[,] D = new int[2, 2];
            int[,] Sp = new int[2, 2];

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (boat[i, j] == 1)
                    {
                        if (i <= (N / 2) - 1)
                        {
                            if (j <= (N / 2) - 1)
                                Sp[0, 0]++;
                            else
                                Sp[0, 1]++;
                        }
                        else
                        {
                            if (j <= (N / 2) - 1)
                                Sp[1, 0]++;
                            else
                                Sp[1, 1]++;
                        }
                    }
                    else if (boat[i, j] == 2)
                    {
                        if (i <= (N / 2) - 1)
                        {
                            if (j <= (N / 2) - 1)
                                D[0, 0]++;
                            else
                                D[0, 1]++;
                        }
                        else
                        {
                            if (j <= (N / 2) - 1)
                                D[1, 0]++;
                            else
                                D[1, 1]++;
                        }
                    }
                }
            }


            int Max = (N * N) / 4;
            Sp[0, 0] = Max - Sp[0, 0] - D[0, 0];
            Sp[0, 1] = Max - Sp[0, 1] - D[0, 1];
            Sp[1, 0] = Max - Sp[1, 0] - D[1, 0];
            Sp[1, 1] = Max - Sp[1, 1] - D[1, 1];

            // D & S are ready....

            int adjst = 0;
            if (D[0, 0] > D[1, 1])
            {
                if (D[1, 1] + (Sp[1, 1]) < D[0, 0])
                    return -1;
                else
                {
                    adjst = adjst + D[0, 0] - D[1, 1];
                    Sp[1, 1] = Sp[1, 1] - (D[0, 0] - D[1, 1]);
                }
            }
            if (D[1, 1] > D[0, 0])
            {
                if (D[0, 0] + (Sp[0, 0]) < D[1, 1])
                    return -1;
                else
                {
                    adjst = adjst + D[1, 1] - D[0, 0];
                    Sp[0, 0] = Sp[0, 0] - (D[1, 1] - D[0, 0]);
                }
            }

            if (D[0, 1] > D[1, 0])
            {
                if (D[1, 0] + (Sp[1, 0]) < D[0, 1])
                    return -1;
                else
                {
                    adjst = adjst + D[0, 1] - D[1, 0];
                    Sp[1, 0] = Sp[1, 0] - (D[0, 1] - D[1, 0]);
                }
            }
            if (D[1, 0] > D[0, 1])
            {
                if (D[0, 1] + (Sp[0, 1]) < D[1, 0])
                    return -1;
                else
                {
                    adjst = adjst + D[1, 0] - D[0, 1];
                    Sp[0, 1] = Sp[0, 1] - (D[1, 0] - D[0, 1]);
                }
            }

            if (Sp[0, 0] > Sp[1, 1])
                adjst = adjst + Sp[1, 1] * 2;
            else
                adjst = adjst + Sp[0, 0] * 2;

            if (Sp[0, 1] > Sp[1, 0])
                adjst = adjst + Sp[1, 0] * 2;
            else
                adjst = adjst + Sp[0, 1] * 2;

            return adjst;
        }
    }
}
