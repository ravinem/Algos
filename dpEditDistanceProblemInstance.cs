using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class dpEditDistanceProblemInstance
    {
        public static void Main1()
        {
            string a = "atcat";
            string b = "attatc";

            string[] x = a.ToCharArray().Select(t => t.ToString()).ToArray();
            string[] y = b.ToCharArray().Select(t => t.ToString()).ToArray();

            int m = x.Length;
            int n = y.Length;

            int[,] C = new int[n + 1, m + 1];
            for (int i = 0; i < m + 1; i++)
            {
                C[0, i] = i;
            }
            for (int i = 0; i < n + 1; i++)
            {
                C[i, 0] = i;
            }

            for (int i = 1; i < n + 1; i++)
            {
                for (int j = 1; j < m + 1; j++)
                {
                    if (x[j - 1] == y[i - 1] && i == j)
                    {
                        C[i, j] = C[i - 1, j - 1];
                    }
                    else if (x[j - 1] == y[i - 1] && i != j)
                    {
                        C[i, j] = Math.Min(Math.Min(C[i - 1, j - 1], C[i - 1, j]), C[i, j - 1]);
                    }
                    else
                    {
                        C[i, j] = Math.Min(Math.Min(C[i - 1, j - 1], C[i - 1, j]), C[i, j - 1]) + 1;
                    }
                }
            }

            Console.WriteLine(C[n, m]);
            Console.ReadLine();
        }
    }
}
