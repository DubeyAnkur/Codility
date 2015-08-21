using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    }
}
