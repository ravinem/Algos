using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    class graph_BFS
    {
        public static void Main()
        {
            BFS("A", PrepareInput());
        }
        
        public static void BFS(string node,Dictionary<string,List<string>> adjcncy)
        {
            Dictionary<string, int> level = new Dictionary<string, int>();
            level.Add(node, 0);
            List<string> frontier = new List<string>();
            frontier.Add(node);
            Dictionary<string, string> parent = new Dictionary<string, string>();
            parent.Add(node, null);
            int current_level =1;
            
            while(frontier.Count > 0)
            {
                List<string> next = new List<string>();
                foreach (var v in frontier)
                {
                    foreach(var u in adjcncy[v])
                    {
                        if(!level.ContainsKey(u))
                        {
                            level[u] = current_level;
                            parent[u] = v;
                            next.Add(u);
                        }
                    }                    
                }
                frontier = next;
                ++current_level;
            }
        }


        public static Dictionary<string, List<string>> PrepareInput()
        {
            /*
            A----------B------E
            |        /  |
            |       /   |
             ------C----D
             */
            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
            dict.Add("A", new List<string>() { "B","C"});
            dict.Add("B", new List<string>() { "A", "C","D","E" });
            dict.Add("C", new List<string>() { "B", "A", "D" });
            dict.Add("D", new List<string>() { "B", "C" });
            dict.Add("E", new List<string>() { "B" });
            return dict;
        }
    }
}
