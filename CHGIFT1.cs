using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMT_Elitmus
{
    class CHGIFT1
    {
        static void Main1(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());
            while (t-- > 0)
            {
                int n = Convert.ToInt32(Console.ReadLine());
                string line = Console.ReadLine();
                string[] vals = line.Split(' ');

                int lastval = Convert.ToInt32(vals[0]);
                for (int i = 1; i < vals.Length; i++)
                {
                    lastval = Math.Min(lastval - Convert.ToInt32(vals[i]), Math.Min(lastval + Convert.ToInt32(vals[i]), lastval * Convert.ToInt32(vals[i])));
           
                }
                Console.WriteLine(lastval);
            }
        }
    }
}
