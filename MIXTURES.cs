using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// NOT SOLVED
namespace MMT_Elitmus
{
    class MIXTURES
    {
        static void Main1(string[] args)
        {
            //int T = Convert.ToInt32(Console.ReadLine());
            while (true)
            {
                string s = Console.ReadLine();
                if (string.IsNullOrEmpty(s))
                    break;
                int n = Convert.ToInt32(s);
                List<string> colors = Console.ReadLine().Split(' ').ToList();
                long answer = 0;
                while (colors.Count > 1)
                {
                    int smokingIndex = 0;
                    int lastMaxDifference = 200;
                    for (int i = 0; i < colors.Count - 1; i++)
                    {
                        if (100 - ((Convert.ToInt32(colors[i]) + Convert.ToInt32(colors[i + 1])) % 100) < lastMaxDifference)
                        {
                            lastMaxDifference = (Convert.ToInt32(colors[i]) + Convert.ToInt32(colors[i + 1])) % 100;
                            smokingIndex = i;
                            if (lastMaxDifference == 0)
                            { break; }                           
                        }
                    }
                    answer = answer + (Convert.ToInt32(colors[smokingIndex]) * Convert.ToInt32(colors[smokingIndex + 1]));
                    colors[smokingIndex] = ((Convert.ToInt32(colors[smokingIndex]) + Convert.ToInt32(colors[smokingIndex + 1])) % 100).ToString();
                    colors.RemoveAt(smokingIndex + 1);
                }
                Console.WriteLine(answer);
                
            }
        }
    }
}
