using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codility._2021
{
    class Multivitamin
    {
        private class Juice : IComparable
        {
            public int juice;
            public int capacity;
            public int index;
            public Juice(int j, int c, int indx)
            {
                juice = j;
                capacity = c;
            }
            public int CompareTo(object comparePart)
            {
                return this.juice.CompareTo(((Juice)comparePart).juice);
            }

        }
        public int solution(int[] juice, int[] capacity)
        {
            int ret = 1;
            int maxIndex = 0;

            var juiceList = new List<Juice>();


            for (int i = 0; i < juice.Length; i++)
            {
                var temp = new Juice(juice[i], capacity[i], i);
                juiceList.Add(temp);
            }
            juiceList.Sort();

            for (int i = 0; i < juiceList.Count; i++)
            {
                if (juiceList[i].capacity - juiceList[i].juice > juiceList[maxIndex].capacity - juiceList[maxIndex].juice)
                {
                    maxIndex = i;
                }
                else if (juiceList[i].capacity - juiceList[i].juice == juiceList[maxIndex].capacity - juiceList[maxIndex].juice && juiceList[i].juice < juiceList[maxIndex].juice)
                {
                    maxIndex = i;
                }
            }


            for (int i = 0; i < juiceList.Count; i++)
            {
                if (i != maxIndex)
                {
                    if (juiceList[maxIndex].capacity - juiceList[maxIndex].juice >= juiceList[i].juice)
                    {
                        juiceList[maxIndex].juice = juiceList[maxIndex].juice + juiceList[i].juice;
                        ret++;
                    }
                    else if (juiceList[i].capacity - juiceList[i].juice >= juiceList[maxIndex].juice)
                    {
                        juiceList[i].juice = juiceList[i].juice + juiceList[maxIndex].juice;
                        maxIndex = i;
                        ret++;
                    }
                }
            }

            return ret;
        }
    }
}
