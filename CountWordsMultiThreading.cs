using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class CountWordsMultiThreading
    {
        public static void Main1()
        {
            Dictionary<char, long> counts = new Dictionary<char, long>();
            Dictionary<char, long> countsSingle = new Dictionary<char, long>();
            string alphabets = "abcdefghijklmnopqrstuvwxyz";
            foreach(char c in alphabets)
            {
                counts.Add(c, 0);
            }
            foreach (char c in alphabets)
            {
                countsSingle.Add(c, 0);
            }
            Stopwatch sw = Stopwatch.StartNew();
            sw.Start();
            string[] words = File.ReadAllText(@"C:\Users\ja13\Documents\Visual Studio 2015\Projects\ConsoleApplication2\ConsoleApplication2\CountWordsCaseDocument.txt").Split(' ');
            ParallelQuery<string> query = words.AsParallel().Where(w => (int)w.ToUpper()[0] >= 65 && (int)w.ToUpper()[0] <=90 == true).Select(m => m.ToLower());
            string[] result = query.ToArray();
            
            object locker = new object();
            
            // counts each alphabets words
            Parallel.ForEach(result,
                () => {
                    // initialize thread's local dictionary
                    var dict = new Dictionary<char, long>();
                    string _alphabets = "abcdefghijklmnopqrstuvwxyz";
                    foreach (char c in _alphabets)
                    {
                        dict.Add(c, 0);
                    }
                    return dict;
                }
                , (w, state, localDict) => 
                {
                    // update thread's local dictionary
                    char startChar = w[0];
                    localDict[startChar] = localDict[startChar] + 1;
                    return localDict;
                }
                , (localDict) => {
                    lock (locker)
                    {
                        // update global dictionary with thread's local dictionary
                        foreach (var j in localDict)
                        {
                            counts[j.Key] = counts[j.Key] + localDict[j.Key];
                        }
                    }
                    }
                );

            sw.Stop();

            Console.Write("Time to get words with parallel query : ");
            Console.WriteLine(sw.ElapsedMilliseconds);

            sw.Reset();

            sw.Start();
            string[] words1 = File.ReadAllText(@"C:\Users\ja13\Documents\Visual Studio 2015\Projects\ConsoleApplication2\ConsoleApplication2\CountWordsCaseDocument.txt").Split(' ');
            IEnumerable<string> query1 = words1.Where(w => (int)w.ToUpper()[0] >= 65 && (int)w.ToUpper()[0] <= 90 == true).Select(m => m.ToLower());
            string[] result1 = query1.ToArray();
            sw.Stop();

            foreach (var s in result1)
            {
                char c = s[0];
                countsSingle[c] = countsSingle[c] + 1;
            }
            sw.Stop();
            Console.Write("Time with single thread query : ");
            Console.WriteLine(sw.ElapsedMilliseconds);

            Console.ReadLine();
        }
    }
}
