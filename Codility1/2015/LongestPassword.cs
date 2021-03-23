using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codility._2015
{
    class LongestPassword
    {
        public int solution(string S)
        {
            int maxLength = -1;

            foreach(var str in S.Split(' '))
            {
                int chCount = 0;
                int numCount = 0;
                bool otherCh = false;
                foreach (var ch in str)
                {
                    int asci = (int)ch;
                    if (asci >= 48 && asci <= 57)
                        numCount++;
                    else if (asci >= 65 && asci <= 90)
                        chCount++;
                    else if (asci >= 97 && asci <= 122)
                        chCount++;
                    else
                    { otherCh = true;  break; }
                }

                if (otherCh == false && chCount % 2 == 0 && numCount %2 ==1 & maxLength<= str.Length)
                {
                    maxLength = str.Length;
                }
            }

            return maxLength;
        }
    }
}
