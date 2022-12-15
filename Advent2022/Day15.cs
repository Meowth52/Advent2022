using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Advent2022
{
    public class Day15 : Day
    {
        string[] Instructions;
        public Day15(string _input) : base(_input)
        {
            string Input = this.CheckFile(_input);
            Instructions = this.ParseStringArray(Input);
        }
        public override Tuple<string, string> GetResult()
        {
            return Tuple.Create(GetPartOne(), GetPartTwo());
        }
        public string GetPartOne()
        {
            long ReturnValue = 0;
            int LowestX = Int32.MaxValue;
            int HighestX = 0;
            Dictionary<Coordinate, long> Sensors = new Dictionary<Coordinate, long>();
            HashSet<Coordinate> Beacons = new HashSet<Coordinate>();
            foreach (string s in Instructions)
            {
                List<int> numbers = this.ParseListOfInteger(s);
                Coordinate c = new Coordinate(numbers[0], numbers[1]);
                Coordinate b = new Coordinate(numbers[2], numbers[3]);
                int distance = checked(c.ManhattanDistance(b));
                Sensors.Add(c, distance);
                Beacons.Add(b);
                if (c.x - distance < LowestX)
                    LowestX = checked(c.x - distance);
                if (c.x + distance > HighestX)
                    HighestX = checked(c.x + distance);
            }
            int ArbetaryYValue = 2000000;
            for (int x = LowestX; x <= HighestX; x++)
            {
                bool WillItMakeIt = false;
                foreach (KeyValuePair<Coordinate, long> sensor in Sensors)
                {
                    int Distance = Int32.MaxValue;
                    Coordinate check = new Coordinate(x, ArbetaryYValue);
                    if (sensor.Key.ManhattanDistance(check) <= sensor.Value && !Beacons.Contains(check))
                    {
                        WillItMakeIt = true;
                        break;
                    }
                }
                if (WillItMakeIt)
                {
                    ReturnValue++;
                }
            }
            return ReturnValue.ToString();
        }
        public string GetPartTwo()
        {
            int ReturnValue = 0;

            return ReturnValue.ToString();
        }
    }
}
