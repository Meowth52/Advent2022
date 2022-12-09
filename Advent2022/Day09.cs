using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Advent2022
{
    public class Day09 : Day
    {
        List<string[]> Instructions;
        public Day09(string _input) : base(_input)
        {
            string Input = this.CheckFile(_input);
            Instructions = this.ParseListOfStringArrays2(Input);
        }
        public override Tuple<string, string> GetResult()
        {
            return Tuple.Create(GetPartOne(), GetPartTwo());
        }
        public string GetPartOne()
        {
            int ReturnValue = 0;
            HashSet<Coordinate> VisistedPositions = new HashSet<Coordinate>();
            Coordinate Head = new Coordinate(0, 0);
            Coordinate Tail = new Coordinate(0, 0);
            VisistedPositions.Add(new Coordinate(Tail));
            foreach (string[] instruction in Instructions)
            {
                char Direction = instruction[0][0];
                int Steps = Int32.Parse(instruction[1]);
                for (int i = 0; i < Steps; i++)
                {
                    Head.MoveNSteps(Direction);
                    if (Head.ManhattanDistance(Tail) == 3)
                    {
                        Tail.x += Math.Sign(Head.x - Tail.x);
                        Tail.y += Math.Sign(Head.y - Tail.y);
                    }
                    else if (Math.Abs(Head.x - Tail.x) == 2)
                    {
                        Tail.x += Math.Sign(Head.x - Tail.x);
                    }
                    else if (Math.Abs(Head.y - Tail.y) == 2)
                    {
                        Tail.y += Math.Sign(Head.y - Tail.y);
                    }
                    if (!VisistedPositions.Contains(Tail))
                    {
                        VisistedPositions.Add(new Coordinate(Tail));
                    }
                }
            }
            ReturnValue = VisistedPositions.Count;
            return ReturnValue.ToString();
        }
        public string GetPartTwo()
        {
            int ReturnValue = 0;
            HashSet<Coordinate> VisistedPositions = new HashSet<Coordinate>();
            Coordinate Head = new Coordinate(0, 0);
            List<Coordinate> Tail = new List<Coordinate>();
            for (int i = 0; i < 9; i++)
            {
                Tail.Add(new Coordinate(0, 0));
            }
            VisistedPositions.Add(new Coordinate(Tail.Last()));
            foreach (string[] instruction in Instructions)
            {
                char Direction = instruction[0][0];
                int Steps = Int32.Parse(instruction[1]);
                for (int i = 0; i < Steps; i++)
                {
                    Head.MoveNSteps(Direction);
                    for (int i2 = 0; i2 < Tail.Count; i2++)
                    {
                        Coordinate Knot = Tail[i2];
                        Coordinate Last;
                        if (i2 == 0)
                            Last = Head;
                        else
                            Last = Tail[i2 - 1];

                        if (Last.ManhattanDistance(Knot) == 3)
                        {
                            Knot.x += Math.Sign(Last.x - Knot.x);
                            Knot.y += Math.Sign(Last.y - Knot.y);
                        }
                        else if (Math.Abs(Last.x - Knot.x) == 2)
                        {
                            Knot.x += Math.Sign(Last.x - Knot.x);
                        }
                        else if (Math.Abs(Last.y - Knot.y) == 2)
                        {
                            Knot.y += Math.Sign(Last.y - Knot.y);
                        }
                        if (i2 == Tail.Count - 1 && !VisistedPositions.Contains(Knot))
                        {
                            VisistedPositions.Add(new Coordinate(Knot));
                        }
                    }
                }
            }
            ReturnValue = VisistedPositions.Count;
            return ReturnValue.ToString();
        }
    }
}
