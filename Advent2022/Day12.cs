using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Advent2022
{
    public class Day12 : Day
    {
        Dictionary<Coordinate, int> HeightMap;
        Coordinate Start;
        Coordinate End;
        public Day12(string _input) : base(_input)
        {
            string Input = this.CheckFile(_input);
            string[] split = this.ParseStringArray(Input);
            HeightMap = new Dictionary<Coordinate, int>();
            for (int y = 0; y < split.Length; y++)
            {
                for (int x = 0; x < split[0].Length; x++)
                {
                    byte b = (byte)split[y][x];

                    switch (b)
                    {
                        case 83: //Start
                            Start = new Coordinate(x, y);
                            HeightMap.Add(Start, 0);
                            break;
                        case 69: //End
                            End = new Coordinate(x, y);
                            HeightMap.Add(End, 25);
                            break;
                        default:
                            HeightMap.Add(new Coordinate(x, y), b - 97);
                            break;
                    }
                }
            }
        }
        public override Tuple<string, string> GetResult()
        {
            return Tuple.Create(GetPartOne(), GetPartTwo());
        }
        public string GetPartOne()
        {
            List<Coordinate> start = new List<Coordinate>();
            start.Add(Start);
            int ReturnValue = GetPath(start);
            return ReturnValue.ToString();
        }
        public string GetPartTwo()
        {
            int ReturnValue = HeightMap.Count();
            ReturnValue = GetPath(HeightMap.Where(x => x.Value == 0).Select(x => x.Key).ToList());
            return ReturnValue.ToString();
        }
        public int GetPath(List<Coordinate> Start)
        {
            int ReturnValue = HeightMap.Count();
            HashSet<Coordinate> Visited = new HashSet<Coordinate>();
            HashSet<Coordinate> GoingToVisit = new HashSet<Coordinate>();
            Queue<KeyValuePair<Coordinate, int>> Paths = new Queue<KeyValuePair<Coordinate, int>>();
            foreach (Coordinate c in Start)
                Paths.Enqueue(new KeyValuePair<Coordinate, int>(c, 1));
            List<int> Winners = new List<int>();
            while (Paths.Count > 0)
            {
                KeyValuePair<Coordinate, int> herp = Paths.Dequeue();
                Coordinate Current = herp.Key;
                int CurrentNumber = herp.Value + 1;
                List<Coordinate> Neihbours = Current.GetNeihbours();
                Visited.Add(Current);
                foreach (Coordinate n in Neihbours)
                {
                    if (HeightMap.ContainsKey(n) && HeightMap[n] <= HeightMap[Current] + 1 && !Visited.Contains(n) && !GoingToVisit.Contains(n))
                    {
                        GoingToVisit.Add(n);
                        Paths.Enqueue(new KeyValuePair<Coordinate, int>(n, CurrentNumber));
                        if (n.Equals(End))
                        {
                            ReturnValue = CurrentNumber - 1;
                        }
                    }
                }
            }
            return ReturnValue;

        }
    }
}
