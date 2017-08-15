using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMT_Elitmus
{
    class he_shinoTournament
    {
        static string[] power;
        static Dictionary<int, int> map;
        static void Main1(string[] args)
        {
            string[] nq = Console.ReadLine().Split(' ');
            int N = Convert.ToInt32(nq[0]);
            int Q = Convert.ToInt32(nq[1]);
            power = Console.ReadLine().Split(' ');

            List<int> membersLeft = new List<int>();
            map = new Dictionary<int, int>();

            for (int i = 1; i <= N; i = i + 1)
            {
                membersLeft.Add(i);
                map.Add(i, 0);
            }
            build(membersLeft);
            while (Q-- > 0)
            {
                int b = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(map[b]);
            }


        }

        static void build(List<int> membersLeft)
        {
            if (membersLeft.Count == 1)
                return;
            List<int> memLeft = new List<int>();
            for (int i = 1; i < membersLeft.Count; i = i + 2)
            {
                int f = Convert.ToInt32(power[membersLeft[i - 1] - 1]);
                int s = Convert.ToInt32(power[membersLeft[i] - 1]);
                map[membersLeft[i]] = map[membersLeft[i]] + 1;
                map[membersLeft[i - 1]] = map[membersLeft[i - 1]] + 1;
                if (f > s)
                {
                    memLeft.Add(membersLeft[i - 1]);
                }
                else
                {
                    memLeft.Add(membersLeft[i]);
                }
            }
            if (membersLeft.Count % 2 != 0)
            {
                memLeft.Add(membersLeft[membersLeft.Count - 1]);
            }
            build(memLeft);
        }
    }
}
