using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Advent2022
{
    public class Day03 : Day
    {
        List<List<int[]>> Instructions;
        string[] Strings;
        public Day03(string _input) : base(_input)
        {
            string Input = this.CheckFile(_input);
            Strings = this.ParseStringArray(Input);
            Instructions = new List<List<int[]>>();
            foreach (string s in Strings)
            {
                Instructions.Add(new List<int[]>());
                Instructions.Last().Add(Encoding.ASCII.GetBytes(s.Substring(0, s.Length / 2)).Select(x => (int)x).ToArray());
                Instructions.Last().Add(Encoding.ASCII.GetBytes(s.Substring(s.Length / 2, s.Length / 2)).Select(x => (int)x).ToArray());
            }
            foreach (List<int[]> list in Instructions)
            {
                foreach (int[] bs in list)
                {
                    for (int i = 0; i < bs.Length; i++)
                    {
                        if (bs[i] < 91)
                            bs[i] -= 38;
                        else
                            bs[i] -= 96;
                    }
                }
            }
        }
        public override Tuple<string, string> GetResult()
        {
            return Tuple.Create(GetPartOne(), GetPartTwo());
        }
        public string GetPartOne()
        {
            int ReturnValue = 0;

            foreach (List<int[]> list in Instructions)
            {
                foreach (int hepp in list[0])
                {
                    if (list[1].Contains(hepp))
                    {
                        ReturnValue += hepp;
                        break;
                    }
                }
            }
            return ReturnValue.ToString();
        }
        public string GetPartTwo()
        {
            int ReturnValue = 0;
            List<char> badgers = new List<char>();
            for (int i = 0; i < Strings.Length; i += 3)
            {
                foreach (char c in Strings[i])
                {
                    if (Strings[i + 1].Contains(c) && Strings[i + 2].Contains(c))
                    {
                        badgers.Add(c);
                        break;
                    }
                }
            }
            foreach (char c in badgers)
            {
                ReturnValue += GetPriority(c);
            }
            return ReturnValue.ToString();
        }
        public int GetPriority(char c)
        {
            int b = (byte)c;
            if (b < 91)
                b -= 38;
            else
                b -= 96;
            return b;
        }
    }
}
