using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Advent2022
{
    public class Day06 : Day
    {
        string Instructions;
        public Day06(string _input) : base(_input)
        {
            string Input = this.CheckFile(_input);
            Instructions = this.ParseJustOneLine(Input);
        }
        public override Tuple<string, string> GetResult()
        {
            return Tuple.Create(GetPartOne(), GetPartTwo());
        }
        public string GetPartOne()
        {
            int ReturnValue = 0;
            Queue<char> Uniqueness = new Queue<char>();
            foreach (char c in Instructions)
            {
                ReturnValue++;
                if (Uniqueness.Count() >= 3)
                {
                    if (!Uniqueness.Contains(c) && Uniqueness.Distinct().Count() == 3)
                    {
                        break;
                    }
                    Uniqueness.Dequeue();
                }
                Uniqueness.Enqueue(c);
            }
            return ReturnValue.ToString();
        }
        public string GetPartTwo()
        {
            int ReturnValue = 0;

            Queue<char> Uniqueness = new Queue<char>();
            foreach (char c in Instructions)
            {
                ReturnValue++;
                if (Uniqueness.Count() >= 13)
                {
                    if (!Uniqueness.Contains(c) && Uniqueness.Distinct().Count() == 13)
                    {
                        break;
                    }
                    Uniqueness.Dequeue();
                }
                Uniqueness.Enqueue(c);
            }
            return ReturnValue.ToString();
        }
    }
}
