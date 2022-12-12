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
            int ReturnValue = 0;
            return ReturnValue.ToString();
        }
        public string GetPartTwo()
        {
            int ReturnValue = 0;

            return ReturnValue.ToString();
        }
        public class CooSchmordinate : Coordinate
        {
            int Height;
            public CooSchmordinate(int x, int y, int h) : base(x, y)
            {
                Height = h;
            }
        }
    }
}
