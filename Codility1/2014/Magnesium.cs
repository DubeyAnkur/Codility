using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codility._2014
{
    class Magnesium
    {
        public int solution(int N, int[] A, int[] B, int[] C)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            int result = 0;
            int[] w = new int[N];
            int M = C.Length;

            List<Tuple<int, int>> sortedC = new List<Tuple<int, int>>();

            for (int i = 0; i < C.Length; i++)
                sortedC.Add(new Tuple<int, int>(C[i], i));

            sortedC.Sort((x, y) => x.Item1.CompareTo(y.Item1));

            List<Tuple<int, int>> updates = new List<Tuple<int, int>>();

            for (int i = 0; i < sortedC.Count; i++)
            {
                int x = sortedC[i].Item2;
                int u = A[x];
                int v = B[x];
                updates.Add(new Tuple<int, int>(u, Math.Max(w[u], w[v] + 1)));
                updates.Add(new Tuple<int, int>(v, Math.Max(w[v], w[u] + 1)));

                if (i == M - 1 || sortedC[i].Item1 != sortedC[i + 1].Item1)
                {
                    for (int j = 0; j < updates.Count; j++)
                    {
                        w[updates[j].Item1] = Math.Max(w[updates[j].Item1], updates[j].Item2);
                    }
                    updates = new List<Tuple<int, int>>();
                }
            }

            for (int i = 0; i < w.Length; i++)
            {
                if (result < w[i])
                    result = w[i];
            }

            return result;
        }
    }
}
