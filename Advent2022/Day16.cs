using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace Advent2022
{
    public class Day16 : Day
    {
        string[] Instructions;
        Dictionary<char, Valve> Valves;
        public Day16(string _input) : base(_input)
        {
            string Input = this.CheckFile(_input);
            Instructions = this.ParseStringArray(Input);
            Valves = new Dictionary<char, Valve>();
            foreach (string s in Instructions)
            {
                int flow = this.ParseListOfInteger(s).First();
                string[] split = s.Split(' ');
                List<char> routes = new List<char>();
                for (int i = 9; i < split.Length; i++)
                {
                    routes.Add(split[i][0]);
                }
                Valves.Add(split[1][0], new Valve(split[1][0], flow, routes));
            }
        }
        public override Tuple<string, string> GetResult()
        {
            return Tuple.Create(GetPartOne(), GetPartTwo());
        }
        public string GetPartOne()
        {
            int ReturnValue = 0;
            int Rate = 0;
            List<Valve> tunnels = new List<Valve>();

            tunnels.Add(new Valve(Valves['A']));
            for (int i = 1; i <= 30; i++)
            {
                List<Valve> NextTunnels = new List<Valve>();
                foreach (Valve v in tunnels)
                {
                    if (v.TurnsFLowing == 0)
                    {
                        v.TurnsFLowing = 30 - i;
                        foreach (char r in v.Routes)
                        {
                            if (!v.Visited.ContainsKey(r) || v.Visited[r].TurnsFLowing > 0)
                            {
                                Valve Next = new Valve(Valves[r]);
                                Next.Visited = v.Visited;
                                if (!v.Visited.ContainsKey(v.Name))
                                    Next.Visited.Add(v.Name, v);
                                NextTunnels.Add(Next);
                            }
                        }
                    }
                    foreach (char r in v.Routes)
                    {
                        if (!v.Visited.ContainsKey(r) || v.Visited[r].TurnsFLowing > 0)
                        {
                            Valve Next = new Valve(Valves[r]);
                            Next.Visited = v.Visited;
                            if (!v.Visited.ContainsKey(v.Name))
                                Next.Visited.Add(v.Name, v);
                            NextTunnels.Add(Next);
                        }
                    }
                }
                tunnels = new List<Valve>(NextTunnels);
            }
            return ReturnValue.ToString();
        }
        public string GetPartTwo()
        {
            int ReturnValue = 0;

            return ReturnValue.ToString();
        }
        public class Valve
        {
            public char Name;
            public int Rate;
            public int TurnsFLowing;
            public List<char> Routes;
            public Dictionary<char, Valve> Visited;
            public Valve(char name, int rate, List<char> routes)
            {
                Name = name;
                Rate = rate;
                Routes = routes;
                Visited = new Dictionary<char, Valve>();
                TurnsFLowing = 0;
            }
            public Valve(Valve v)
            {
                Name = v.Name;
                Rate = v.Rate;
                Routes = v.Routes;
                Visited = new Dictionary<char, Valve>(v.Visited);
                TurnsFLowing = 0;
            }
            public int GetFlowed()
            {
                int ReturnValue = Rate * TurnsFLowing;
                foreach (KeyValuePair<char, Valve> v in Visited)
                    ReturnValue += v.Value.Rate * v.Value.TurnsFLowing;
                return ReturnValue;
            }
        }
    }
}
