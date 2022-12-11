using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Advent2022
{
    public class Day01 : Day
    {
        List<List<int>> Snacks;
        public Day01(string _input) : base(_input)
        {
            string Input = this.CheckFile(_input);
            List< string[]> hepp = this.ParseListOfStringArraysLineLine(Input);
            Snacks = new List<List<int>>();
            foreach (string[] elf in hepp)
            {
                Snacks.Add(new List<int>());
                foreach(string snack in elf)
                {
                    Snacks.Last().Add(Int32.Parse(snack));
                }
            }
            
            ;
        }
        public override Tuple<string, string> GetResult()
        {
            return Tuple.Create(GetPartOne(), GetPartTwo());
        }
        public string GetPartOne()
        {
            int ReturnValue = 0;
            foreach(List<int> i in Snacks)
            {
                int thisOne = i.Sum();
                if (thisOne > ReturnValue)
                    ReturnValue = thisOne;
            }
            return ReturnValue.ToString();
        }
        public string GetPartTwo()
        {
            int ReturnValue = 0;
            List<int> Sums = new List<int>();
            foreach (List<int> i in Snacks)
            {
                Sums.Add(i.Sum());
            }
            Sums.Sort();
            for(int i = 1; i < 4; i++)
            {
                ReturnValue += Sums[Sums.Count - i];
            }
            return ReturnValue.ToString();
        }
    }
}
