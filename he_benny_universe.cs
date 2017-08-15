using System;
using System.Collections.Generic;
using System.Linq;

// not solved
namespace MMT_Elitmus
{
    class he_benny_universe
    {
        static List<long> line;
        static int indexToStart;
        static void Main1(string[] sasa)
        {
            string[] Nas = Console.ReadLine().Split(' ');
            int N = Convert.ToInt32(Nas[0]);
            int Q = Convert.ToInt32(Nas[1]);
            string dds = Console.ReadLine();
            line = dds.Split(new string[] { " ", "  ", "   ", "    ", "     ", "      ", "       ", "        ", "         ", "          " }, StringSplitOptions.RemoveEmptyEntries).Select(t => Convert.ToInt64(t)).ToList();
            line = line.OrderBy(t => t).ToList();
            int cnt = line.Count - 1;
            while (Q-- > 0)
            {
                long item = Convert.ToInt64(Console.ReadLine());
                int indStat = binarySearch(item,0,cnt);
                bool found = false;
                for (int j = indStat; j >= 0; j--)
                {
                    if (item % line[j] == 0)
                    {
                        Console.WriteLine("YES");
                        found = true;
                        break;
                    }
                    else
                    {
                        item = item % line[j];
                    }
                    for (int k = j - 1; k >= 0; k--)
                    {
                        if (item < line[k])
                            continue;
                        else
                        {
                            item = item % line[j];
                        }
                    }
                }
                if (!found)
                    Console.WriteLine("NO");
            }
        }

        // 5 8 11 : 11

        static int binarySearch(long val,int start,int end)
        {
            if (end < start)
                return -1;

            if (start == end)
            {
                indexToStart = start;
                return start;
            }

            int mid = (start + end) / 2;

            if (line[mid] == val)
            {
                indexToStart = mid;
                return mid;
            }

            if (line[mid] < val && line[mid + 1] > val)
            {
                indexToStart = mid;
                return mid;
            }

            if (line[mid] > val)
            {
                return binarySearch(val, mid + 1, end);
            }
            else
            {
                return binarySearch(val, start, mid);
            }
        }
    }
}
