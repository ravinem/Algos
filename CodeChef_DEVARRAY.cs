using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMT_Elitmus
{
    class CodeChef_DEVARRAY
    {
        static void Main3(string[] dd)
        {
            string[] line = Console.ReadLine().Split(' ');
            int arrLen = Convert.ToInt32(line[0]);
            int queryLen = Convert.ToInt32(line[1]);

            string[] arr = Console.ReadLine().Split(' ');
            int minNum = Convert.ToInt32(arr[0]);
            int maxNum = Convert.ToInt32(arr[0]);

            foreach (var s in arr)
            {
                if (Convert.ToInt32(s) < minNum)
                {
                    minNum = Convert.ToInt32(s);
                }
                else if (Convert.ToInt32(s) > maxNum)
                {
                    maxNum = Convert.ToInt32(s);
                }
            }

            while (queryLen > 0)
            {
                int t = Convert.ToInt32(Console.ReadLine());
                if (t >= minNum && t <= maxNum)
                {
                    Console.WriteLine("Yes");
                }
                else
                {
                    Console.WriteLine("No");
                }
                queryLen--;
            }

        }
    }
}
