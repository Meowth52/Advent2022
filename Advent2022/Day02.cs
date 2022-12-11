using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Advent2022
{
    public class Day02 : Day
    {
        List<string[]> Instructions;
        Dictionary<string, int> MaterialValue;
        Dictionary<string, string> MaterialVinnablility;
        public Day02(string _input) : base(_input)
        {
            string Input = this.CheckFile(_input);
            Input = Input.Replace("A", "X");
            Input = Input.Replace("B", "Y");
            Input = Input.Replace("C", "Z");
            Instructions = this.ParseListOfStringArraysLineSpace(Input);
            MaterialValue = new Dictionary<string, int>()
            {
                {"X", 1},
                {"Y", 2},
                {"Z", 3}
            };
            MaterialVinnablility = new Dictionary<string, string>()
            {
                {"X", "Z"},
                {"Y", "X"},
                {"Z", "Y"}
            };
        }
        public override Tuple<string, string> GetResult()
        {
            return Tuple.Create(GetPartOne(), GetPartTwo());
        }
        public string GetPartOne()
        {
            int ReturnValue = 0;
            foreach (string[] instruction in Instructions)
            {
                ReturnValue += MaterialValue[instruction[1]];
                ReturnValue += IsWin(instruction);
            }
            return ReturnValue.ToString();
        }
        public string GetPartTwo()
        {
            int ReturnValue = 0;

            foreach (string[] instruction in Instructions)
            {
                switch (instruction[1])
                {
                    case "X": //loose
                        ReturnValue += MaterialValue[MaterialVinnablility[instruction[0]]];
                        break;
                    case "Y": //draw
                        ReturnValue += MaterialValue[instruction[0]] + 3;
                        break;
                    case "Z": //win
                        string key = MaterialVinnablility.FirstOrDefault(x => x.Value == instruction[0]).Key;
                        ReturnValue += MaterialValue[key] + 6;
                        break;

                    default:
                        break;
                }
            }
            return ReturnValue.ToString();
        }
        int IsWin(string[] instruction)
        {
            if (instruction[0] == MaterialVinnablility[instruction[1]])
                return 6;
            else if (instruction[1] == MaterialVinnablility[instruction[0]])
                return 0;
            return 3;
        }
    }
}
