using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMT_Elitmus
{
    class SNCK01_Grundy_Theorm_
    {
        static void Main1(string[] args)
        {
            int T = Convert.ToInt32(Console.ReadLine());
            while (T > 0)
            {
                string[] matrix = Console.ReadLine().Split(' ');
                int N = Convert.ToInt32(matrix[0]);
                int M = Convert.ToInt32(matrix[1]);

                long answer = 0;

                for (int j = 1; j <= N; j++)
                {
                    string[] row = Console.ReadLine().Split(' ');
                    for (int i = row.Length - 2; i >= 0; i--)
                    {
                        if (Convert.ToInt32(row[i + 1]) >= Convert.ToInt32(row[i]))
                        {
                            row[i] = (Convert.ToInt32(row[i]) - 1).ToString();
                        }
                    }
                    answer = answer ^ Convert.ToInt32(row[0]);
                }
                if (answer == 0)
                    Console.WriteLine("SECOND");
                else
                    Console.WriteLine("FIRST");
                Console.ReadLine();
                T--;
            }
        }
    }
}
