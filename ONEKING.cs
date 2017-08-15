using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMT_Elitmus
{
    class ONEKING
    {
        static void Main2(string[] args)
        {
            int T = Convert.ToInt32(Console.ReadLine());
            while (T > 0)
            {
                int N = Convert.ToInt32(Console.ReadLine());
                int c = 0;
                List<string> elems = new List<string>();
                for (int i = 0; i < N; i++)
                {
                    string[] k = Console.ReadLine().Split(' ');
                    int f = Convert.ToInt32(k[0]);
                    int s = Convert.ToInt32(k[1]);
                    elems.Add(f +" "+ s);
                    c++;
                }

                elems = elems.OrderBy(t => Convert.ToInt32(t.Split(' ')[1])).ToList();
                
                int[] ar = new int[c];
                int lasti = 0;
                int max = -1;
                int answer = 0;
                for (int i = 0; i < c; i++)
                {
                    if (i == 0)
                    {
                        ar[i] = Convert.ToInt32(elems[i].Split(' ')[1]);                     
                    }
                    else
                    {
                        if (Convert.ToInt32(elems[i].Split(' ')[0]) <= Convert.ToInt32(elems[lasti].Split(' ')[1]))
                        {
                            ar[i] = Convert.ToInt32(elems[lasti].Split(' ')[1]);
                        }
                        else
                        {
                            lasti = i;
                            ar[i] = Convert.ToInt32(elems[i].Split(' ')[1]);
                        }
                    }
                    if (ar[i] > max)
                    {
                        answer++;
                        max = ar[i];
                    }
                }
                Console.WriteLine(answer);
                T--;
            }
        }
    }
}
