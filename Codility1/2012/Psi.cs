using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codility._2012
{
    internal class Psi
    {
        public int solution(int N, int[] A, int[] B, int[] C)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            bool[,] vEdge = new bool[N, N];
            bool[,] hEdge = new bool[N, N];

            //Initialize as everything is connected.
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (j != N - 1)
                        vEdge[i, j] = true;
                    if (i != N - 1)
                        hEdge[i, j] = true;
                }
            }

            //Go to end of time and mark all burned wires.
            for (int i = 0; i < C.Length; i++)
            {
                if (C[i] == 0)
                    vEdge[A[i], B[i]] = false;
                else
                    hEdge[A[i], B[i]] = false;
            }


            //For All nodes there parent will be themself
            Node[,] Parent = new Node[N, N];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Parent[i, j] = new Node(i, j);
                }
            }

            //Join all wires which are still entact and connected.
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (vEdge[i, j] == true)
                        Join(i, j, i, j + 1, Parent);
                    if (hEdge[i, j] == true)
                        Join(i, j, i + 1, j, Parent);
                }
            }
            
            //If endpoints are still connected return -1;
            if (findParent(0, 0, Parent) == findParent(N - 1, N - 1, Parent))
                return -1;

            int result = 0;
            //Back traverse and find point where they join again.
            for (int i = C.Length - 1; i > 0; i--)
            {
                if (C[i] == 0)
                    Join(A[i], B[i], A[i], B[i] + 1, Parent);
                else
                    Join(A[i], B[i], A[i] + 1, B[i], Parent);

                if(findParent(0, 0, Parent) == findParent(N - 1, N - 1, Parent))
                {
                    break;
                }
                result = i; // Last value at which they are disconnected.
            }

            return result;
        }

        public void Join(int i, int j, int nI, int nJ, Node[,] Parent)
        {
            Node pOne, pTwo;
            pOne = findParent(i, j, Parent);
            pTwo = findParent(nI, nJ, Parent);
            if (pOne.Rank > pTwo.Rank)
            {
                Parent[nI, nJ] = pOne;
                //pTwo.X = pOne.X;
                //pTwo.Y = pOne.Y;
            }
            else if (pOne.Rank < pTwo.Rank)
            {
                Parent[i, j] = pTwo;
                //pOne.X = pTwo.X;
                //pOne.Y = pTwo.Y;
            }
            else
            {
                pOne.Rank++;
                //pTwo = Parent[pTwo.X, pTwo.Y];
                Parent[nI, nJ] = pOne;
                //pTwo.X = pOne.X;
                //pTwo.Y = pOne.Y;
            }
        }

        public Node findParent(int i, int j, Node[,] Parent)
        {
            Node temp = Parent[i, j];
            if (temp.X != i && temp.Y != j)
                temp = findParent(temp.X, temp.Y, Parent);
            return temp;
        }

        public class Node
        {
            public int X;
            public int Y;
            public int Rank;
            public Node(int i, int j)
            {
                X = i;
                Y = j;
                Rank = 0;
            }
        }

    }
}

