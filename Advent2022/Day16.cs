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
                Valves.Add(split[1][0], new Valve(flow, routes));
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
            Dictionary<char, int> tunnels = new Dictionary<char, int>();
            //tunnels.Enqueue('A');
            //for (int i = 1; i <= 30; i++)
            //{
            //    Dictionary<char, int> NextTunnels = new Dictionary<char, int>();
            //    foreach (char t in tunnels)
            //    {
            //        ReturnValue += Rate;
            //        Valve v = Valves[t];
            //        if (v.Rate > 0)
            //        {
            //            Rate += v.Rate;
            //            v.Rate = 0;
            //            foreach (char r in v.Routes)
            //                NextTunnels.Enqueue(r);
            //        }
            //        foreach (char r in v.Routes)
            //            NextTunnels.Enqueue(r);
            //    }
            //    tunnels = new Queue<char>(NextTunnels);
            //}
            return ReturnValue.ToString();
        }
        public string GetPartTwo()
        {
            int ReturnValue = 0;

            return ReturnValue.ToString();
        }
        public class Valve
        {
            public int Rate;
            public List<char> Routes;
            public Valve(int rate, List<char> routes)
            {
                Rate = rate;
                Routes = routes;
            }
        }
    }
}
