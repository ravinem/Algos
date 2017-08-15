using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMT_Elitmus
{
    class SEAVOTE
    {
        static void Main2(string[] args)
        { 
         int T = Convert.ToInt32(Console.ReadLine());
         while (T > 0)
         {
             int n = Convert.ToInt32(Console.ReadLine());
             string[] B = Console.ReadLine().Split(' ');
             int sum = 0;
             int count = 0;
             foreach (var b in B)
             {
                 sum = sum + Convert.ToInt32(b);
                 if (Convert.ToInt32(b) != 0)
                     count++;
             }
             if (sum < 100)
                 Console.WriteLine("NO");
             else if(sum==100)
                 Console.WriteLine("YES");
             else
             {
                 double diff = sum - 100;
                 double maxReduction = count;
                 if( sum - maxReduction < 100)
                     Console.WriteLine("YES");
                 else
                     Console.WriteLine("NO");
             }

             T--;
         }
        }
    }
}
