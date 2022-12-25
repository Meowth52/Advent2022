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
        int Maxflow;
        public Day16(string _input) : base(_input)
        {
            string Input = this.CheckFile(_input);
            Instructions = this.ParseStringArray(Input);
            Valves = new Dictionary<char, Valve>();
            Maxflow = 0;
            foreach (string s in Instructions)
            {
                int flow = this.ParseListOfInteger(s).First();
                if (flow > Maxflow)
                    Maxflow = flow;
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
            List<Valve> tunnels = new List<Valve>();

            tunnels.Add(new Valve(Valves['A']));
            for (int i = 1; i <= 30; i++)
            {
                List<Valve> NextTunnels = new List<Valve>();
                foreach (Valve v in tunnels)
                {
                    if (v.Flow == 0)
                    {
                        if (v.Rate < (Maxflow / 2))
                        {
                            foreach (char r in v.Routes)
                            {
                                if (v.Visited.Count == 0 || v.Visited.Last().Name != r || v.Routes.Count() == 1)
                                {
                                    Valve Next = new Valve(Valves[r]);
                                    if (v.Visited.Count > 0 && v.Visited.Last().Routes.Count == 1)
                                    {
                                        Next.Routes.Remove(v.Visited.Last().Name);
                                    }
                                    Next.Visited = v.Visited;
                                    Next.Visited.Add(v);
                                    NextTunnels.Add(Next);
                                }
                            }
                        }
                        if (v.Rate > 0)
                        {
                            v.Flow = v.Rate * (30 - i);
                            NextTunnels.Add(v);
                        }
                    }
                    else
                    {
                        foreach (char r in v.Routes)
                        {
                            if (v.Visited.Count == 0 || v.Visited.Last().Name != r || v.Routes.Count() == 1)
                            {
                                Valve Next = new Valve(Valves[r]);
                                if (v.Visited.Count > 0 && v.Visited.Last().Routes.Count == 1)
                                {
                                    Next.Routes.Remove(v.Visited.Last().Name);
                                }
                                Next.Visited = v.Visited;
                                Next.Visited.Add(v);
                                NextTunnels.Add(Next);
                            }
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
            public int Flow;
            public List<char> Routes;
            public List<Valve> Visited;
            public Valve(char name, int rate, List<char> routes)
            {
                Name = name;
                Rate = rate;
                Routes = routes;
                Visited = new List<Valve>();
                Flow = 0;
            }
            public Valve(Valve v)
            {
                Name = v.Name;
                Rate = v.Rate;
                Routes = v.Routes;
                Visited = new List<Valve>(v.Visited);
                Flow = 0;
            }
            //public int GetFlowed()
            //{
            //    int ReturnValue = Rate * Flow;
            //    foreach (KeyValuePair<char, Valve> v in Visited)
            //        ReturnValue += v.Value.Rate * v.Value.Flow;
            //    return ReturnValue;
            //}
        }
    }
}
