using System;
using System.Collections.Generic;
using System.Linq;

// 4k ^ (4k+1) ^ (4k+2) ^ (4k+3) = 0

namespace MMT_Elitmus
{
    class hr_ann_jimmy
    {
        static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());
            int nums = t;
            List<int> homes = new List<int>();
            List<int> aways = new List<int>();
            while (t-- > 0)
            {                
                string[] dd = Console.ReadLine().Split(' ');
                homes.Add(Convert.ToInt32(dd[0]));
                aways.Add(Convert.ToInt32(dd[1]));
            }
            for (int i = 0; i < nums; i++)
            {
                int ans = 0;
                for (int j = 0; j < nums; j++)
                {
                    if (i != j)
                    {
                        if (aways[i] == homes[j])
                        {
                            ans++;                        
                        }
                    }
                }
                Console.WriteLine(((nums - 1) + ans) + " " + ((nums - 1) - ans));
            }
        }
    }
}
