using System;
using System.Collections.Generic;
using System.Linq;


//Not solved
namespace MMT_Elitmus
{
    class he_shino_coins
    {
        static void Main1(string[] args)
        {
            int k = Convert.ToInt32(Console.ReadLine());
            string line = Console.ReadLine();
            long ans = 0;
            List<shinoNode> lst = new List<shinoNode>();
            for (int i = 0; i < line.Length; i++)
            {
                lst.Add(new shinoNode());
                int lasti= i-1;
                if(i==0)
                    lasti = 0;
                switch (line[i])
                { 
                    case 'a':
                        lst[i].a = lst[lasti].a + 1;
                        if (lst[i].a == 1)
                        {
                            lst[i].totalDistinct += 1;
                        }
                        break;
                    case 'b':
                        lst[i].b = lst[lasti].b + 1;
                        if (lst[i].b == 1)
                        {
                            lst[i].totalDistinct += 1;
                        }
                        break;
                    case 'c':
                        lst[i].c = lst[lasti].c + 1;
                        if (lst[i].c == 1)
                        {
                            lst[i].totalDistinct += 1;
                        }
                        break;
                    case 'd':
                        lst[i].d = lst[lasti].d + 1;
                        if (lst[i].d == 1)
                        {
                            lst[i].totalDistinct += 1;
                        }
                        break;
                    case 'e':
                        lst[i].e = lst[lasti].e + 1;
                        if (lst[i].e == 1)
                        {
                            lst[i].totalDistinct += 1;
                        }
                        break;
                    case 'f':
                        lst[i].f = lst[lasti].f + 1;
                        if (lst[i].f == 1)
                        {
                            lst[i].totalDistinct += 1;
                        }
                        break;
                    case 'g':
                        lst[i].g = lst[lasti].g + 1;
                        if (lst[i].g == 1)
                        {
                            lst[i].totalDistinct += 1;
                        }
                        break;
                    case 'h':
                        lst[i].h = lst[lasti].h + 1;
                        if (lst[i].h == 1)
                        {
                            lst[i].totalDistinct += 1;
                        }
                        break;
                    case 'i':
                        lst[i].i = lst[lasti].i + 1;
                        if (lst[i].i == 1)
                        {
                            lst[i].totalDistinct += 1;
                        }
                        break;
                    case 'j':
                        lst[i].j = lst[lasti].j + 1;
                        if (lst[i].j == 1)
                        {
                            lst[i].totalDistinct += 1;
                        }
                        break;
                    case 'k':
                        lst[i].k = lst[lasti].k + 1;
                        if (lst[i].k == 1)
                        {
                            lst[i].totalDistinct += 1;
                        }
                        break;
                    case 'l':
                        lst[i].l = lst[lasti].l + 1;
                        if (lst[i].l == 1)
                        {
                            lst[i].totalDistinct += 1;
                        }
                        break;
                    case 'm':
                        lst[i].m = lst[lasti].m + 1;
                        if (lst[i].m == 1)
                        {
                            lst[i].totalDistinct += 1;
                        }
                        break;
                    case 'n':
                        lst[i].n = lst[lasti].n + 1;
                        if (lst[i].n == 1)
                        {
                            lst[i].totalDistinct += 1;
                        }
                        break;
                    case 'o':
                        lst[i].o = lst[lasti].o + 1;
                        if (lst[i].o == 1)
                        {
                            lst[i].totalDistinct += 1;
                        }
                        break;
                    case 'p':
                        lst[i].p = lst[lasti].p + 1;
                        if (lst[i].p == 1)
                        {
                            lst[i].totalDistinct += 1;
                        }
                        break;
                    case 'q':
                        lst[i].q = lst[lasti].q + 1;
                        if (lst[i].q == 1)
                        {
                            lst[i].totalDistinct += 1;
                        }
                        break;
                    case 'r':
                        lst[i].r = lst[lasti].r + 1;
                        if (lst[i].r == 1)
                        {
                            lst[i].totalDistinct += 1;
                        }
                        break;
                    case 's':
                        lst[i].s = lst[lasti].s + 1;
                        if (lst[i].s == 1)
                        {
                            lst[i].totalDistinct += 1;
                        }
                        break;
                    case 't':
                        lst[i].t = lst[lasti].t + 1;
                        if (lst[i].t == 1)
                        {
                            lst[i].totalDistinct += 1;
                        }
                        break;
                    case 'u':
                        lst[i].u = lst[lasti].u + 1;
                        if (lst[i].u == 1)
                        {
                            lst[i].totalDistinct += 1;
                        }
                        break;
                    case 'v':
                        lst[i].v = lst[lasti].v + 1;
                        if (lst[i].v == 1)
                        {
                            lst[i].totalDistinct += 1;
                        }
                        break;
                    case 'w':
                        lst[i].w = lst[lasti].w + 1;
                        if (lst[i].w == 1)
                        {
                            lst[i].totalDistinct += 1;
                        }
                        break;
                    case 'x':
                        lst[i].x = lst[lasti].x + 1;
                        if (lst[i].x == 1)
                        {
                            lst[i].totalDistinct += 1;
                        }
                        break;
                    case 'y':
                        lst[i].y = lst[lasti].y + 1;
                        if (lst[i].y == 1)
                        {
                            lst[i].totalDistinct += 1;
                        }
                        break;
                    case 'z':
                        lst[i].z = lst[lasti].z + 1;
                        if (lst[i].z == 1)
                        {
                            lst[i].totalDistinct += 1;
                        }
                        break;
                }
            }
            //abcaa
            for (int i = 0; i < line.Length - 1; i++)
            {
                for (int j = i + k - 1; j < line.Length; j++)
                {
                    char item = line[i];
                    
                }
            }
            Console.WriteLine(ans);
        }
    }

    public class shinoNode
    {
        public int a;
        public int b;
        public int c;
        public int d;
        public int e;
        public int f;
        public int g;
        public int h;
        public int i;
        public int j;
        public int k;
        public int l;
        public int m;
        public int n;
        public int o;
        public int p;
        public int q;
        public int r;
        public int s;
        public int t;
        public int u;
        public int v;
        public int w;
        public int x;
        public int y;
        public int z;
        public int totalDistinct;
    }
}
