using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// not solved

namespace MMT_Elitmus
{
    class CHCHCL
    {
        static void Main1(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());
            while (t-- > 0)
            {
                string fgh = Console.ReadLine();
                int n = Convert.ToInt32(fgh.Split(' ')[0]);
                int m = Convert.ToInt32(fgh.Split(' ')[1]);
                if (n == 1 || m == 1)
                {
                    int val = n * m;
                    if (val % 2 == 0)
                    {
                        Console.WriteLine("Yes");
                    }
                    else
                    {
                        Console.WriteLine("No");
                    }
                }
                else
                {
                    int ans = 1;
                    while (n != 1 && m != 1)
                    {
                        if (n % 2 == 0)
                        {
                        
                        }
                    }
                }
            }
        }
    }
}
