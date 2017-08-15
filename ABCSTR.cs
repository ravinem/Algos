using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Not Solved

namespace MMT_Elitmus
{
    class ABCSTR
    {
        static void Main1(string[] rsf)
        {
            string line = Console.ReadLine();
            int[] Asum = new int[line.Length];
            int[] Bsum = new int[line.Length];
            int[] Csum = new int[line.Length];

            int sumA = 0;
            int sumB = 0;
            int sumC = 0;

            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == 'A')
                {
                    sumA++;
                    Asum[i] = sumA;
                    Bsum[i] = sumB;
                    Csum[i] = sumC;
                }
                else if (line[i] == 'B')
                {
                    sumB++;
                    Asum[i] = sumA;
                    Bsum[i] = sumB;
                    Csum[i] = sumC;
                }
                else
                {
                    sumC++;
                    Asum[i] = sumA;
                    Bsum[i] = sumB;
                    Csum[i] = sumC;
                }
            }
            long ans = 0;
            for (int i = 0; i < line.Length - 2; i++)
            {
                int lasta = 0;
                int lastb = 0;
                int lastc = 0;
                if (i > 0)
                {
                    lasta = Asum[i - 1];
                    lastb = Bsum[i - 1];
                    lastc = Csum[i - 1];
                }
                for (int j = i + 2; j < line.Length; j = j + 3)
                {
                    int suba = Asum[j] - lasta;
                    int subb = Bsum[j] - lastb;
                    int subc = Csum[j] - lastc;
                    if (suba == subb && subb == subc)
                        ans++;
                }
            }
            Console.WriteLine(ans);
        }
    }
}
