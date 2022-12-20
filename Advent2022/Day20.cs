using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Advent2022
{
    public class Day20 : Day
    {
        List<int> Instructions;
        public Day20(string _input) : base(_input)
        {
            string Input = this.CheckFile(_input);
            Instructions = this.ParseListOfInteger(Input);
        }
        public override Tuple<string, string> GetResult()
        {
            return Tuple.Create(GetPartOne(), GetPartTwo());
        }
        public string GetPartOne()
        {
            int ReturnValue = 0;
            int count = Instructions.Count - 1;
            List<int> Move = new List<int>(Instructions);
            for (int i = 0; i <= 3000;)
            {
                foreach (int n in Instructions)
                {
                    int index = Move.IndexOf(n);
                    //index = index % count ;
                    int newIndex = index + n;
                    newIndex %= count;
                    if (newIndex < 0)
                        newIndex += count;
                    if (newIndex >= count)
                        newIndex -= count;
                    Move.Remove(n);
                    //if (newIndex < index)
                    //    newIndex++;
                    //if (newIndex == count + 1)
                    //    newIndex = 0;
                    Move.Insert(newIndex, n);
                    i++;
                    if (i % 1000 == 0)
                        ReturnValue += Move[1000 % (count)];
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
