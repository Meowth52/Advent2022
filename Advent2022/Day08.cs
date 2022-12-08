using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Media.Media3D;

namespace Advent2022
{
    public class Day08 : Day
    {
        string[] Instructions;
        public Day08(string _input) : base(_input)
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
            Dictionary<Coordinate, int> Trees = new Dictionary<Coordinate, int>();
            for (int x = 0; x < Instructions.Length; x++)
            {
                int height = -1;
                for (int y = 0; y < Instructions[0].Length; y++)
                {
                    if (Instructions[x][y] > height)
                    {
                        height = Instructions[x][y];
                        Coordinate tree = new Coordinate(x, y);
                        if (!Trees.ContainsKey(tree))
                        {
                            Trees.Add(tree, height);
                            ReturnValue++;
                        }
                        if (height == 9)
                            break;
                    }
                }
            }
            for (int x = 0; x < Instructions.Length; x++)
            {
                int height = -1;
                for (int y = Instructions[0].Length - 1; y >= 0; y--)
                {
                    if (Instructions[x][y] > height)
                    {
                        height = Instructions[x][y];
                        Coordinate tree = new Coordinate(x, y);
                        if (!Trees.ContainsKey(tree))
                        {
                            Trees.Add(tree, height);
                            ReturnValue++;
                        }
                        if (height == 9)
                            break;
                    }
                }
            }
            for (int y = 0; y < Instructions[0].Length; y++)
            {
                int height = -1;
                for (int x = 0; x < Instructions.Length; x++)
                {
                    if (Instructions[x][y] > height)
                    {
                        height = Instructions[x][y];
                        Coordinate tree = new Coordinate(x, y);
                        if (!Trees.ContainsKey(tree))
                        {
                            Trees.Add(tree, height);
                            ReturnValue++;
                        }
                        if (height == 9)
                            break;
                    }
                }
            }
            for (int y = 0; y < Instructions[0].Length; y++)
            {
                int height = -1;
                for (int x = Instructions.Length - 1; x >= 0; x--)
                {
                    if (Instructions[x][y] > height)
                    {
                        height = Instructions[x][y];
                        Coordinate tree = new Coordinate(x, y);
                        if (!Trees.ContainsKey(tree))
                        {
                            Trees.Add(tree, height);
                            ReturnValue++;
                        }
                        if (height == 9)
                            break;
                    }
                }
            }
            return ReturnValue.ToString();
        }
        public string GetPartTwo()
        {
            int ReturnValue = 1;
            char[] directions = { 'E', 'W', 'N', 'S' };
            for (int x = 0; x < Instructions.Length; x++)
            {
                for (int y = 0; y < Instructions[0].Length; y++)
                {
                    Dictionary<char, int> points = new Dictionary<char, int>();
                    foreach (char direction in directions)
                    {
                        points.Add(direction, 0);
                    }
                    int height = Instructions[x][y];
                    foreach (char direction in directions)
                    {
                        Coordinate Tree = new Coordinate(x, y);
                        while (true)
                        {
                            Tree.MoveNSteps(direction);
                            if (Tree.IsInPositiveBounds(Instructions.Length - 1, Instructions[0].Length - 1))
                            {
                                points[direction]++;
                                if (Instructions[Tree.x][Tree.y] >= height)
                                    break;
                            }
                            else
                                break;
                        }
                    }
                    int point = 1;
                    foreach (char direction in directions)
                    {
                        point *= points[direction];
                    }
                    if (point > ReturnValue)
                        ReturnValue = point;
                }
            }
            return ReturnValue.ToString();
        }
    }
}
