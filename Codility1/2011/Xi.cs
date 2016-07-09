using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codility._2011
{
    class Xi
    {
        public int solution(string S, string T, int K)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            int result = 0;

            T = KParseIncrease(T, K);
            //S = KParseIncrease(S, K);

            int[] F = FindKParse(T.Length, K);

            for (int i = 0; i < T.Length; i++)
            {
                if (T[i] == '1')
                    result = (result + F[T.Length - i - 1]) % 1000000007;
            }
            for (int i = 0; i < S.Length; i++)
            {
                if (S[i] == '1')
                    result = (result - F[S.Length - i - 1]) % 1000000007;
            }

            return result;
        }
        public string KParseIncrease(string T, int K)
        {
            int j = 0;
            int mostSigni = 0;
            int current = K + 1;
            T = "0" + T;
            while (j < T.Length)
            {
                if (T[j] == '1')
                {
                    if (current < K)
                        break;
                    if (current > K)
                        mostSigni = j - 1;

                    current = 0;
                }
                else
                    current++;

                j++;
            }
            string S = T;
            S = T.Substring(0, mostSigni);
            S += '1';
            for (int i = mostSigni + 1; i < T.Length; i++)
                S += '0';

            return S;
        }
        public int[] FindKParse(int length, int K)
        {
            int[] F = new int[length];
            for (int i = 0; i < length; i++)
            {
                F[i] = 1;
            }

            for (int i = 1; i < length; i++)
            {
                if (i > K)
                    F[i] = (F[i - 1] + F[i - K - 1]) % 1000000007;
                else
                    F[i] = (F[i - 1] + 1) % 1000000007;
            }

            return F;
        }

        //public int new_solution(string S, string T, int K)
        //{
        //    int ModP = 1000000007;
        //    int[] F = new int[B.Length + 2];
        //    //[1] * (len(B) + 2);
        //    for (int i = 0; i < F.Length; i++)
        //    {
        //        if (i > K)
        //            F[i] = (F[i - 1] + F[i - K - 1]) % ModP;
        //        else
        //            F[i] = (F[i - 1] + 1) % ModP;
        //    }

        //    return (below(increase(B), K) - below(A, K) + ModP) % ModP;
        //}

        //public int below(string N, int K)
        //{
        //    N = '0' + N;
        //    int l = N.Length;
        //    int c = K + 1;
        //    int i = 0;
        //    int j = 0;
        //    while (i < l)
        //    {

        //        if (N[i] == '1')
        //        {
        //            if (c < K)
        //                break;
        //            else if (c > K)
        //                j = i;
        //            c = 0;
        //        }
        //        else
        //            c += 1;
        //        i += 1;
        //    }
        //    if (i < l)
        //    {
        //        string str = "";
        //        str = N.Substring(0, j - 1);
        //        //for (int an = 0; an < j - 1; j++)
        //        //    str = str + N[an];
        //        N = str + '1' + '0' * (l - j);
        //        //N = N[:j - 1] + '1' + '0' * (l - j);
        //    }
        //    return below_k_sparse(N, K);
        //}

        //public int below_k_sparse(string N, int K)
        //{
        //    int ModP = 1000000007;
        //    int l = N.Length;
        //    int res = 0;
        //    for (int i = 0; i < l; i++)
        //        if (N[i] == '1')
        //            res = (res + F[l - 1 - i]) % ModP;
        //    return res;
        //}
    }
}
