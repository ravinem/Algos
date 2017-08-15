using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// DP Dynamic Programming

namespace MMT_Elitmus
{
    class hr_jesse_and_profit
    {
        static List<long> arr = null;
        public static void Main1(string[] sssda)
        {
            int t = Convert.ToInt32(Console.ReadLine());
            
            while (t-- > 0)
            {
                int n = Convert.ToInt32(Console.ReadLine());
                string[] arr1 = Console.ReadLine().Split(' ');
                arr = new List<long>();
                long sumTilNow = 0;
                for (int i = 0; i < arr1.Length; i++)
                {
                    sumTilNow += Convert.ToInt64(arr1[i]);
                    arr.Add(sumTilNow);
                }
                int ans = Solve(0, arr.Count - 1);
                Console.WriteLine(ans);
            }          
            

        }

        static int Solve(int startIndex,int EndIndex)
        {
            for (int x = startIndex; x < EndIndex; x++)
            {
                long lastEle = 0;
                if (startIndex != 0)
                    lastEle = arr[startIndex - 1];

                if ((arr[x] - lastEle) * 2 == arr[EndIndex] - lastEle)
                {
                    return Math.Max(Solve(startIndex, x), Solve(x + 1, EndIndex)) + 1;
                }
            }
            return 0;
        }

        static long Log_Exponential(long val, long pow, long modulo)
        {
            if (pow < 0)
            {
                return Log_Exponential(1 / val, -pow, modulo) % modulo;
            }
            if (pow == 0)
                return 1;
            if (pow % 2 == 0)
            {
                return Log_Exponential(((val % modulo) * (val % modulo)) % modulo, pow / 2, modulo) % modulo;
            }
            else
            {
                return (val % modulo) * Log_Exponential(((val % modulo) * (val % modulo)) % modulo, (pow - 1) / 2, modulo) % modulo;
            }
        }

    }
}
