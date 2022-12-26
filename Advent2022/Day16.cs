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
        Dictionary<string, Valve> Valves;
        int Maxflow;
        public Day16(string _input) : base(_input)
        {
            string Input = this.CheckFile(_input);
            Instructions = this.ParseStringArray(Input);
            Valves = new Dictionary<string, Valve>();
            Maxflow = 0;
            foreach (string s in Instructions)
            {
                int flow = this.ParseListOfInteger(s).First();
                if (flow > Maxflow)
                    Maxflow = flow;
                string[] split = s.Split(' ');
                List<string> routes = new List<string>();
                for (int i = 9; i < split.Length; i++)
                {
                    routes.Add(split[i].Substring(0, 2));
                }
                Valves.Add(split[1], new Valve(split[1], flow, routes));
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

            tunnels.Add(new Valve(Valves["AA"]));
            for (int i = 1; i <= 30; i++)
            {
                List<Valve> NextTunnels = new List<Valve>();
                foreach (Valve v in tunnels)
                {
                    if (!v.OpenValves.Contains(v.Name))
                    {
                        if (v.Rate < (Maxflow / 2))
                        {
                            foreach (string r in v.Routes)
                            {
                                if (v.Visited.Count == 0 || v.Visited.Last().Name != r || v.Routes.Count() == 1)
                                {
                                    Valve Next = new Valve(Valves[r]);
                                    if (v.Visited.Count > 0 && v.Visited.Last().Routes.Count == 1)
                                    {
                                        Next.Routes.Remove(v.Visited.Last().Name);
                                    }
                                    Next.Visited = new List<Valve>(v.Visited);
                                    Next.AddVisit(v);
                                    Next.Flow = v.Flow;
                                    NextTunnels.Add(new Valve(Next));
                                }
                            }
                        }
                        if (v.Rate > 0)
                        {
                            Valve Next = new Valve(v);
                            Next.Open = true;
                            Next.OpenValves.Add(Next.Name);
                            Next.Flow += v.Rate * (30 - (i));
                            NextTunnels.Add(Next);
                        }
                    }
                    else
                    {
                        foreach (string r in v.Routes)
                        {
                            if (v.Visited.Count == 0 || v.Visited.Last().Name != r || v.Routes.Count() == 1)
                            {
                                Valve Next = new Valve(Valves[r]);
                                if (v.Visited.Count > 0 && v.Visited.Last().Routes.Count == 1)
                                {
                                    Next.Routes.Remove(v.Visited.Last().Name);
                                }
                                Next.Visited = new List<Valve>(v.Visited);
                                Next.AddVisit(v);
                                Next.Flow = v.Flow;
                                NextTunnels.Add(new Valve(Next));
                            }
                        }
                    }
                }

                tunnels = new List<Valve>(NextTunnels);
            }
            Valve öhh;
            foreach (Valve v in tunnels)
            {
                if (v.Flow > ReturnValue)
                {
                    ReturnValue = v.Flow;
                    öhh = v;
                }
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
            public string Name;
            public int Rate;
            public int Flow;
            public bool Open;
            public List<string> Routes;
            public List<Valve> Visited;
            public HashSet<string> OpenValves;
            public Valve(string name, int rate, List<string> routes)
            {
                Name = name;
                Rate = rate;
                Routes = routes;
                Visited = new List<Valve>();
                Flow = 0;
                Open = false;
                OpenValves = new HashSet<string>();
            }
            public Valve(Valve v)
            {
                Name = v.Name;
                Rate = v.Rate;
                Routes = v.Routes;
                Visited = new List<Valve>(v.Visited);
                Flow = v.Flow;
                Open = v.Open;
                OpenValves = new HashSet<string>(v.OpenValves);
            }
            public void AddVisit(Valve v)
            {
                OpenValves = new HashSet<string>(v.OpenValves);
                Valve W = new Valve(v);
                W.Visited.Clear();
                Visited.Add(W);
            }
        }
    }
}
