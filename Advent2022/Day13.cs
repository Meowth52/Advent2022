using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Text.Json.Serialization;
using System.Xml;

namespace Advent2022
{
    public class Day13 : Day
    {
        List<string[]> Instructions;
        string[] Instructions2;
        public Day13(string _input) : base(_input)
        {
            string Input = this.CheckFile(_input);
            Instructions = this.ParseListOfStringArraysLineLine(Input);
            Instructions2 = this.ParseStringArray(Input);
        }
        public override Tuple<string, string> GetResult()
        {
            return Tuple.Create(GetPartOne(), GetPartTwo());
        }
        public string GetPartOne()
        {
            int ReturnValue = 0;
            int i = 0;
            foreach (string[] strings in Instructions)
            {
                i++;
                if (CompareStrings(strings[0], strings[1]))
                    ReturnValue += i;
            }
            return ReturnValue.ToString();
        }
        public string GetPartTwo()
        {
            int ReturnValue = 0;
            int DividerIndexOne = 0;
            int DividerIndexTwo = 0;
            string DividerOne = "[[2]]";
            string DividerTwo = "[[6]]";
            foreach (string s in Instructions2)
            {
                if (CompareStrings(s, DividerOne))
                    DividerIndexOne++;
                if (CompareStrings(s, DividerTwo))
                    DividerIndexTwo++;
            }
            ReturnValue = (DividerIndexOne + 1) * (DividerIndexTwo + 2);
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
                        result.Enqueue(-2);
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
        public bool CompareStrings(string _one, string _two)
        {
            bool Win = false;
            Queue<int> One = Parse(_one);
            Queue<int> Two = Parse(_two);
            bool GetOut = false;
            while (!GetOut)
            {
                int one = One.Dequeue();
                int two = Two.Dequeue();
                if (one == two)
                    ;
                else if (one == -1)
                {
                    Win = true;
                    break;
                }
                else if (one == -2 && two >= 0)
                {
                    Two = new Queue<int>(Two.Prepend(-1));
                    Two = new Queue<int>(Two.Prepend(two));

                }
                else if (two == -1)
                {
                    break;
                }
                else if (two == -2 && one >= 0)
                {
                    One = new Queue<int>(One.Prepend(-1));
                    One = new Queue<int>(One.Prepend(one));
                }

                else if (one < two)
                {
                    Win = true;
                    break;
                }
                else if (one > two)
                {
                    break;
                }
            }
            return Win;
        }
    }
}
