using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codility._2016
{
    class RectangleBuilderGreaterArea
    {
        public int solution(int[] A, int X)
        {
            int ret = 0;
            if (A.Length ==0)
                return 0;
            Array.Sort(A);

            Numb[] Xc = new Numb[A.Length];
            int j = 0;
            Xc[j] = new Numb();
            Xc[j].val = A[0];
            int valid = 0;
            bool flag = false;
            for (int i = 0; i < A.Length; i++)
            {
                if (Xc[j].val == A[i])
                {
                    Xc[j].count++;
                    if (Xc[j].count >= 2 && flag == false)
                    {
                        flag = true;
                        valid++;
                    }
                }
                else
                {
                    flag = false;
                    j++;
                    Xc[j] = new Numb();
                    Xc[j].val = A[i];
                    Xc[j].count++;
                }
            }

            Numb[] Y = new Numb[valid];
            int k = 0;
            for (int i = 0; i < Xc.Length; i++)
            {
                if (Xc[i] == null)
                    break;

                if (Xc[i].count > 1)
                {
                    Y[k] = new Numb();
                    Y[k] = Xc[i];
                    k++;
                }
            }

            int down = Y.Length - 1;
            for (int i = 0; i < Y.Length; i++)
            {
                int me = Y[i].val;
                while (i <= down && (double)(Y[down].val * me) >= X)
                { down--; }

                if (down >= i)
                {
                    ret = ret + Y.Length - 1 - down; 
                }
                else
                {
                    if (Y[i].count >= 4)
                        ret = ret + 1;
                    ret = ret + Y.Length - 1 - i;
                }
                if (ret > 1000000000)
                    return -1;
            }
            string g = "";
            for (int i = 0; i < A.Length; i++)
            {
                g = g + "," + A[i];
            }
            Console.WriteLine(g + "|" + X);
            return ret;
        }

        public class Numb
        {
            public int val;
            public int count;
        }
    }
}
