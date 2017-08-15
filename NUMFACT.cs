using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMT_Elitmus
{
    // Based on Divisor Function
    class NUMFACT
    {
        static void Main1(string[] args)
        {
            int T = Convert.ToInt32(Console.ReadLine());
            while (T > 0)
            {
                int n = Convert.ToInt32(Console.ReadLine());
                string[] A = Console.ReadLine().Split(' ');

                Dictionary<int, int> primesExponent = new Dictionary<int, int>();
              
                // can check if number's count is more than 1 say x, then we can say numbe rof factors are answer*x

                for (int i = 0; i < A.Length; i++)
                {
                    int num = Convert.ToInt32(A[i]);
                    if (num % 2 == 0 && !primesExponent.ContainsKey(2))
                    {
                        primesExponent.Add(2, 1);
                        num = num / 2;
                    }
                    while (num % 2 == 0)
                    {
                        primesExponent[2] = primesExponent[2] + 1;
                        num = num / 2;
                    }

                    for (int f = 3; f <= Math.Sqrt(num); f = f + 2)
                    {
                        if (num % f == 0 && !primesExponent.ContainsKey(f))
                        {
                            primesExponent.Add(f, 1);
                            num = num / f;
                        }
                        while (num % f == 0)
                        {
                            primesExponent[f] = primesExponent[f] + 1;
                            num = num / f;
                        }
                    }

                    if (num > 2)
                    {
                        if (!primesExponent.ContainsKey(num))
                        primesExponent.Add(num, 1);
                        else
                            primesExponent[num] = primesExponent[num] + 1;
                    }
                }

                int answer = 1;
                foreach (var y in primesExponent.Values)
                {
                    answer = answer * (y + 1);
                }

                Console.WriteLine(answer);
                T--;
            }
        }
    }
}
