using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Advent2022
{
    public class Day05 : Day
    {
        List<List<int>> Instructions;
        List<Stack<char>> Stacks;
        List<Stack<char>> Stacks2;
        public Day05(string _input) : base(_input)
        {
            string Input = this.CheckFile(_input);
            string[] splitted = Input.Split("\r\n\r\n");
            Instructions = this.ParseListOfIntegerLists(splitted[1]);
            string[] stackStrings = this.ParseStringArray(splitted[0]);
            List<int> stackNumbers = this.ParseListOfInteger(stackStrings[stackStrings.Length - 1]);
            Stacks = new List<Stack<char>>();
            Stacks2 = new List<Stack<char>>();//because deep copy is bullshit 
            Stacks.Add(new Stack<char>()); //because fuck zero
            Stacks2.Add(new Stack<char>()); //because fuck zero
            foreach (int stack in stackNumbers)
                Stacks.Add(new Stack<char>());
            foreach (int stack in stackNumbers)
                Stacks2.Add(new Stack<char>());
            for (int i = stackStrings.Length - 2; i >= 0; i--)
            {
                foreach (int stack in stackNumbers)
                {
                    int position = stackStrings[stackStrings.Length - 1].IndexOf(stack.ToString());
                    if (stackStrings[i][position] != ' ')
                    {
                        Stacks[stack].Push(stackStrings[i][position]);
                        Stacks2[stack].Push(stackStrings[i][position]);
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
            string ReturnValue = "";
            foreach (List<int> instruction in Instructions)
            {
                for (int i = 0; i < instruction[0]; i++)
                {
                    char item = Stacks[instruction[1]].Pop();
                    Stacks[instruction[2]].Push(item);
                }
            }
            foreach (Stack<char> stack in Stacks)
            {
                if (stack.Count > 0)
                    ReturnValue += stack.Peek();
            }

            return ReturnValue;
        }
        public string GetPartTwo()
        {
            string ReturnValue = "";
            foreach (List<int> instruction in Instructions)
            {
                Stack<char> items = new Stack<char>();
                for (int i = 0; i < instruction[0]; i++)
                {
                    items.Push(Stacks2[instruction[1]].Pop());
                }
                foreach (char item in items)
                {
                    Stacks2[instruction[2]].Push(item);
                }
            }
            foreach (Stack<char> stack in Stacks2)
            {
                if (stack.Count > 0)
                    ReturnValue += stack.Peek();
            }

            return ReturnValue;
        }
    }
}
