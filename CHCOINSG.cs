using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMT_Elitmus
{
    class CHCOINSG
    {
        static void Main2(string[] dd)
        {
            int T = Convert.ToInt32(Console.ReadLine());
            while (T > 0)
            {
                int N = Convert.ToInt32(Console.ReadLine());
                if (N % 6 == 0)
                {
                    Console.WriteLine("Misha");
                }
                else
                {
                    Console.WriteLine("Chef");
                }
                T--;
            }
        }
    }
}
