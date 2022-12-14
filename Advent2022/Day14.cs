using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Xml;
using System.DirectoryServices.ActiveDirectory;

namespace Advent2022
{
    public class Day14 : Day
    {
        string[] Instructions;
        public Day14(string _input) : base(_input)
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
            HashSet<Coordinate> Cave = DigCave(Instructions);
            int Lowest = 0;
            foreach (Coordinate c in Cave)
            {
                if (c.y > Lowest)
                    Lowest = c.y;
            }
            Coordinate quit = new Coordinate(500, 0);
            List<Coordinate> Directions = new List<Coordinate>();
            Directions.Add(new Coordinate(0, 1));
            Directions.Add(new Coordinate(-1, 1));
            Directions.Add(new Coordinate(+1, 1));
            bool OutOfBounds = false;
            while (!OutOfBounds)
            {
                Coordinate Current = new Coordinate(500, 0);
                while (true)
                {
                    Coordinate Next = new Coordinate(Current);
                    foreach (Coordinate c in Directions)
                    {
                        if (!Cave.Contains(Current.GetSum(c)))
                        {
                            Next.AddTo(c);
                            break;
                        }
                    }
                    if (Next.Equals(Current))
                    {
                        Cave.Add(new Coordinate(Current));
                        ReturnValue++;
                        break;
                    }
                    else
                    {
                        Current = new Coordinate(Next);
                        if (Current.y > Lowest)
                        {
                            OutOfBounds = true;
                            break;
                        }
                    }
                }
            }
            return ReturnValue.ToString();
        }
        public string GetPartTwo()
        {
            int ReturnValue = 0;
            HashSet<Coordinate> Cave = DigCave(Instructions);
            int Lowest = 0;
            foreach (Coordinate c in Cave)
            {
                if (c.y > Lowest)
                    Lowest = c.y;
            }
            Coordinate quit = new Coordinate(500, 0);
            List<Coordinate> Directions = new List<Coordinate>();
            Directions.Add(new Coordinate(0, 1));
            Directions.Add(new Coordinate(-1, 1));
            Directions.Add(new Coordinate(+1, 1));
            Lowest += 2;
            while (!Cave.Contains(quit))
            {
                Coordinate Current = new Coordinate(500, 0);
                while (true)
                {
                    Coordinate Next = new Coordinate(Current);
                    foreach (Coordinate c in Directions)
                    {
                        if (!Cave.Contains(Current.GetSum(c)) && Current.GetSum(c).y < Lowest)
                        {
                            Next.AddTo(c);
                            break;
                        }
                    }
                    if (Next.Equals(Current))
                    {
                        Cave.Add(new Coordinate(Current));
                        ReturnValue++;
                        break;
                    }
                    else
                    {
                        Current = new Coordinate(Next);
                    }
                }
            }
            return ReturnValue.ToString();
        }
        public HashSet<Coordinate> DigCave(string[] instructions)
        {
            HashSet<Coordinate> Cave = new HashSet<Coordinate>();
            foreach (string Instruction in instructions)
            {
                string[] split = Instruction.Split(" -> ");
                for (int i = 0; i < split.Length - 1; i++)
                {
                    List<int> Numbers = this.ParseListOfInteger(split[i]);
                    List<Coordinate> Pair = new List<Coordinate>();
                    Pair.Add(new Coordinate(Numbers[0], Numbers[1]));
                    Numbers = this.ParseListOfInteger(split[i + 1]);
                    Pair.Add(new Coordinate(Numbers[0], Numbers[1]));
                    Pair.Sort();
                    if (Pair[0].x != Pair[1].x)
                    {
                        for (int x = Pair[0].x; x <= Pair[1].x; x++)
                        {
                            Cave.Add(new Coordinate(x, Pair[0].y));
                        }
                    }
                    else
                    {
                        for (int y = Pair[0].y; y <= Pair[1].y; y++)
                        {
                            Cave.Add(new Coordinate(Pair[0].x, y));
                        }
                    }
                }
            }
            return Cave;
        }
    }
}
