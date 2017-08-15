using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MMT_Elitmus
{
    struct TreeNode
    {
        public int startVal;
        public int endVal;
        public int max;
        public int maxLeft;
        public int maxRight;
        public bool isNice;
    }

    class SUBSGM
    {
        static TreeNode[] tree;
        static string[] vals;

        static void Main1(string[] args)
        {
            string[] f = Console.ReadLine().Split(' ');
            int N = Convert.ToInt32(f[0]);
            int M = Convert.ToInt32(f[1]);
            vals = Console.ReadLine().Split(' ');

            int x = (int)Math.Ceiling(Math.Log(N, 2));
            int max_size = 2 * (int)Math.Pow(2, x) - 1;

            tree = new TreeNode[max_size];
            Build(0, 0, N - 1);


            Console.WriteLine(tree[0].max);

            for (int q = 0; q < M; q++)
            {
                string[] newVals = Console.ReadLine().Split(' ');
                int X = Convert.ToInt32(newVals[0]);
                int Y = Convert.ToInt32(newVals[1]);

                Update(0, 0, N - 1, X - 1, Y);
                Console.WriteLine(tree[0].max);
            }
        }

        static void Build(int n, int start, int end)
        {
            if (start == end)
            {
                tree[n] = new TreeNode() { startVal = Convert.ToInt32(vals[start]), endVal = Convert.ToInt32(vals[start]), max = 1, maxLeft = 1, maxRight = 1, isNice = true };
            }
            else
            {
                int mid = (start + end) / 2;

                Build(2 * n + 1, start, mid);
                Build(2 * n + 2, mid + 1, end);

                int startValue = tree[2 * n + 1].startVal;
                int endValue = tree[2 * n + 2].endVal;
                int Lmax = 0;
                int LmaxLeft = 0;
                int LmaxRight = 0;
                bool isArrayNice = false;
                if (tree[2 * n + 2].startVal - tree[2 * n + 1].endVal == 1)
                {
                    Lmax = tree[2 * n + 1].maxRight + tree[2 * n + 2].maxLeft;
                    if (tree[2 * n + 1].isNice)
                    {
                        LmaxLeft = tree[2 * n + 1].maxRight + tree[2 * n + 2].maxLeft;
                    }
                    else
                    {
                        LmaxLeft = tree[2 * n + 1].maxLeft;
                    }
                    if (tree[2 * n + 2].isNice)
                    {
                        LmaxRight = tree[2 * n + 1].maxRight + tree[2 * n + 2].maxRight;
                    }
                    else
                    {
                        LmaxRight = tree[2 * n + 2].maxRight;
                    }

                    if (tree[2 * n + 2].isNice && tree[2 * n + 1].isNice)
                    {
                        isArrayNice = true;

                    }
                }
                else
                {
                    LmaxLeft = tree[2 * n + 1].maxLeft;
                    LmaxRight = tree[2 * n + 2].maxRight;
                }

                Lmax = Math.Max(Math.Max(tree[2 * n + 1].max, tree[2 * n + 2].max), Lmax);
                tree[n] = new TreeNode() { startVal = startValue, endVal = endValue, maxLeft = LmaxLeft, maxRight = LmaxRight, max = Lmax, isNice = isArrayNice };
            }
        }


        static void Update(int n, int start, int end, int index, int val)
        {
            if (start == end)
            {
                tree[n].startVal = val;
                tree[n].endVal = val;
                tree[n].isNice = true;
                tree[n].maxLeft = 1;
                tree[n].maxRight = 1;
                tree[n].max = 1;
            }
            else
            {
                int mid = (start + end) / 2;
                if (index <= mid)
                {
                    Update(2 * n + 1, start, mid, index, val);
                }
                else
                {
                    Update(2 * n + 2, mid + 1, end, index, val);
                }

                int startValue = tree[2 * n + 1].startVal;
                int endValue = tree[2 * n + 2].endVal;
                int Lmax = 0;
                int LmaxLeft = 0;
                int LmaxRight = 0;
                bool isArrayNice = false;
                if (tree[2 * n + 2].startVal - tree[2 * n + 1].endVal == 1)
                {
                    Lmax = tree[2 * n + 1].maxRight + tree[2 * n + 2].maxLeft;
                    if (tree[2 * n + 1].isNice)
                    {
                        LmaxLeft = tree[2 * n + 1].maxRight + tree[2 * n + 2].maxLeft;
                    }
                    else
                    {
                        LmaxLeft = tree[2 * n + 1].maxLeft;
                    }
                    if (tree[2 * n + 2].isNice)
                    {
                        LmaxRight = tree[2 * n + 1].maxRight + tree[2 * n + 2].maxRight;
                    }
                    else
                    {
                        LmaxRight = tree[2 * n + 2].maxRight;
                    }

                    if (tree[2 * n + 2].isNice && tree[2 * n + 1].isNice)
                    {
                        isArrayNice = true;

                    }
                }
                else
                {
                    LmaxLeft = tree[2 * n + 1].maxLeft;
                    LmaxRight = tree[2 * n + 2].maxRight;
                }

                Lmax = Math.Max(Math.Max(tree[2 * n + 1].max, tree[2 * n + 2].max), Lmax);
                tree[n] = new TreeNode() { startVal = startValue, endVal = endValue, maxLeft = LmaxLeft, maxRight = LmaxRight, max = Lmax, isNice = isArrayNice };

            }
        }

    }
}
