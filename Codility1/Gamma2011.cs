using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codility
{
    class Gamma2011
    {
        public int solution(string seq)
        {
            int total = 0;
            int l, r;

            int N = seq.Length;
            l = r = -1;
            int[] odd = new int[seq.Length];
            int[] even = new int[seq.Length];

            for (int i = 0; i < seq.Length; i++ )
            {
                int pl = 1;
                if (i < r)
                    pl = Math.Min(r - i + 1, odd[l + r - i]);
                while (i - pl > 0 && i + pl < N && seq[i - pl] == seq[i + pl])
                    pl++;
                odd[i] = pl;
                if (i + pl - 1 > r)
                {
                    l = i - pl + 1;
                    r = i + pl - 1;
                }
            }

            l = r = -1;
            for (int i = 0; i < N; i++)
            {
                int cur = 0;
                if (i < r)
                    cur = Math.Min(r - i + 1, even[l + r - i + 1]);
                while (i + cur < N && i - 1 - cur >= 0 && seq[i - 1 - cur] == seq[i + cur])
                    cur++;
                even[i] = cur;
                if (i + cur - 1 > r)
                {
                    l = i - cur;
                    r = i + cur - 1;
                }
            }

            for (int i = 0; i < N; i++)
            {
                if (odd[i] > 1)
                {
                    total += odd[i] - 1;
                }
                if (even[i] > 0)
                    total += even[i];
            }

            return total;
        }
    }
}
