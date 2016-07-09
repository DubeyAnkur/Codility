using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Codility
{
    class FabFrog
    {
        public int solution(int[] A)
        {
            // write your code in C# 5.0 with .NET 4.5 (Mono)
            int N = A.Length;

            Queue<Tup> Q = new Queue<Tup>();

            Q.Enqueue(new Tup(-1,-1,0,-4));
            while(Q.Any())
            {
                Tup t = Q.Dequeue();

                if (isFab(t.mid - t.start) && isFab(N - t.mid))
                {
                    Console.WriteLine(t.prev + " | " + t.start + " : " + t.mid + " : " + (N - t.mid));
                    return t.Depth + 1;
                }
                else if (t.Depth == 0)
                {
                    for (int i = t.mid + 1; i < A.Length; i++)
                    {
                        if (A[i] == 1)
                        {
                            Tup nT = new Tup(t.mid, i, t.Depth + 1, t.start);
                            if (myFab(i) < N)
                                Q.Enqueue(nT);
                            else
                                break;
                            //Console.WriteLine(i);
                        }
                    }
                }
                else if (isFab(t.mid - t.start))
                {
                    for (int i = t.mid + 1; i < A.Length; i++)
                    {
                        if (A[i] == 1)
                        {
                            Tup nT = new Tup(t.mid, i, t.Depth + 1, t.start);
                            if (myFab(i) < N)
                                Q.Enqueue(nT);
                            else
                                break;
                            //Console.WriteLine(i);
                        }
                    }
                }
               
            }
            return -1;
        }
        public bool isFab(int num)
        {
            double val1 = Math.Sqrt(5*num*num + 4);
            double val2 = Math.Sqrt(5 * num * num - 4);
            
            if(((val1%1) == 0 ) && ((val2 % 2) == 0))
                return false;
            else if ((val1 % 1) == 0)
                return true;
            else if ((val2 % 1) == 0)
                return true;
            else
                return false;
        }

        public double myFab(int n)
        {
            double phi = (1 + Math.Sqrt(5)) / 2;
            double nphi = (1 - Math.Sqrt(5)) / 2;
            double fn = (Math.Pow(phi, n) - Math.Pow(nphi, n)) / Math.Sqrt(5);
            return Math.Round(fn);
        }

        public class Tup
        {
            public Tup(int s,int m, int d, int p)
            {
                start = s;
                mid = m;
                Depth = d;
                prev = prev + p;
            }
            public int start;
            public int mid;
            public int Depth;
            public string prev ="";
        }


        //Java Solution below:
        public int solution4(int[] A)
        {
            // write your code in Java SE 8
            // the original version is at
            // http://codesays.com/2014/solution-to-fib-frog-by-codility/
            int N = A.Length;
            int[] fib = new int[N + 4];
            bool[] visit = new bool[N];
            fib[0] = 0;
            fib[1] = 1;
            int m = 1;
            do
            {
                m++;
                fib[m] = fib[m - 1] + fib[m - 2];
            } while (fib[m] <= N + 1);
            ArrayList statusQueue = new ArrayList();
            // use a queue to save the position and the moves of every possible jump
            statusQueue.Add(new Status(-1, 0));
            int nextTry = 0;
            // use the breadth first search to get the result
            while (true)
            {
                if (nextTry == statusQueue.Count)
                    return -1;
                Status currStatus = (Status)statusQueue[nextTry];
                nextTry++;
                int currPosition = currStatus.position;
                int currMoves = currStatus.moves;
                for (int i = m - 1; i > 0; i--)
                {
                    if (currPosition + fib[i] == N)
                        return currMoves + 1;
                    else if (currPosition + fib[i] > N ||
                             A[currPosition + fib[i]] == 0 ||
                             visit[currPosition + fib[i]] == true)
                        continue;
                    statusQueue.Add(new Status(currPosition + fib[i], currMoves + 1));
                    visit[currPosition + fib[i]] = true;
                }
            }
        }
    }

    class Status
    {
        public int position;
        public int moves;

        public Status(int p, int m)
        {
            position = p;
            moves = m;
        }


    }
}
