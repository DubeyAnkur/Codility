using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codility
{
    class Minfuds
    {
        public const double EPS = 0.0000001;
        public const double INF = 10000000.0;

        public struct Point
        {
            public double x;
            public double y;
        }
        public class Line
        {
            public int a;
            public int b;
        }

        
        internal static class Arrays
        {
            internal static T[] InitializeWithDefaultInstances<T>(int length) where T : new()
            {
                T[] array = new T[length];
                for (int i = 0; i < length; i++)
                {
                    array[i] = new T();
                }
                return array;
            }
        }


        public int cmp0(double x)
        {
            return (Math.Abs(x) < EPS) ? 0 : ((x > 0) ? 1 : -1);
        }

        public double f(Line[] lines, int i, double x)
        {
            return lines[i].a * x + lines[i].b;
        }

        public void get_intersection(Line[] lines, int i, int j, Point[] p, int k)
        {
            p[k].x = (lines[j].b - lines[i].b + 0.0) / (lines[i].a - lines[j].a);
            p[k].y = f(lines, i, p[k].x);
        }

        public int cmp_slope(object p, object q)
        {
            Line u = (Line)p;
            Line v = (Line)q;
            return ((u.a < v.a) || (u.a == v.a && u.b > v.b)) ? -1 : 1;
        }

        public int get_upper_lower(Line[] lines, int b, int e, int inc, int[] idx, Point[] ps)
        {
            ps[0].x = -1 * INF;
            ps[0].y = f(lines, b, ps[0].x);
            idx[0] = b;
            int i;
            int j;
            int k = 0;
            for (j = b + inc; j != e; j += inc)
            {
                i = idx[k];
                if (lines[j].a != lines[i].a)
                {
                    ++k;
                    get_intersection(lines, i, j, ps, k);
                    if (cmp0(ps[k].x - ps[k - 1].x) == 0)
                    {
                        --k;
                    }
                    else
                    {
                        while (k >= 2 && ps[k].x < ps[k - 1].x)
                        {
                            get_intersection(lines, idx[k - 2], j, ps, k - 1);
                            --k;
                        }
                    }
                    idx[k] = j;
                }
            }
            ps[++k].x = INF;
            ps[k].y = f(lines, idx[k - 1], ps[k].x);
            return k;
        }

        public double solution(int[] a, int[] b)
        {
            int i;
            int j;
            int un;
            int vn;
            int n = a.Length;
            Line[] lines = new Line[n];
            for (i = 0; i < n; ++i)
            {
                lines[i] = new Line();
                lines[i].a = a[i];
                lines[i].b = b[i];
            }
            //Sort it Someway
            Array.Sort(lines, cmp_slope);
            //qsort(lines, n, sizeof(Line), cmp_slope);

            int[] iu = new int[(n + 1)];
            Point[] pu = new Point[n + 1];
            un = get_upper_lower(lines, 0, n, 1, iu, pu);

            int[] iv = new int[n + 1];
            Point[] pv =  new Point[n + 1];
            vn = get_upper_lower(lines, n - 1, -1, -1, iv, pv);

            if (un <= 1 && vn <= 1)
            {
                return pu[0].y - pv[0].y;
            }

            double r = INF;
            double dy;
            for (i = 1, j = 1; i < un || j < vn; )
            {
                if (pu[i].x < pv[j].x)
                {
                    dy = pu[i].y - f(lines, iv[j - 1], pu[i].x);
                    ++i;
                }
                else
                {
                    dy = f(lines, iu[i - 1], pv[j].x) - pv[j].y;
                    ++j;
                }
                r = (dy < r) ? dy : r;
            }
            return Math.Abs(r);
        }

        public double solution2(int[] a, int[] b)
        {
            int N = a.Length;
            Line[] ln = new Line[N];
            double r = int.MaxValue;
            for(int i =0;i<a.Length; i++)
            {
                ln[i] = new Line();
                ln[i].a = a[i];
                ln[i].b = b[i];
            }

            Array.Sort(ln, Compare);

            Point[] pUpper = new Point[N + 1];
            int[] uLineNum = new int[N + 1];
            int upper = GetUpperBound(ln, pUpper, uLineNum);

            Point[] pLower = new Point[N + 1];
            int[] lLineNum = new int[N + 1];
            int lower = GetLowerBound(ln, pLower, lLineNum);

            double dy;
            for (int i = 1, j = 1; i < upper || j < lower; )
            {
                if (pUpper[i].x < pLower[j].x)
                {
                    dy = pUpper[i].y - getY(ln[lLineNum[j-1]], pUpper[i].x);
                    i++;
                }
                else
                {
                    dy = getY(ln[uLineNum[i - 1]], pLower[j].x) - pLower[j].y;
                    j++;
                }
                r = Math.Min(dy, r);
            }

            return Math.Abs(r);
        }
        public int GetUpperBound(Line[] ln, Point[] pnt, int[] lineNum)
        {
            
            int k = 0;
            pnt[k].x = -100000000;
            pnt[k].y = getY(ln[k], pnt[k].x);
            k++;

            for(int i=1; i<ln.Length; i++)
            {
                if (ln[lineNum[k - 1]].a != ln[i].a)
                {
                    pnt[k] = GetCrossPoint(ln[i], ln[lineNum[k-1]]);
                    while (k >= 2 && pnt[k].x < pnt[k-1].x)
                    {
                        if(ln[i].a != ln[lineNum[k-2]].a)
                            pnt[k-1] = GetCrossPoint(ln[i], ln[lineNum[k-2]]);
                        k--;
                    }
                    lineNum[k] = i;
                    k++;
                }
            }
            //k++;
            pnt[k].x = 100000000;
            pnt[k].y = getY(ln[k-1], pnt[k].x);
            return k;
        }
        public int GetLowerBound(Line[] ln, Point[] pnt, int[] lineNum)
        {

            int k = 0;
            pnt[k].x = -100000000;
            pnt[k].y = getY(ln[ln.Length-1], pnt[k].x);
            lineNum[0] = ln.Length - 1;
            k++;
            for (int i = ln.Length-2; i >=0; i--)
            {
                
                if (ln[lineNum[k-1]].a != ln[i].a)
                {
                    pnt[k] = GetCrossPoint(ln[i], ln[lineNum[k - 1]]);
                    while (k >= 2 && pnt[k].x < pnt[k - 1].x)
                    {
                        if(ln[i].a != ln[lineNum[k - 2]].a)
                            pnt[k - 1] = GetCrossPoint(ln[i], ln[lineNum[k - 2]]);
                        k--;
                    }
                    lineNum[k] = i;
                    k++;
                }
            }
            //k++;
            pnt[k].x = 100000000;
            pnt[k].y = getY(ln[k - 1], pnt[k].x);
            return k;
        }
        public int Compare(Line x, Line y)
        {
            Line loanX = x;
            Line loanY = y;
            if(loanX.a == loanY.a)
                return loanY.b.CompareTo(loanX.b);
            return loanX.a.CompareTo(loanY.a);
        }
        public double getY(Line l, double x)
        {
            return (x*l.a + l.b);
        }
        public Point GetCrossPoint(Line l1, Line l2)
        {
            Point p = new Point();
            p.x = ((double)l1.b - l2.b)/(l2.a - l1.a);
            p.y = getY(l2, p.x);

            return p;
        }
    }

}
