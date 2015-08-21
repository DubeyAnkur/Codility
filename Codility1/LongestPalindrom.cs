using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codility
{
    class LongestPalindrom
    {
        public int solution(string seq)
        {
            int Longest = 0;
            List<int> l = new List<int>();
            int i = 0;
            int palLen = 0;
            int s = 0;
            int e = 0;
            while (i < seq.Length)
            {
                if (i > palLen && seq[i - palLen - 1] == seq[i])
                {
                    palLen += 2;
                    i += 1;
                    continue;
                }
                l.Add(palLen);
                Longest = Math.Max(Longest, palLen);
                s = l.Count - 2;
                e = s - palLen;
                bool found = false;
                for (int j = s; j > e; j--)
                {
                    int d = j - e - 1;
                    if (l[j] == d)
                    {
                        palLen = d;
                        found = true;
                        break;
                    }
                    l.Add(Math.Min(d, l[j]));
                }
                if (!found)
                {
                    palLen = 1;
                    i += 1;
                }
            }
            l.Add(palLen);
            Longest = Math.Max(Longest, palLen);
            return Longest;
        }
        public int solution2(string seq)
        {
            int N = seq.Length;
            int max = 0;
            int tempMax = 0;
            int pl = 0;
            int[] C = new int[2 * N];

            for (int i = 0; i < 2 * N; i++)
            {
                pl = 0;
                int j = i / 2;
                if (i % 2 == 1)
                {
                    while (j + pl < N && j >= pl && seq[j - pl] == seq[j + pl])
                        pl += 1;
                    C[i] = 2 * pl - (i % 2);
                    tempMax = C[i];
                }
                else
                {
                    while (j + pl < N && j > pl && seq[j - pl - 1] == seq[j + pl])
                        pl += 1;
                    C[i] = 2 * pl;
                    tempMax = C[i];
                }
                max = Math.Max(max, C[i]);
                int x = i;
                int y = i;
                bool flag = false;

                while (x < i + C[i] - 1)
                {
                    x++;
                    y--;
                    C[x] = C[y];
                    if (C[y] + x == i + C[i])
                    {
                        i = x - 1;
                        flag = true;
                        break;
                    }
                }
                // If results are incorrect, comment below 2 lines.
                if (!flag && C[i] > 2)
                    i = i + C[i] - 1;
            }
            max = Math.Max(max, tempMax);

            return max;
        }
    }
}
