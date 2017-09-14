using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace ConsoleApplication2
{

    class dpKnapsackProblemInstance
    {
        struct item
        {
            public int weight;
            public int value;
        }
        public static void Main1()
        {
            GenericMergeSortAlgo<string> s = new GenericMergeSortAlgo<string>();
            //int[] n = new int[] { 2, 5, 3, 65, 43, 326, 21, 04,2 };
            string[] st = File.ReadAllLines(@"C:\Users\ja13\Desktop\3d app\OASIS_MB.dat");

            Func<string, string, bool> comp = (a, b) =>
            {
                return (a.CompareTo(b) > 0) ? true : false;
            };
            //string[] p = s.Sort(st, comp);
            //File.WriteAllLines(@"C:\Users\ja13\Desktop\3d app\OASIS_MB_sorted.dat", p);
            int total = 10;
            int[] values = new int[] { 10, 40, 30, 50 };
            int[] weights = new int[] { 5, 4, 6, 3 };
            List<item> items = new List<item>();
            for (int i = 0; i < weights.Length; i++)
            {
                item it = new item();
                it.value = values[i];
                it.weight = weights[i];
                items.Add(it);
            }
            // items = items.OrderBy(t => t.weight).ThenByDescending(m => m.value).ToList<item>();
            int[,] C = new int[values.Length, total + 1];
            for (int i = 0; i < total + 1; i++)
            {
                C[0, i] = items[0].weight <= i ? items[0].value : 0;
            }
            for (int i = 1; i < values.Length; i++)
            {
                for (int j = 1; j < total + 1; j++)
                {
                    if (j < items[i].weight)
                    {
                        C[i, j] = C[i - 1, j];
                    }
                    else
                    {
                        C[i, j] = Math.Max(items[i].value + C[i - 1, j - items[i].weight], C[i - 1, j]);
                    }
                }
            }

            Console.WriteLine(C[weights.Length - 1, total]);
            Console.ReadLine();

        }
    }
}
