using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codility._2014
{
    class Neon
    {
        public int solution1(int[] R, int X, int M)
        {
            if (R.Length * X * 2 > M)
                return -1;

            Array.Sort(R);

            int result = 0;
            Stack<Boat> prev = new Stack<Boat>();

            for (int i = 0; i < R.Length; i++)
            {
                if (prev.Count == 0)
                {
                    Boat temp;
                    if (R[i] >= X)
                        temp = new Boat(R[i] - X, R[i] + X, 0);
                    else
                        temp = new Boat(0, 2 * X, X - R[i]);
                    prev.Push(temp);
                }
                else
                {
                    Boat park = prev.Peek();
                    if (park.right < R[i] - X)
                    {
                        Boat temp = new Boat(R[i] - X, R[i] + X, 0);
                        prev.Push(temp);
                    }
                    else
                    {
                        Boat merge = prev.Pop();
                        Boat temp = new Boat(park.right, park.right + 2 * X, park.right + X - R[i]);
                        int adjst = Convert.ToInt32(Math.Ceiling((double)(temp.rope - merge.rope) / 2));
                        temp.sMax = merge.rope;
                        temp.left = merge.left; //temp = merge + temp;

                        if (adjst == 0)
                        {
                            temp.rope = Math.Max(temp.rope, merge.rope);
                            prev.Push(temp);
                        }
                        else
                        {
                            while (adjst > 0 && prev.Count > 0)
                            {
                                merge = prev.Pop();
                                if (temp.left - merge.right <= adjst)
                                {
                                    int partial = temp.left - merge.right;
                                    temp.left = merge.left;
                                    temp.right = temp.right - partial;
                                    temp.rope = temp.rope - partial;
                                    temp.sMax = Math.Max(temp.sMax + partial, merge.rope);

                                    adjst = adjst - partial;
                                    if (adjst == 0)
                                        prev.Push(temp);
                                    if (merge.rope > temp.rope)
                                    {
                                        temp.rope = merge.rope;
                                        temp.sMax = merge.rope;
                                        prev.Push(temp);
                                        continue;
                                    }
                                }
                                else
                                {
                                    prev.Push(merge);
                                    temp.left = temp.left - adjst;
                                    temp.right = temp.right - adjst;
                                    temp.rope = temp.sMax + adjst; // temp.rope - adjst;
                                    prev.Push(temp);
                                    adjst = 0;
                                }
                            }
                            if (prev.Count == 0)
                            {
                                if (temp.left > adjst)
                                {
                                    temp.left = temp.left - adjst;
                                    temp.rope = temp.rope - adjst;
                                }
                                else
                                {
                                    temp.rope = temp.rope - temp.left;
                                    temp.left = 0;
                                }
                                prev.Push(temp);
                            }
                        }
                    }
                }
            }
            while (prev.Count > 0)
            {
                if (prev.Peek().rope > result)
                    result = prev.Peek().rope;
                prev.Pop();
            }
            return result;
        }

        public class Boat
        {
            public int left;
            public int right;
            public int rope;
            public int sMax;

            public Boat(int l, int r, int rop)
            {
                left = l;
                right = r;
                rope = rop;
            }
        }

        public int solution(int[] R, int X, int M)
        {
            if (R.Length * X * 2 > M)
                return -1;

            int j = 0, Gap = 0, Right = 0, Rope = 0, leftRope = 0;
            while (j < R.Length && R[j] < Right + X)
            {
                leftRope = Math.Max(leftRope, Right + X - R[j]);
                Right = Right + 2 * X;
                j++;
            }

            for (int i = j; i < R.Length; i++)
            {
                if (R[i] - X >= Right)
                {
                    int adjst = R[i] - X - Right;
                    if (adjst > Rope)
                    {
                        int prevRight = Right;
                        Right = R[i] + X - Rope;
                        Gap = Gap + (Right - 2 * X) - prevRight;
                    }
                    else
                        Right = Right + 2 * X;
                }
                else
                {
                    int tempRope = Right + X - R[i];
                    int adjst = Convert.ToInt32(Math.Ceiling((double)(tempRope - Rope) / 2));
                    if (adjst > 0)
                    {
                        if (Gap >= adjst)
                        {
                            Rope = Rope + adjst;
                            Right = Right + 2 * X - adjst;
                            Gap = Gap - adjst;
                        }
                        else
                        {
                            leftRope = Math.Max(tempRope - Gap, leftRope);
                            Rope = Rope + Gap; // What about adjst.
                            Right = Right + 2 * X - Gap;
                            Gap = 0;
                        }
                    }
                    else
                        Right = Right + 2 * X; 
                }

                if (Right > M)
                {
                    Rope = Rope + Right - M;
                    Right = M;
                }

            }
            return Math.Max(Rope, leftRope);
        }
    }
}
