using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codility
{
    class BallSwitchBoard
    {

        //int[][] K = new int[4][];
        //    K[0] = new int[6];
        //    K[1] = new int[6];
        //    K[2] = new int[6];
        //    K[3] = new int[6];

        //    K[0][0] = K[1][1] = K[2][2] = K[3][4] = K[0][4] = K[1][5] = K[3][0] = 1;
        //    K[0][2] = K[2][0] = K[2][2] = K[1][3] = K[2][4] = K[3][5] = K[3][2] = -1;

        public int solution(int[][] A, int K)
        {
            // write your code in C# 5.0 with .NET 4.5 (Mono)
            int result = 0;

            int N = A.Length;
            int M = A[0].Length;

            int[] U = new int[M];
            int[] R = new int[M];
            U[0] = K;

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    int top = U[j];
                    int left = 0;
                    if(j> 0)
                        left = R[j - 1];
                    int tot = top + left;
                    if (A[i][j] == -1)
                    {
                        U[j] = tot/2 + tot%2;
                        R[j] = tot/2;
                    }
                    else if (A[i][j] == 1)
                    {
                        U[j] = tot / 2;
                        R[j] = tot / 2 + tot % 2;
                    }
                    else //0
                    {
                        U[j] = top;
                        R[j] = left;
                    }
                }
                R = new int[M];
            }

            result = U[M-1];
            return result;
        }

        public int solution2(int[][] A, int K)
        {
            int result = 0;
            int i = 0;
            int j = 0;

            int N = A.Length;
            int M = A[0].Length;

            while(i<N && j<M)
            {
                bool mi = false;
                bool mj = false;

                if (A[i][j] == -1)
                {
                    i++;
                    mi = true;
                }
                if (A[i][j] == 1)
                {    
                    j++;
                    mj = true;
                }
                if (A[i][j] == 0 && mi)
                    i++;
                if (A[i][j] == 0 && mj)
                    j++;
            }
            return result;
        }

        public int HamiltonianRoutesCount(int[] A)
        {
            int M = A.Length/2 + 1;
            int[] B = new int[M];
            int[,] C = new int[M,3];


            int result = 3;

            for (int i = 0; i < A.Length; i++ )
            {
                if (i > 0 && A[i] == A[i - 1])
                    return -2;

                B[A[i]] += 1;
            }
            //B[A[0]] += 1;
            for (int i = 0; i < B.Length; i++)
            {
                if (B[i] != 1 && B[i] != 3)
                {
                    return -2;
                }
            }

            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < 3; j++)
                    C[i, j] = -1;
            }

            for (int i = 1; i < A.Length; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (C[A[i], j] == A[i - 1])
                    {
                        break;
                    }
                    if (C[A[i], j] == -1)
                    {
                        C[A[i], j] = A[i - 1];
                        break;
                    }
                    else if (j == 2)
                        return -2;
                }
                for (int j = 0; j < 3; j++)
                {
                    if (C[A[i-1], j] == A[i])
                    {
                        break;
                    }
                    if (C[A[i - 1], j] == -1)
                    {
                        C[A[i - 1], j] = A[i];
                        break;
                    }
                    else if (j == 2)
                        return -2;
                }
                //for (int j = 0; j < 3; j++)
            }

            for (int i = 0; i < M; i++)
            {
                if (C[i, 0] == -1)
                    return -2;
                if (C[i, 1] != -1 && C[i, 2] == -1)
                    return -2;
            }

            return result;
        }
    }
}
