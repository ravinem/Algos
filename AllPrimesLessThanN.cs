using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMT_Elitmus
{
    class AllPrimesLessThanN
    {
        static void Main1(string[] args)
        {
            AllPrimes(1000000);
            int yu = (int)Math.Sqrt(1000000000) + 5;
            List<int> primes = AllPrimes(yu);
            int t = Convert.ToInt32(Console.ReadLine());
            var ouWriter = new StreamWriter(Console.OpenStandardOutput());
            ouWriter.AutoFlush = true;
            while (t-- > 0)
            {
                string[] nums = Console.ReadLine().Split(' ');
                int m = Convert.ToInt32(nums[0]);
                int n = Convert.ToInt32(nums[1]);
                for (int i = Math.Max(2,m); i <= n; i++)
                {
                    foreach (int p in primes)
                    {
                        if (p * p > i)
                        {
                            ouWriter.WriteLine(i);
                            break;
                        }
                        if (i % p == 0)
                        {
                            break;
                        }
                      
                    }
                }
                ouWriter.WriteLine();
            }
        }

        public static List<int> AllPrimes(int n)
        {
            int sqrtN = (int)Math.Sqrt(n);
            bool[] isPrime = new bool[n + 1];
            List<int> primes = new List<int>();

            for (int p = 2; p <= sqrtN; p++)
            {
                if (isPrime[p] == false)
                {
                    for (int i = p * 2; i <= n; i += p)
                        isPrime[i] = true;
                }
            }

            for (int i = 2; i < n + 1; i++)
            {
                if (!isPrime[i])
                {
                    primes.Add(i);
                }
            }
            return primes;
        }
    }
}



