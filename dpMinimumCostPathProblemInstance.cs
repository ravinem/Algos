using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class dpMinimumCostPathProblemInstance
    {
        public static void Main1()
        {
            int[,] Cost = new int[,] { { 1, 2, 3 }, { 4, 8, 2 }, { 1, 5, 3 } };
            int[,] memo = new int[,] { { -1, -1, -1 }, { -1, -1, -1 }, { -1, -1, -1 } };
            Console.WriteLine(MinCostRecurFunc(Cost, 2, 2, memo));

            Console.ReadLine();
        }

        private static int MinCostRecurFunc(int[,] cost, int m, int n, int[,] memo)
        {
            if (m < 0 || n < 0)
            {
                return int.MaxValue;
            }
            if (m == 0 && n == 0)
            {
                return cost[m, n];
            }
            else
            {
                if (memo[m, n] != -1)
                {
                    return memo[m, n];
                }
                memo[m, n] = Math.Min(Math.Min(MinCostRecurFunc(cost, m - 1, n - 1, memo), MinCostRecurFunc(cost, m - 1, n, memo)),
                    MinCostRecurFunc(cost, m, n - 1, memo)) + cost[m, n];
                return memo[m, n];
            }
        }
    }
}
