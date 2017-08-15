using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// to check if ith bit of decimal number in binary is 1 : if(num & (1<<i)==1)

namespace MMT_Elitmus
{
    class AND
    {
        static void Main1(string[] args)
        {
            int N = Convert.ToInt32(Console.ReadLine());
            string[] A = Console.ReadLine().Split(' ');
            
            List<long> m = new List<long>();
            int maxBits = 30;
            for (int i = 1; i <= maxBits; i++)
            {
                m.Add(0);
            }
            bool isAll10=true;
            long counts = 0;
            for (int j = 0; j < A.Length; j++)
            {
                int num2 = Convert.ToInt32(A[j]);
                if (num2 > 1)
                    isAll10 = false;
                else if (num2 == 1)
                    counts++;
                string s2 = "";
                while (num2 > 2)
                {
                    s2 = (num2 % 2).ToString() + s2;
                    num2 = num2 / 2;
                }
                if (num2 == 1)
                    s2 = "1" + s2;
                else
                    s2 = "10" + s2;
                while (s2.Length != maxBits)
                {
                    s2 = "0" + s2;
                }
            
                for (int i = 0; i <= maxBits - 1; i++)
                {
                    m[i] = m[i] + Convert.ToInt32(s2[(maxBits-1) - i].ToString());
                }
            }
            long sum = 0;
            if (isAll10)
            {
                    long answer = (counts * (counts - 1)) / 2;
                    Console.WriteLine(answer);
            }
            else
            {
                for (int i = 0; i < maxBits; i++)
                {
                    long h = (m[i] * (m[i] - 1)) / 2;
                    long v = Convert.ToInt64(Math.Pow(2, i));
                    sum = sum + (h * v);
                }
                Console.WriteLine(sum);
            }
           

           
        }
    }
}
