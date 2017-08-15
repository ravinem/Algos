using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMT_Elitmus
{
    class CHSGMNTS
    {
        static void Main1(string[] args)
        {

            //List<int> primes = new List<int>();
            //bool[] isPrimes = new bool[20000];
            //for (int i = 2; i < 20000; i++)
            //{
            //    if (!isPrimes[i])
            //    {
            //        primes.Add(i);
            //        for (int j = 2 * i; j < 20000; j = j + i)
            //        {
            //            isPrimes[j] = true;
            //        }
            //    }
            //}



            int t = Convert.ToInt32(Console.ReadLine());
            while (t-- > 0)
            {
                int n = Convert.ToInt32(Console.ReadLine());
                string[] vals = Console.ReadLine().Split(' ');
              
                long answer = 0;
                if (vals.Length == 1)
                {
                    Console.WriteLine(0);
                }
                else if (vals.Length == 2)
                {
                    if (vals[0] != vals[1])
                    {
                        Console.WriteLine(1);
                    }
                    else
                    {
                        Console.WriteLine(0);
                    }
                }
                else
                {
                    for (int i = 0; i < vals.Length - 1; i++)
                    {
                        string singleEle = vals[i];
                        for (int j = i + 1; j < vals.Length; j++)
                        {
                            string currentEleVal = vals[j];
                            
                        }
                    }
                    Console.WriteLine(answer);
                }
            }
        }

        static ulong GCD(ulong a, ulong b)
        {
            if (b == 0)
                return a;
            else
            {
               return GCD(b, a % b);
            }
        }
    }
}
