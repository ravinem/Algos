using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMT_Elitmus
{
    class BINOP
    {
        static void Main5(string[] args)
        { 
            // 00 -> 00
            // 01 -> 00,11,10
            // 10 -> 00,11,01
            // 11 -> 00

            int T = Convert.ToInt32(Console.ReadLine());
            while (T > 0)
            {
                string A = Console.ReadLine();
                string B = Console.ReadLine();
                int count10 = 0;
                int count01 = 0;

                bool isAll0 = true;
                bool isAll1 = true;

                bool alReadySolved = true;
                for (int i = 0; i < A.Length; i++)
                {
                    if (A[i] != B[i])
                    {
                        alReadySolved = false;
                        if (A[i] == '0')
                        {
                            isAll1 = false;
                            count01++;
                        }
                        else
                        {
                            isAll0 = false;
                            count10++;
                        }
                    }
                    else if (A[i] == '0')
                    { isAll1 = false; }
                    else
                        isAll0 = false;
                }

                if (alReadySolved)
                {
                    Console.WriteLine("Lucky Chef");
                    Console.WriteLine("0");
                }
                else if (!isAll0 && !isAll1)
                {
                    int res = Math.Min(count10, count01);
                    int res2 = Math.Max(count10, count01) - res;
                    Console.WriteLine("Lucky Chef");
                    Console.WriteLine(res + res2);
                }
                else
                {
                    Console.WriteLine("Unlucky Chef");
                }

                T--;
            }
         
        }
    }
}
