using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMT_Elitmus
{
    class SWEGIRL
    {
        struct Node
        {
            public int Os;
            public int Xs;
            public int minIndexO;
            public int maxIndexX;
            public int startIndex;
            public int endIndex;
        }

        static string input = "";
        static Node[] tree;
        static string[] lazy;
        static List<int> mapArrayTree = new List<int>();
        static void Main1(string[] rgs)
        {
            int t = Convert.ToInt32(Console.ReadLine());
            while (t-- > 0)
            {
                mapArrayTree = new List<int>();
                input = Console.ReadLine();
                int h = (int)Math.Ceiling(Math.Log(input.Length, 2));
                int max_size = 2 * (int)Math.Pow(2, h) - 1;
                tree = new Node[max_size];
                lazy = new string[max_size];
                int k = Convert.ToInt32(Console.ReadLine());//hd.Next(50, 100);
                Build(0, 0, input.Length - 1);

                for (int K = 0; K < k; K++)
                {
                    string[] dd = Console.ReadLine().Split(' ');
                    if (dd[0] == "1")
                    {
                        Update(0, 0, input.Length - 1, Convert.ToInt32(dd[1]) - 1, Convert.ToInt32(dd[2]) - 1, "X");
                    }
                    else
                    {
                        Update(0, 0, input.Length - 1, Convert.ToInt32(dd[1]) - 1, Convert.ToInt32(dd[2]) - 1, "O");
                    }
                }
                Clear(0, 0, input.Length - 1);
                Query(input.Length);
            }
        }

        static void Build(int n, int start, int end)
        {
            if (start == end)
            {
                int LastX = 0;
                int os = 0;
                int xs = 0;
                int FirstO = int.MaxValue;
                if (input[start] == 'O')
                {
                    os = 1;
                    FirstO = start;
                }
                else
                {
                    LastX = start;
                    xs = 1;
                }

                tree[n].Xs = xs; tree[n].Os = os; tree[n].startIndex = start; tree[n].endIndex = start; tree[n].maxIndexX = LastX; tree[n].minIndexO = FirstO;
                mapArrayTree.Add(n);
            }
            else
            {
                int mid = (start + end) / 2;
                Build(2 * n + 1, start, mid);
                Build(2 * n + 2, mid + 1, end);

                int startInd = tree[2 * n + 1].startIndex;
                int endInd = tree[2 * n + 2].endIndex;

                int LastX = Math.Max(tree[2 * n + 1].maxIndexX, tree[2 * n + 2].maxIndexX);
                int FirstO = Math.Min(tree[2 * n + 1].minIndexO, tree[2 * n + 2].minIndexO);

                int xs = (tree[2 * n + 1].Xs + tree[2 * n + 2].Xs);
                int os = (tree[2 * n + 1].Os + tree[2 * n + 2].Os);

                tree[n].Xs = xs; tree[n].Os = os; tree[n].startIndex = startInd; tree[n].endIndex = endInd; tree[n].maxIndexX = LastX; tree[n].minIndexO = FirstO;

            }
        }

        static void Update(int n, int start, int end, int l, int r, string val)
        {
            if (lazy[n] != null)
            {
                int FirstO = int.MaxValue;
                int LastX = 0;
                int os = 0;
                int xs = 0;
                if (lazy[n] == "O")
                {
                    os =  tree[n].endIndex - tree[n].startIndex + 1;
                    FirstO = start;
                }
                else
                {
                    LastX = end;
                    xs =  tree[n].endIndex - tree[n].startIndex + 1;
                }

                tree[n].Xs = xs; tree[n].Os = os; tree[n].maxIndexX = LastX; tree[n].minIndexO = FirstO;
                if (start != end)
                {
                    lazy[2 * n + 1] = lazy[n];
                    lazy[2 * n + 2] = lazy[n];
                }
                lazy[n] = null;
            }

            if (end < start)
                return;

            if (l > end || r < start)
                return;

            if (l <= start && end <= r)
           // if(start == end)
            {
                int FirstO = int.MaxValue;
                int LastX = 0;
                int os = 0;
                int xs = 0;
                if (val == "O")
                {
                    os = tree[n].endIndex - tree[n].startIndex + 1;
                    FirstO = start;
                }
                else
                {
                    LastX = end;
                    xs =  tree[n].endIndex - tree[n].startIndex + 1;
                }

                tree[n].Xs = xs; tree[n].Os = os; tree[n].maxIndexX = LastX; tree[n].minIndexO = FirstO;

                if (start != end)
                {
                    lazy[2 * n + 1] = val;
                    lazy[2 * n + 2] = val;
                }

            }
            else
            {
                int mid = (start + end) / 2;
                Update(2 * n + 1, start, mid, l, r, val);
                Update(2 * n + 2, mid + 1, end, l, r, val);

                int LastX = Math.Max(tree[2 * n + 1].maxIndexX, tree[2 * n + 2].maxIndexX);
                int FirstO = Math.Min(tree[2 * n + 1].minIndexO, tree[2 * n + 2].minIndexO);

                int xs = (tree[2 * n + 1].Xs + tree[2 * n + 2].Xs);
                int os = (tree[2 * n + 1].Os + tree[2 * n + 2].Os);

                tree[n].Xs = xs; tree[n].Os = os;  tree[n].maxIndexX = LastX; tree[n].minIndexO = FirstO;
            }
        }

        static void Clear(int n, int start, int end)
        {
            if (lazy[n] != null)
            {
                int FirstO = int.MaxValue;
                int LastX = 0;
                int os = 0;
                int xs = 0;
                if (lazy[n] == "O")
                {
                    os = tree[n].endIndex - tree[n].startIndex + 1;
                    FirstO = start;
                }
                else
                {
                    LastX = end;
                    xs = tree[n].endIndex - tree[n].startIndex + 1;
                }

                tree[n].Xs = xs; tree[n].Os = os; tree[n].maxIndexX = LastX; tree[n].minIndexO = FirstO;
                if (start != end)
                {
                    lazy[2 * n + 1] = lazy[n];
                    lazy[2 * n + 2] = lazy[n];
                }
                lazy[n] = null;
            }
            if (start == end)
            {
                return;
            }
            else
            {
                int mid = (start + end) / 2;
                Clear(2 * n + 1, start, mid);
                Clear(2 * n + 2, mid + 1, end);
            }
        }

        static void Query(int len)
        {
            int OsBeforeLastX = Math.Max(0, tree[0].Os - ((len - tree[0].maxIndexX)));
            if (tree[0].minIndexO == int.MaxValue)
            {
                tree[0].minIndexO = 0;
            }
            int XsAfterFirstO = tree[0].Xs - tree[0].minIndexO;
            int ans=0;
            int bestAns = int.MaxValue;
            for (int j = tree[0].minIndexO; j <= tree[0].maxIndexX; j++)
            {
                int index = mapArrayTree[j];
                if (tree[index].Os == 1)
                {
                    bestAns = Math.Min(bestAns, ans +XsAfterFirstO);
                    ans++;
                    OsBeforeLastX--;
                }
                else
                {
                    bestAns = Math.Min(bestAns, ans + XsAfterFirstO);
                   
                    XsAfterFirstO--;
                }
            }
            Console.WriteLine(Math.Min(bestAns,ans));
        }
    }
}
