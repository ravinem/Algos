using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// NOT SOLVED

namespace MMT_Elitmus
{
    class POUR1
    {
        static void Main1(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());
            while (t-- > 0)
            {
                int a = Convert.ToInt32(Console.ReadLine());
                int b = Convert.ToInt32(Console.ReadLine());
                int c = Convert.ToInt32(Console.ReadLine());


                if ((c > a && c > b) || (a == b && a != c) || (c % GCD(a, b) != 0))
                {
                    Console.WriteLine(-1);
                     continue;
                }
                else if (c == a || c == b)
                {
                    Console.WriteLine(1);
                    continue;
                }
                else
                {
                    // first try filling a jug
                    int fSteps = numSteps(a, b, c);
                    // second try filling a jug
                    int sSteps = numSteps(b, a, c);


                    Console.WriteLine(Math.Min(fSteps, sSteps));
                }

                //int l = Math.Max(a, b);
                //int s = Math.Min(a, b);

                //int lastQ = 0;
                //int lastx = 1;
                //int lasty = 0;
                //int x = 0;
                //int y = 1;
                //int lastR = 0;
                //while (l % s != 0)
                //{
                //    lastR = l % s;
                //    lastQ = l / s;

                //    var m = l;

                //    l = Math.Max(m % s, s);
                //    s = Math.Min(m % s, s);

                //    int tempS = x;
                //    int tempT = y;
                //    x = lastx - (lastQ * x);
                //    y = lasty - (lastQ * y);

                //    lastx = tempS;
                //    lasty = tempT;
                //}

                //int k = c / GCD(a, b);
                //x = x * k;
                //y = y * k;

                //if (x < 0)
                //    x = -1 * x;
                //if (y < 0)
                //    y = -1 * y;
                //Console.WriteLine(x + y);
            }
        }

        static int GCD(int a, int b)
        {
            int l = Math.Max(a, b);
            int s = Math.Min(a, b);
            int gcd = a;
            while (l % s != 0)
            {
                gcd = l % s;
                var t = l;
                l = Math.Max(t % s, s);
                s = Math.Min(t % s, s);
            }
            return gcd;
        }

        public static int numSteps(int a, int b, int c)
        {
            int j1 = 0, j2 = 0, num = 0;
            while (true)
            {
                if (j1 == c || j2 == c)
                {
                    return num;
                }
                else if (j1 == 0)
                {
                    j1 = a;
                    num++;
                }
                else if (j2 == b)
                {
                    j2 = 0;
                    num++;
                }
                else if (j1 != 0)
                {
                    int temp = j1;
                    j1 = Math.Max(j2 + j1 - b, 0);
                    j2 = Math.Min(j2 + temp, b);
                    num++;
                }
            }
        }
    }
}
