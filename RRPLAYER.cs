using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMT_Elitmus
{
    class RRPLAYER
    {
        static void Main1(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());
            while (t-- > 0)
            {
                int n = Convert.ToInt32(Console.ReadLine());
                double harmonicSum = 0;
                for (int i = 1; i <= n; i++)
                {
                    harmonicSum = harmonicSum + (double)1 / (double)i;
                }
                double answer = (double)n * harmonicSum;
                Console.WriteLine(answer);
            }


        }
    }
}
