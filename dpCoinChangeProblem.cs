using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class dpCoinChangeProblem
    {
        public static void Main1()
        {
            int[] coins = new int[] { 1, 4, 3 };
            int total = 6;
            int[] dp = new int[total + 1];
            int[] usedCoinsIndexNumber = new int[total + 1];
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = int.MaxValue - 1;
            }
            dp[0] = 0;
            for (int i = 0; i < coins.Length; i++)
            {
                for (int t = 1; t < total + 1; t++)
                {
                    if (coins[i] <= t)
                    {
                        dp[t] = Math.Min(dp[t], dp[t - coins[i]] + 1);
                        usedCoinsIndexNumber[t] = i;
                    }
                }
            }
            int totalCoinsUsedForChange = dp[dp.Length - 1];
            Console.WriteLine($"{totalCoinsUsedForChange} used for making {total}");
            foreach (int c in getCoins(total, usedCoinsIndexNumber, coins))
            {
                Console.Write(" " + c);
                Console.Write(",");
            }
            Console.ReadLine();
        }

        private static List<int> getCoins(int total, int[] ar, int[] coins)
        {
            List<int> coinused = new List<int>();
            while (total > 0)
            {
                coinused.Add(coins[ar[total]]);
                total = total - coins[ar[total]];
            }
            return coinused;
        }
    }
}
