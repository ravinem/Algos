using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMT_Elitmus
{
    class he_anagrams
    {
        static void Main1(string[] args)
        {
            char[] a = Console.ReadLine().ToCharArray();
            char[] b = Console.ReadLine().ToCharArray();
            Dictionary<char, int> da = new Dictionary<char, int>();
            Dictionary<char, int> db = new Dictionary<char, int>();
      
            da.Add('a', 0);
            db.Add('a', 0);
            da.Add('b', 0);
            db.Add('b', 0);
            da.Add('c', 0);
            db.Add('c', 0);
            da.Add('d', 0);
            db.Add('d', 0);
            da.Add('e', 0);
            db.Add('e', 0);
            da.Add('f', 0);
            db.Add('f', 0);
            da.Add('g', 0);
            db.Add('g', 0);
            da.Add('h', 0);
            db.Add('h', 0);
            da.Add('i', 0);
            db.Add('i', 0);
            da.Add('j', 0);
            db.Add('j', 0);
            da.Add('k', 0);
            db.Add('k', 0);
            da.Add('l', 0);
            db.Add('l', 0);
            da.Add('m', 0);
            db.Add('m', 0);
            da.Add('n', 0);
            db.Add('n', 0);
            da.Add('o', 0);
            db.Add('o', 0);
            da.Add('p', 0);
            db.Add('p', 0);
            da.Add('q', 0);
            db.Add('q', 0);
            da.Add('r', 0);
            db.Add('r', 0);
            da.Add('s', 0);
            db.Add('s', 0);
            db.Add('t', 0);
            da.Add('t', 0);
            db.Add('u', 0);
            da.Add('u', 0);
            db.Add('v', 0);
            da.Add('v', 0);
            db.Add('w', 0);
            da.Add('w', 0);
            db.Add('x', 0);
            da.Add('x', 0);
            db.Add('y', 0);
            da.Add('y', 0);
            db.Add('z', 0);
            da.Add('z', 0);

            for (int i = 0; i < Math.Max(a.Length, b.Length); i++)
            {
                if (i < a.Length)
                {
                    da[a[i]] += 1; 
                }
                if (i < b.Length)
                {
                    db[b[i]] += 1;
                }
            }
            int ans = 0;
            foreach (char t in db.Keys)
            {
                if (db[t] != da[t])
                {
                    ans = ans + (Math.Max(db[t], da[t]) - Math.Min(db[t], da[t]));
                }
            }
            Console.WriteLine(ans);
        }
    }
}
