using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMT_Elitmus
{
    class CSS2
    {
        static void Main1(string[] args)
        {
            string fline =  Console.ReadLine();
            int N = Convert.ToInt32(fline.Split(' ')[0]);
            int M = Convert.ToInt32(fline.Split(' ')[1]);
            List<string> iniVal = new List<string>();
            Dictionary<string, string> dict = new Dictionary<string, string>();
            for (int i = 0; i < N; i++)
            {
                string sline = Console.ReadLine();
                string id = sline.Split(' ')[0];
                string attr = sline.Split(' ')[1];
                string val = sline.Split(' ')[2];
                string priority = sline.Split(' ')[3];
                iniVal.Add(id + " " + attr + '#' + priority + "*" + val);
                if (dict.ContainsKey(id + " " + attr))
                {
                    string v = dict[id + " " + attr];
                    int p = Convert.ToInt32(v.Split('#')[0]);
                    if (p <= Convert.ToInt32(priority))
                    {
                        dict[id + " " + attr] = priority + "#" + val;
                    }
                }
                else
                {
                    dict.Add(id + " " + attr, priority + "#" + val);
                }
            }

            //iniVal = iniVal.OrderByDescending(t => t.Split('*')[0]).ToList();
          

            //string lastidattr = "";
            //string lastfull = "";
            //for (int i = 0; i < N; i++)
            //{
            //    if (lastfull == iniVal[i].Split('*')[0])
            //    {
            //        dict[iniVal[i].Split('#')[0]] =  iniVal[i].Split('*')[1];
            //    }
            //    else if (lastidattr != iniVal[i].Split('#')[0])
            //    {
            //        dict.Add(iniVal[i].Split('#')[0], iniVal[i].Split('*')[1]);
            //        lastidattr = iniVal[i].Split('#')[0];
            //        lastfull = iniVal[i].Split('*')[0];
            //    }
            //}

            for (int i = 0; i < M; i++)
            {
                string tline = Console.ReadLine();
                Console.WriteLine(dict[tline].Split('#')[1]);
            }

        }
    }
}
