using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// not solved
namespace MMT_Elitmus
{
    class ANUMLA
    {
        public static void Main1(string[] args)
        {
            int T = Convert.ToInt32(Console.ReadLine());
            while (T-- > 0)
            {
                int N = Convert.ToInt32(Console.ReadLine());
                List<long> nums = Console.ReadLine().Split(' ').Select(t => Convert.ToInt64(t)).ToList();

                nums = nums.OrderBy(t => t).ToList();

                if (nums.Count == 1)
                {
                    Console.WriteLine("0");
                    continue;
                }

                for (int i = 1; i <= N; i++)
                {
                    if (i == N)
                    {
                        Console.Write(nums[i] + Environment.NewLine);
                    }
                    else
                    {
                        Console.Write(nums[i] + " ");
                    }
                }

            }
        }
    }
}
