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
            HashSet<Coordinate> remove = new HashSet<Coordinate>();
            foreach (string s in Instructions)
            {
                List<int> numbers = this.ParseListOfInteger(s);
                Coordinate c = new Coordinate(numbers[0], numbers[1]);
                Coordinate b = new Coordinate(numbers[2], numbers[3]);
                foreach (KeyValuePair<Coordinate, int> k in Sensors)
                {
                    if (!k.Key.Equals(c) && k.Key.ManhattanDistance(c) <= k.Value && k.Key.ManhattanDistance(b) <= k.Value)
                    {
                        remove.Add(c);
                    }
                }
            }
            foreach (Coordinate c in remove)
                Sensors.Remove(c);
            HashSet<Coordinate> mhm = new HashSet<Coordinate>();

            foreach (KeyValuePair<Coordinate, int> sensor in Sensors)
            {
                List<Coordinate> corners = new List<Coordinate>();
                corners.Add(new Coordinate(sensor.Key.GetSum(new Coordinate(0, sensor.Value))));
                corners.Add(new Coordinate(sensor.Key.GetSum(new Coordinate(0, -sensor.Value))));
                corners.Add(new Coordinate(sensor.Key.GetSum(new Coordinate(sensor.Value, 0))));
                corners.Add(new Coordinate(sensor.Key.GetSum(new Coordinate(-sensor.Value, 0))));
                for (int i = 0; i < corners.Count; i++)
                {
                    for (int x = corners[0].x; x < corners)
                }
            }
            //foreach (KeyValuePair<Coordinate, int> sensor in Sensors)
            //{
            //    foreach (KeyValuePair<Coordinate, int> sensor2 in Sensors)
            //    {
            //        if (sensor.Key.ManhattanDistance(sensor2.Key) > sensor.Value + sensor2.Value)
            //        {
            //            Coordinate direction = new Coordinate(Math.Sign(sensor.Key.x - sensor2.Key.x), Math.Sign(sensor.Key.y - sensor2.Key.y));
            //            Coordinate move = new Coordinate(sensor2.Key);
            //            if (sensor.Value > sensor2.Value)
            //            {
            //                while (sensor.Key.ManhattanDistance(move) > sensor.Value)
            //                {
            //                    move.AddTo(direction);
            //                }
            //                Coordinate NewDirection = new Coordinate(direction.x, direction.y * -1);
            //                Coordinate move2 = new Coordinate(move);
            //                while (sensor2.Key.ManhattanDistance(move2) < sensor2.Value)
            //                {
            //                    if (move2.IsInPositiveBounds(4000000, 4000000))
            //                        move2.AddTo(direction);
            //                    else break;
            //                }
            //                mhm.Add(move2);
            //                NewDirection = new Coordinate(direction.x * -1, direction.y);
            //                move2 = new Coordinate(move);
            //                while (sensor2.Key.ManhattanDistance(move2) < sensor2.Value)
            //                {
            //                    if (move2.IsInPositiveBounds(4000000, 4000000))
            //                        move2.AddTo(direction);
            //                    else break;
            //                }
            //            }

            //        }
            //    }
            //}
            foreach (Coordinate mmm in mhm)
            {
                List<Coordinate> MaybeNotSpotOn = mmm.GetNeihbours();
                bool WillItMakeIt = true;
                foreach (Coordinate c in MaybeNotSpotOn)
                {
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
                        ReturnValue = c.x * 4000000 + c.y;
                        return ReturnValue.ToString();
                    }
                }
            }
            return ReturnValue.ToString();
        }
    }
}
