using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMT_Elitmus
{
    class TADELIVE
    {
        static void Main1(string[] args)
        {
            string hj = Console.ReadLine();
            string[] nxy = hj.Split(' ');
            int N = Convert.ToInt32(nxy[0]);
            int X = Convert.ToInt32(nxy[1]);
            int Y = Convert.ToInt32(nxy[2]);
            string a = Console.ReadLine();
            string[] A = a.Split(' ');
            string b = Console.ReadLine();
            string[] B = b.Split(' ');
            List<int> DiffDict = new List<int>();
            long ATotal = 0;
            long BTotal = 0;
            long ans = 0;
            int maxordersthatcanbetaken = 0;
            if (X < Y)
            {
                for (int i = 0; i < N; i++)
                {
                    DiffDict.Add(Convert.ToInt32(A[i]) - Convert.ToInt32(B[i]));
                    BTotal = BTotal + Convert.ToInt32(B[i]);
                }
                maxordersthatcanbetaken = X;
                ans = BTotal;
            }
            else
            {
                for (int i = 0; i < N; i++)
                {
                    DiffDict.Add(Convert.ToInt32(B[i]) - Convert.ToInt32(A[i]));
                    ATotal = ATotal + Convert.ToInt32(A[i]);
                }
                maxordersthatcanbetaken = Y;
                ans = ATotal;
            }

            List<int> SortedDiff = DiffDict.OrderByDescending(t => t).ToList();

            foreach (int item in SortedDiff)
            {
                if (maxordersthatcanbetaken == 0)
                {
                    break;
                }
                if (item <= 0)
                {
                    break;
                }
                ans = ans + item;
                maxordersthatcanbetaken--;
            }

            Console.WriteLine(ans);

        }
    }
}
