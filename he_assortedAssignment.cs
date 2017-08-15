using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMT_Elitmus
{
    class he_assortedAssignment
    {
        static void Main1(string[] args)
        {

            string[] nms = Console.ReadLine().Split(' ');
            int N = Convert.ToInt32(nms[0]);
            int M = Convert.ToInt32(nms[1]);

            string[] c = Console.ReadLine().Split(' ');

            List<long> nums = new List<long>();

            long lastVal = 1;
            for (int i = 0; i < M; i++)
            {
                lastVal = lastVal * Convert.ToInt64(c[i]);
                nums.Add(lastVal);
            }

            string[] vals = Console.ReadLine().Split(' ');
            List<long> dhs = new List<long>();

            long lastnum = 0;

            for (int i = 0; i < N; i++)
            {
                int val = Convert.ToInt32(vals[i]);
                int index = val - 1;

                // start with lastnum
                long shouldDivideBy = 0;
                if (index > 0)
                    shouldDivideBy = nums[index] / nums[index - 1];
                else
                    shouldDivideBy = nums[index];

                long shouldNotDivideBy = nums[nums.Count - 1] / nums[index];

                long start = lastnum + (shouldDivideBy - (lastnum % shouldDivideBy));
                long shouldBeLessThen;
                if (index + 1 < M)
                { 
                    shouldBeLessThen = Convert.ToInt64(c[index + 1]);
                }
                else
                {
                    shouldBeLessThen = Convert.ToInt64(c[index]);
                }

                for (long j = start; ; j = j + shouldDivideBy)
                {
                    long gcd = GCD(j, shouldNotDivideBy);
                    if (gcd == 1 || gcd < shouldBeLessThen)
                    {
                        lastnum = j;
                       dhs.Add(lastnum);
                        break;
                    }
                }
            }

            Console.WriteLine(lastnum);
        }

        static long GCD(long a, long b)
        {
            if (b == 0)
                return a;
            return GCD(b, a % b);
        }
    }
}
