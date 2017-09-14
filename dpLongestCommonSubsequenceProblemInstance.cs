using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class dpLongestCommonSubsequenceProblemInstance
    {
        public static void Main1()
        {
            string a = "AGGTAB";
            string b = "GXTXAYB"; 

            string[] x = a.ToCharArray().Select(t => t.ToString()).ToArray();
            string[] y = b.ToCharArray().Select(t => t.ToString()).ToArray();

            int m = x.Length;
            int n = y.Length;
            int[,] C = new int[n + 1, m + 1];

            for (int i = 1; i < n + 1; i++)
            {
                for (int j = 1; j < m + 1; j++)
                {
                    if (x[j - 1] == y[i - 1])
                    {
                        C[i, j] = C[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        C[i, j] = Math.Max(C[i - 1, j], C[i, j - 1]);
                    }
                }
            }
            Console.WriteLine(C[n, m]);
            int r = n;
            int c = m;
            string answer = "";
            while (r > 0 && c > 0)
            {
                if (x[c - 1] == y[r - 1])
                {
                    answer += x[c - 1];
                }
                int lessr = C[r - 1, c];
                int lessc = C[r, c - 1];
                int lessb = C[r - 1, c - 1];
                if (lessb >= Math.Max(lessr, lessc))
                {
                    r--;
                    c--;
                }
                else if (lessr >= lessc)
                {
                    r--;
                }
                else
                {
                    c--;
                }
            }
            string final = "";
            for (int l = answer.Length - 1; l >= 0; l--)
            {
                final += answer[l].ToString();
            }
            Console.WriteLine(final);
            Console.ReadLine();
        }
    }
}
