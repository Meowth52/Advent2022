using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Text.Json.Serialization;

namespace Advent2022
{
    public class Day13 : Day
    {
        List<string[]> Instructions;
        public Day13(string _input) : base(_input)
        {
            string Input = this.CheckFile(_input);
            Instructions = this.ParseListOfStringArraysLineLine(Input);

        }
        public override Tuple<string, string> GetResult()
        {
            return Tuple.Create(GetPartOne(), GetPartTwo());
        }
        public string GetPartOne()
        {
            int ReturnValue = 0;
            foreach (string[] strings in Instructions)
            {
                Queue<int> One = Parse(strings[0]);
                Queue<int> Two = Parse(strings[1]);
                int i = 0;
                while (One.Count() > 0 && Two.Count > 0)
                {
                    int one = One.Dequeue();
                    int two = Two.Dequeue();
                    if (one < two)
                    {
                        ReturnValue += i + 1;
                        break;
                    }
                    else if (one > two)
                    {
                        break;
                    }
                    i++;
                }
            }
            return ReturnValue.ToString();
        }
        public string GetPartTwo()
        {
            int ReturnValue = 0;

            return ReturnValue.ToString();
        }
        public Queue<int> Parse(string input)
        {
            Queue<int> result = new Queue<int>();
            for (int i = 0; i < input.Length; i++)
            {

                switch (input[i])
                {
                    case '[':
                        ;
                        break;
                    case ',':
                        ;
                        break;
                    case ']':
                        result.Enqueue(-1);
                        break;
                    default:
                        string number = input[i].ToString();
                        while (i < input.Length - 1)
                        {
                            if (Char.IsDigit(input[i + 1]))
                            {
                                i++;
                                number += input[i].ToString();
                            }
                            else
                                break;
                        }
                        result.Enqueue(Int32.Parse(number));
                        break;
                }
            }
            return result;
        }
    }
}
