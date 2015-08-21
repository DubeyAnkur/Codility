using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Codility
{
    class CountNonDivisible
    {
        public int[] solution(int[] A)
        {
            // write your code in C# 5.0 with .NET 4.5 (Mono)
            Stopwatch w = new Stopwatch();
            w.Start();
            var PL = new List<PlaceHolder>();
            for(int i=0;i<A.Length;i++)
            {
                PL.Add(new PlaceHolder());
                PL[i].val = A[i];
                PL[i].index = i;
            }
            Console.WriteLine(w.ElapsedMilliseconds);
            w.Stop();
            w.Start();

            PL.Sort();
            Console.WriteLine(w.ElapsedMilliseconds);
            w.Stop();
            w.Start();
            //for (int i = 0; i < A.Length; i++)
            //{
            //    Console.WriteLine(PL[i].val + " " + PL[i].index);
            //}

            for (int i = PL.Count - 2; i >= 0; i--)
            {
                if (PL[i].val == PL[i + 1].val)
                    PL[i].cnt = PL[i + 1].cnt + 1;
                else
                    PL[i].cnt = 0;
            }
            //Console.WriteLine(w.ElapsedMilliseconds);
            //w.Stop();
            //w.Start();
            //string a = "", b = "";
            //for (int i = 0; i < PL.Count; i++)
            //{
            //    a = a + PL[i].val + " ";
            //    b = b + PL[i].cnt + " ";
            //}
            //Console.WriteLine(a);
            //Console.WriteLine(b);

            int[] S = new int[2*A.Length +2];

            for (int i = 0; i< PL.Count ; i++)
            {
                int k = PL[i].val;
                //S[k] = S[k] + 1;
                int incm = PL[i].cnt;
                if (incm > 1)
                {
                    incm++;
                    i = i + incm;
                }
                else
                    incm = 1;
                int l = k;
                while(l<=2*A.Length)
                {
                    S[l] = S[l] + incm;
                    l = l + k;
                }
            }
            Console.WriteLine(w.ElapsedMilliseconds);
            w.Stop();
            w.Start();

            //for (int i = 0; i < S.Length; i++)
            //{
            //    Console.WriteLine(i + ": " + S[i] + " ");
            //}
            //Console.WriteLine();

            int[] result = new int[A.Length];
            for (int i = 0; i < PL.Count; i++)
            {
                int greater = PL.Count - i - 1;
                int less = i - S[PL[i].val] + 1;
                int count = PL[i].cnt;
                result[PL[i].index] = greater + less; //- count: No need already done in Less.
                //Console.WriteLine("AI: " + A[i] + " I: "  + i + " Index: " + PL[i].index + " PL:" + PL[i].val + "\t F: " + S[PL[i].val] + "\t G: " + greater + " L: " + less + " C: " + count);//+ " L: " + less + " C: " + count + " R: " + result[PL[i].index]);
            }
            Console.WriteLine(w.ElapsedMilliseconds);
            w.Stop();

            return result;
        }

        public class PlaceHolder : IComparable<PlaceHolder>
        {
            public int val;
            public int index;
            public int cnt;

            public int CompareTo(PlaceHolder other)
            {
                return val.CompareTo(other.val);
            }
        }
    }
}
