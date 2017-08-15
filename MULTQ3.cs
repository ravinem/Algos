using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMT_Elitmus
{
    struct Node
    {
        public int z;
        public int o;
        public int t;
    }

    class MULTQ3
    {

        static Node[] SegmentTree;

        static int[] lazy;
        static void Main1(string[] args)
        {

            string[] f = Console.ReadLine().Split(' ');
            int N = Convert.ToInt32(f[0]);
            int Q = Convert.ToInt32(f[1]);

            int x = (int)Math.Ceiling(Math.Log(N, 2));
            int max_size = 2 * (int)Math.Pow(2, x) - 1;
            // 262140
            SegmentTree = new Node[max_size];
            lazy = new int[max_size];

            BuildSegmentTree(0, 0, N - 1);
       

            while (Q-- > 0)
            {
                string hj = "";
                
                hj = Console.ReadLine();

                string[] q = hj.Split(' ');
                if (q[0] == "1")
                {
                    int start = Convert.ToInt32(q[1]);
                    int end = Convert.ToInt32(q[2]);

                    int answer = query(0, 0, N - 1, start, end).z;

                    Console.Write(answer);
                    Console.Write('\n');
                }
                else
                {
                    int start = Convert.ToInt32(q[1]);
                    int end = Convert.ToInt32(q[2]);

                    update(0, 0, N - 1, start, end, 1);
                }
            }
        }

        static void BuildSegmentTree(int node, int start, int end)
        {
            if (start == end)
            {
                SegmentTree[node] = new Node() { z = 1 };
            }
            else
            {
                int mid = (start + end) / 2;
                BuildSegmentTree(node * 2 + 1, start, mid);
                BuildSegmentTree(node * 2 + 2, mid + 1, end);
                int Z = SegmentTree[node * 2 + 1].z + SegmentTree[node * 2 + 2].z;
                int O = SegmentTree[node * 2 + 1].o + SegmentTree[node * 2 + 2].o;
                int T = SegmentTree[node * 2 + 1].t + SegmentTree[node * 2 + 2].t;
                SegmentTree[node] = new Node() { z = Z, o = O, t = T };
            }
        }

        static void update(int node, int start, int end, int l, int r, int val)
        {
            if (lazy[node] != 0)
            {
                int increments = lazy[node];
                int rem = increments % 3;
                if (rem == 1)
                {
                    int Z = SegmentTree[node].t;
                    int O = SegmentTree[node].z;
                    int T = SegmentTree[node].o;
                    SegmentTree[node] = new Node() { z = Z, o = O, t = T };
                }
                if (rem == 2)
                {
                    int Z = SegmentTree[node].o;
                    int O = SegmentTree[node].t;
                    int T = SegmentTree[node].z;
                    SegmentTree[node] = new Node() { z = Z, o = O, t = T };
                }

                if (start != end)
                {
                    lazy[2 * node + 1] += increments;
                    lazy[2 * node + 2] += increments;
                }

                lazy[node] = 0;
            }
            if (start > end || start > r || end < l)
                return;

            if (l <= start && r >= end)
            {
                int Z = SegmentTree[node].t;
                int O = SegmentTree[node].z;
                int T = SegmentTree[node].o;

                SegmentTree[node] = new Node() { z = Z, o = O, t = T };
                if (start != end)
                {
                    // how many nodes are getting hit...
                    lazy[node * 2 + 1] += val;
                    lazy[node * 2 + 2] += val;
                }
                return;

            }

            int mid = (start + end) / 2;

            update(node * 2 + 1, start, mid, l, r, val);
            update(node * 2 + 2, mid + 1, end, l, r, val);

            int ZZ = SegmentTree[node * 2 + 1].z + SegmentTree[node * 2 + 2].z;
            int OO = SegmentTree[node * 2 + 1].o + SegmentTree[node * 2 + 2].o;
            int TT = SegmentTree[node * 2 + 1].t + SegmentTree[node * 2 + 2].t;
            SegmentTree[node].z = ZZ;
            SegmentTree[node].o = OO;
            SegmentTree[node].t = TT;
        }

        static Node query(int node, int start, int end, int l, int r)
        {

            if (lazy[node] != 0)
            {
                int increments = lazy[node];
                int rem = increments % 3;
                if (rem == 1)
                {
                    int Z = SegmentTree[node].t;
                    int O = SegmentTree[node].z;
                    int T = SegmentTree[node].o;
                    SegmentTree[node] = new Node() { z = Z, o = O, t = T };
                }
                if (rem == 2)
                {
                    int Z = SegmentTree[node].o;
                    int O = SegmentTree[node].t;
                    int T = SegmentTree[node].z;
                    SegmentTree[node] = new Node() { z = Z, o = O, t = T };
                }

                if (start != end)
                {
                    lazy[2 * node + 1] += lazy[node];
                    lazy[2 * node + 2] += lazy[node];
                }

                lazy[node] = 0;
            }

            if (start > end || start > r || end < l)
                return new Node();

            if (l <= start && end <= r)
            {
                return SegmentTree[node];
            }
            else
            {
                int mid = (start + end) / 2;
                Node p1 = query(node * 2 + 1, start, mid, l, r);
                Node p2 = query(node * 2 + 2, mid + 1, end, l, r);

                int Z = p1.z + p2.z;
                int O = p1.o + p2.o;
                int T = p1.t + p2.t;
                return new Node() { z = Z, t = T, o = O };
            }
        }
    }
}