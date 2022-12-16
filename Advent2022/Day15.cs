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
            int ReturnValue = 0;
            //int LowestX = Int32.MaxValue;
            //int HighestX = 0;
            //Dictionary<Coordinate, int> Sensors = new Dictionary<Coordinate, int>();
            //HashSet<Coordinate> Beacons = new HashSet<Coordinate>();
            //foreach (string s in Instructions)
            //{
            //    List<int> numbers = this.ParseListOfInteger(s);
            //    Coordinate c = new Coordinate(numbers[0], numbers[1]);
            //    Coordinate b = new Coordinate(numbers[2], numbers[3]);
            //    int distance = checked(c.ManhattanDistance(b));
            //    Sensors.Add(c, distance);
            //    Beacons.Add(b);
            //    if (c.x - distance < LowestX)
            //        LowestX = checked(c.x - distance);
            //    if (c.x + distance > HighestX)
            //        HighestX = checked(c.x + distance);
            //}
            //HashSet<Coordinate> remove = new HashSet<Coordinate>();
            //foreach (string s in Instructions)
            //{
            //    List<int> numbers = this.ParseListOfInteger(s);
            //    Coordinate c = new Coordinate(numbers[0], numbers[1]);
            //    Coordinate b = new Coordinate(numbers[2], numbers[3]);
            //    foreach (KeyValuePair<Coordinate, int> k in Sensors)
            //    {
            //        if (!k.Key.Equals(c) && k.Key.ManhattanDistance(c) <= k.Value && k.Key.ManhattanDistance(b) <= k.Value)
            //        {
            //            remove.Add(c);
            //        }
            //    }
            //}
            //foreach (Coordinate c in remove)
            //    Sensors.Remove(c);
            //int ArbetaryYValue = 2000000;
            //for (int x = LowestX; x <= HighestX; x++)
            //{
            //    bool WillItMakeIt = false;
            //    foreach (KeyValuePair<Coordinate, int> sensor in Sensors)
            //    {
            //        int Distance = Int32.MaxValue;
            //        Coordinate check = new Coordinate(x, ArbetaryYValue);
            //        if (sensor.Key.ManhattanDistance(check) <= sensor.Value && !Beacons.Contains(check))
            //        {
            //            WillItMakeIt = true;
            //            break;
            //        }
            //    }
            //    if (WillItMakeIt)
            //    {
            //        ReturnValue++;
            //    }
            //}
            return ReturnValue.ToString();
        }
        public string GetPartTwo()
        {
            long ReturnValue = 0;
            int LowestX = 0;
            int HighestX = 4000000;
            int LowestY = 0;
            int Highesty = 4000000;
            Dictionary<Coordinate, int> Sensors = new Dictionary<Coordinate, int>();
            HashSet<Coordinate> Beacons = new HashSet<Coordinate>();
            foreach (string s in Instructions)
            {
                List<int> numbers = this.ParseListOfInteger(s);
                Coordinate c = new Coordinate(numbers[0], numbers[1]);
                Coordinate b = new Coordinate(numbers[2], numbers[3]);
                int distance = checked(c.ManhattanDistance(b));
                Sensors.Add(c, distance);
                Beacons.Add(b);
            }
            List<Coordinate> mhm = new List<Coordinate>();

            foreach (KeyValuePair<Coordinate, int> sensor in Sensors)
            {
                List<Coordinate> corners = new List<Coordinate>();
                corners.Add(new Coordinate(sensor.Key.GetSum(new Coordinate(0, sensor.Value + 1))));
                corners.Add(new Coordinate(sensor.Key.GetSum(new Coordinate(0, -sensor.Value - 1))));
                corners.Add(new Coordinate(sensor.Key.GetSum(new Coordinate(sensor.Value + 1, 0))));
                corners.Add(new Coordinate(sensor.Key.GetSum(new Coordinate(-sensor.Value - 1, 0))));
                Coordinate Direction = new Coordinate(-1, -1);
                Coordinate Move = new Coordinate(corners[0]);
                while (!Move.Equals(corners[3]))
                {
                    mhm.Add(new Coordinate(Move));
                    Move.AddTo(Direction);
                }
                Direction = new Coordinate(1, -1);
                Move = new Coordinate(corners[3]);
                while (!Move.Equals(corners[1]))
                {
                    mhm.Add(new Coordinate(Move));
                    Move.AddTo(Direction);
                }
                Direction = new Coordinate(1, 1);
                Move = new Coordinate(corners[1]);
                while (!Move.Equals(corners[2]))
                {
                    mhm.Add(new Coordinate(Move));
                    Move.AddTo(Direction);
                }
                Direction = new Coordinate(-1, 1);
                Move = new Coordinate(corners[2]);
                while (!Move.Equals(corners[0]))
                {
                    mhm.Add(new Coordinate(Move));
                    Move.AddTo(Direction);
                }
            }
            foreach (Coordinate c in mhm)
            {
                if (c.IsInPositiveBounds(HighestX, Highesty))
                {
                    bool WillItMakeIt = true;
                    foreach (KeyValuePair<Coordinate, int> sensor in Sensors)
                    {
                        if (sensor.Key.ManhattanDistance(c) <= sensor.Value || Beacons.Contains(c))
                        {
                            WillItMakeIt = false;
                            break;
                        }
                    }
                    if (WillItMakeIt)
                    {
                        ReturnValue = checked((long)c.x * 4000000 + (long)c.y);
                        return ReturnValue.ToString();
                    }
                }
            }
            return ReturnValue.ToString();
        }
    }
}
