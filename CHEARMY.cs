using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMT_Elitmus
{
    class CHEARMY
    {
        static void Main2(string[] args)
        {

            int T = Convert.ToInt32(Console.ReadLine());               


            while (T > 0)
            {
                long k = Convert.ToInt64(Console.ReadLine()) -1;
                long l = baseTenToBase5(k);
                string res = "";
                foreach (var p in l.ToString())
                {
                    res = res + Convert.ToInt32((p.ToString())) * 2;
                }
                Console.WriteLine(res);
                T--;
            }
        }


        public static long baseTenToBase5(long num)
        {
            string res = "";
            while (num > 5)
            {
                res = (num % 5).ToString() + res;
                num = num / 5;
            }
            if (num > 0)
            {
                res = num.ToString() + res;
            }
            return Convert.ToInt64(res);
        }
      
    }
}
