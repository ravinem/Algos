using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMT_Elitmus
{
    class WORDS1
    {
        static void Main1(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());
            while (t-- > 0)
            {
                int N = Convert.ToInt32(Console.ReadLine());
                Dictionary<char, int> DictStarts = new Dictionary<char, int>();
                Dictionary<char, int> DictEnds = new Dictionary<char, int>();
                Dictionary<char, int> DictSames = new Dictionary<char, int>();

                while (N-- > 0)
                {
                    string word = Console.ReadLine();
                    char f = word[0];
                    char l = word[word.Length - 1];
                    if (l == f)
                    {
                        if (DictSames.ContainsKey(f))
                        {
                            DictSames[f] += 1;
                        }
                        else
                        {
                            DictSames.Add(f, 1);
                        }
                    }
                    if (DictStarts.ContainsKey(f))
                    {
                        DictStarts[f] += 1;
                    }
                    else
                    {
                        DictStarts.Add(f, 1);
                    }
                    if (DictEnds.ContainsKey(l))
                    {
                        DictEnds[l] += 1;
                    }
                    else
                    {
                        DictEnds.Add(l, 1);
                    }
                }
                foreach (char c in "abcdefghijklmnopqrstuvwxyz")
                {
                    if (!DictSames.ContainsKey(c))
                    {
                        DictSames.Add(c, 0);
                    }
                    if (!DictEnds.ContainsKey(c))
                    {
                        DictEnds.Add(c, 0);
                    }
                }
                for (int i = 0; i < DictStarts.Count; i++)
                {
                    char c = DictStarts.ElementAt(i).Key;
                    if (DictStarts[c] == DictSames[c])
                    {
                        DictStarts[c] = 20;
                        // tots += 2;
                    }
                    else
                    {
                        // DictStarts[c] = Math.Max(DictStarts[c], DictEnds[c]) - Math.Min(DictStarts[c], DictEnds[c]);
                        DictStarts[c] = DictStarts[c] - DictEnds[c];
                        // tots += DictStarts[c];
                    }
                }

                if (DictStarts.Count == 1)
                {
                    if (DictStarts.ElementAt(0).Value == 20)
                    {
                        Console.WriteLine("Ordering is possible.");
                    }
                    else
                    {
                        Console.WriteLine("The door cannot be opened.");
                    }
                }
                else
                {
                    // check for 1 and -1 and all other 0
                    bool isOneFound = false;
                    bool isMinusOneFound = false;
                    bool ans = true;
                    foreach (char c in DictStarts.Keys)
                    {
                        if (DictStarts[c] == 1)
                        {
                            if (!isOneFound)
                            {
                                isOneFound = true;
                            }
                            else
                            {
                                ans = false;
                                break;
                            }
                        }

                        else if (DictStarts[c] == -1)
                        {
                            if (!isMinusOneFound)
                                isMinusOneFound = true;
                            else
                            {
                                ans = false;
                                break;
                            }
                        }

                        else if (DictStarts[c] != 0)
                        {
                            ans = false;
                            break;
                        }

                    }
                    if (ans)
                        Console.WriteLine("Ordering is possible.");
                    else
                        Console.WriteLine("The door cannot be opened.");

                }
            }

        }
    }
}
