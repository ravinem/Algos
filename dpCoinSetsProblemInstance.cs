using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class dpCoinSetsProblemInstance
    {
        public static void Main1()
        {
            int N = 4;
            int[] coins = new int[] { 1,2,3 };
            int[,] memo = new int[coins.Length, N + 1];
            for (int i = 0; i < coins.Length; i++)
            {
                for (int j = 0; j < N + 1; j++)
                {
                    memo[i, j] = -1;
                }
            }
            Console.WriteLine(NumberOfSetsToMakeSum(coins, coins.Length - 1, N, memo));
            //BottomUp(coins, N);
            Console.ReadLine();
        }

        static int NumberOfSetsToMakeSum(int[] coins, int i, int j, int[,] memo)
        {
            if (j == 0)
            {
                return 1;
            }
            if (j < 0)
            {
                return 0;
            }
            if (i < 0 && j > 0)
            {
                return 0;
            }
            if (memo[i, j] != -1)
            {
                return memo[i, j];
            }
            int value = NumberOfSetsToMakeSum(coins, i - 1, j, memo) + NumberOfSetsToMakeSum(coins, i, j - coins[i], memo);
            memo[i, j] = value;
            return value;
        }

        static void BottomUp(int[] coins, int N)
        {
            int m = N + 1;
            int n = coins.Length + 1;
            int[,] C = new int[n, m];

            for (int i = 0; i < n; i++)
            {
                C[i, 0] = 1;
            }

            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < m; j++)
                {
                    int solution = 0;
                    if (j - coins[i - 1] >= 0)
                    {
                        solution += C[i, j - coins[i - 1]];
                    }
                    C[i, j] = C[i - 1, j] + solution;
                }
            }
            Console.WriteLine(C[n - 1, m - 1]);
        }
    }
}