using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMT_Elitmus
{
    class TAAND
    {
        static void Main1(string[] args)
        {
            int N = Convert.ToInt32(Console.ReadLine());
            int[] nums = new int[N];
            int i = 0;
         

            while (i < N)
            {
                nums[i] = Convert.ToInt32(Console.ReadLine());
                i++;
            }

            nums = nums.OrderByDescending(t => t).ToArray();
            int answer = -1;
            bool found = false;
            int lastmax = -1;
            for (int y = 0; y < nums.Length -1; y++)
            {
                for (int u = y + 1; u < nums.Length ; u++)
                {
                    if (u == nums.Length - 1)
                    {
                        if ((nums[y] & nums[u]) > lastmax)
                        {
                            lastmax = (nums[y] & nums[u]);
                        }
                    }
                    else if ((nums[y] & nums[u]) >= nums[u + 1])
                    {
                        answer = nums[y] & nums[u];
                        found = true;
                        break;
                    }
                    else if ((nums[y] & nums[u]) > lastmax)
                    {
                        lastmax = (nums[y] & nums[u]);
                    }
                }
                if (found)
                    break;
            }

            if (!found)
            {
                Console.WriteLine(lastmax);
            }
            else
            {
                Console.WriteLine(answer);
            }

        }
    }
}
