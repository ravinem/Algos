using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MMT_Elitmus
{
    class HelloWorld
    {
        static void Main1(string[] args)
        {
            string[] allTowns = new string[] { "A", "B", "C", "D", "E" };// Console.ReadLine().Split(' ');
            string[] allConnects = new string[] { "D-A", "B-A", "D-E", "C-E", "B-C" };// Console.ReadLine().Split(' ');
            string[] path = new string[] { "C", "B", "A", "D", "E" };//Console.ReadLine().Split(' ');

            string WinterFell = path[0];

            Dictionary<string, int> con = new Dictionary<string, int>();


            foreach (string a in allConnects)
            {
                if (!con.ContainsKey(a))
                {
                    con.Add(a, 0);
                }
            }

            List<string> townVisited = new List<string>();
            string lastTown = WinterFell;
            bool foundFamily = false;
            for (int i = 1; i < path.Length; i++)
            {
                if (con.ContainsKey(lastTown + '-' + path[i]) || con.ContainsKey(path[i] + '-' + lastTown) && !townVisited.Contains(path[i]))
                {
                    lastTown = path[i];
                    townVisited.Add(lastTown);
                    if (i == path.Length - 1)
                    {
                        if (con.ContainsKey(lastTown + '-' + WinterFell) || con.ContainsKey(WinterFell + '-' + lastTown))
                        { Console.WriteLine("Yes"); }
                        else
                            Console.WriteLine(lastTown);
                        foundFamily = true;
                    }

                }
                else
                {
                    break;
                }
            }
            if (!foundFamily)
                Console.WriteLine(lastTown);

        }

        static void Main2(string[] dd)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            List<string> customers = new List<string>();
            while (n > 0)
            {
                var line = Console.ReadLine();
                line = line + ' ' + (Convert.ToInt32(line.Split(' ')[0]) + Convert.ToInt32(line.Split(' ')[2]));
                customers.Add(line);
                n--;
            }

            customers = customers.OrderBy(t => t).Select(t => t).ToList();

            int TotalNoOfPrefServable = 0;
            int TotalNoOfNormServable = 0;
            bool canbeServed = true;
            int lastServedAt = 0;
            while (canbeServed && customers.Count >0)
            {
                int NoOfPrefServable = 0;
                int NoOfNormServable = 0;
                string custToServe = "";
                foreach (var c in customers)
                {
                    int LocalNoOfPrefServable = 0;
                    int LocalNoOfNormServable = 0;
                    int startTime = Math.Max(lastServedAt,Convert.ToInt32(c.Split(' ')[0])) +  Convert.ToInt32(c.Split(' ')[1]);
                    if (startTime > Convert.ToInt32(c.Split(' ')[4]))
                    {
                        continue;
                    }
                    if (c.Split(' ')[3] == "1")
                    {
                        LocalNoOfPrefServable++;
                    }
                    else
                    {
                        LocalNoOfNormServable++;
                    }
                    foreach (var cust in customers)
                    {
                        if (cust != c)
                        {
                            int servedAt = startTime + Convert.ToInt32(cust.Split(' ')[1]);
                            if (servedAt <= Convert.ToInt32(cust.Split(' ')[4]))
                            {
                                if (cust.Split(' ')[3] == "1")
                                {
                                    LocalNoOfPrefServable++;
                                }
                                else
                                {
                                    LocalNoOfNormServable++;
                                }
                            }

                        }
                    }
                    if (LocalNoOfPrefServable > NoOfPrefServable)
                    {
                        custToServe = c;
                        NoOfPrefServable = LocalNoOfPrefServable;
                        NoOfNormServable = LocalNoOfNormServable;
                    }
                    else if (LocalNoOfPrefServable == NoOfPrefServable && LocalNoOfNormServable > NoOfNormServable)
                    {
                        custToServe = c;
                        NoOfPrefServable = LocalNoOfPrefServable;
                        NoOfNormServable = LocalNoOfNormServable;
                    }
                }

                if (NoOfPrefServable == 0 && NoOfNormServable == 0 )
                {
                    break;
                }
                if (custToServe.Split(' ')[3] == "0")
                {
                    TotalNoOfNormServable += 1;
                }
                else
                {
                    TotalNoOfPrefServable += 1;
                }
                lastServedAt = lastServedAt  + Convert.ToInt32(custToServe.Split(' ')[1]);
                customers.Remove(custToServe);

            }

            Console.WriteLine(TotalNoOfPrefServable + " " + TotalNoOfNormServable);
        }

    }
}
