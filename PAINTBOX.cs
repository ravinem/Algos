
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Not Solved : Solved but how?

namespace MMT_Elitmus
{
    class PAINTBOX
    {
        static paintNode[] tree;
        static int W;
        static string[] vals;
        struct paintNode
        {
            public int ans;
            public int maxLeft;
            public int maxRight;
            public int rightElement;
            public int leftElement;
            public bool isTrue;
        }
        static void Main1(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());
            while (t-- > 0)
            {
                string hj = Console.ReadLine();
                string[] nw = hj.Split(' ');
                int N = Convert.ToInt32(nw[0]);
                W = Convert.ToInt32(nw[1]);
                string hjk = Console.ReadLine();
                vals = hjk.Split(' ');

                int h = (int)Math.Ceiling(Math.Log(N, 2));
                int maxSize = 2 * (int)Math.Pow(2, h) - 1;
                tree = new paintNode[maxSize];
                build(0, 0, N - 1);
                // Console.WriteLine(vals.Length);

                int q = Convert.ToInt32(Console.ReadLine());
                while (q-- > 0)
                {
                    string[] pc = Console.ReadLine().Split(' ');
                    int p = Convert.ToInt32(pc[0]);
                    int c = Convert.ToInt32(pc[1]);
                    if (W == 1)
                    {
                        Console.WriteLine(vals.Length);
                    }
                    else
                    {
                        update(0, 0, N - 1, p - 1, c);
                        Console.WriteLine(tree[0].ans);
                    }
                }
            }
        }

        static void build(int n, int start, int end)
        {
            if (start == end)
            {
                tree[n].maxLeft = 1;
                tree[n].maxRight = 1;
                tree[n].rightElement = Convert.ToInt32(vals[start]);
                tree[n].leftElement = Convert.ToInt32(vals[start]);
                if (W == 1)
                {
                    tree[n].ans = 1;
                }
                tree[n].isTrue = true;
            }
            else
            {
                int mid = (start + end) / 2;
                build(2 * n + 1, start, mid);
                build(2 * n + 2, mid + 1, end);
                prepareParentNode(n);
            }
        }

        static void update(int n, int start, int end, int index, int val)
        {
            if (start == end)
            {
                tree[n].rightElement = val;
                tree[n].leftElement = val;
                tree[n].maxLeft = 1;
                tree[n].maxRight = 1;
                if (W == 1)
                {
                    tree[n].ans = 1;
                }
                tree[n].isTrue = true;
            }
            else
            {
                int mid = (start + end) / 2;
                if (index <= mid)
                    update(2 * n + 1, start, mid, index, val);
                else
                    update(2 * n + 2, mid + 1, end, index, val);
                prepareParentNode(n);
            }
        }

        static void prepareParentNode(int n)
        {
            tree[n].rightElement = tree[2 * n + 2].rightElement;
            tree[n].leftElement = tree[2 * n + 1].leftElement;

            if (tree[2 * n + 1].rightElement == tree[2 * n + 2].leftElement)
            {

                if (tree[2 * n + 1].isTrue && tree[2 * n + 2].isTrue)
                {
                    tree[n].maxLeft = tree[2 * n + 1].maxRight + tree[2 * n + 2].maxLeft;
                    tree[n].maxRight = tree[2 * n + 1].maxLeft + tree[2 * n + 2].maxLeft;
                    int answ = 0;
                    if (tree[n].maxLeft >= W)
                    {
                        answ = tree[n].maxLeft - W + 1;
                    }
                    tree[n].ans = answ;
                    tree[n].isTrue = true;
                }
                else
                {
                    if (tree[2 * n + 1].isTrue)
                    {
                        tree[n].maxLeft = tree[2 * n + 1].maxLeft + tree[2 * n + 2].maxLeft;
                        tree[n].maxRight = tree[2 * n + 2].maxRight;
                       
                        tree[n].isTrue = false;
                    }
                    else if (tree[2 * n + 2].isTrue)
                    {
                        tree[n].maxRight = tree[2 * n + 2].maxRight + tree[2 * n + 1].maxRight;
                        tree[n].maxLeft = tree[2 * n + 1].maxLeft;
                     
                        tree[n].isTrue = false;
                    }
                    else
                    {
                        tree[n].maxLeft = tree[2 * n + 1].maxLeft;
                        tree[n].maxRight = tree[2 * n + 2].maxRight;
                       
                        tree[n].isTrue = false;

                      
                    }
                    int ans = tree[2 * n + 1].ans + tree[2 * n + 2].ans;
                    int temp1 = tree[2 * n + 1].maxRight;
                    int temp2 = tree[2 * n + 2].maxLeft;
                    if (temp1 + temp2 >= W)
                    {
                        ans = ans + (temp1 + temp2 - W + 1);
                    }
                    if (temp1 >= W)
                    {
                        ans = ans - (temp1 - W + 1);
                    }
                    if (temp2 >= W)
                    {
                        ans = ans - (temp2 - W + 1);
                    }
                    tree[n].ans = ans;
                   
                }
            }
            else
            {
                tree[n].maxLeft = tree[2 * n + 1].maxLeft;
                tree[n].maxRight = tree[2 * n + 2].maxRight;
                tree[n].ans = tree[2 * n + 1].ans + tree[2 * n + 2].ans;
                tree[n].isTrue = false;
            }
        }

    }
}
