using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

namespace Advent2022
{
    public class Day11 : Day
    {
        List<string[]> Instructions;
        public Day11(string _input) : base(_input)
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
            Dictionary<int, Monkey> Monkeys = new Dictionary<int, Monkey>();
            int i = 0;
            foreach (string[] instruction in Instructions)
            {
                Monkeys.Add(i, new Monkey(instruction));
                i++;
            }
            for (i = 0; i < 20; i++)
            {
                for (int monkey = 0; monkey < Monkeys.Count(); monkey++)
                {
                    while (Monkeys[monkey].Items.Count() > 0)
                    {
                        (int Monkey, long Item) kast = Monkeys[monkey].Throw();
                        Monkeys[kast.Monkey].Items.Enqueue(kast.Item);
                    }
                }
            }
            List<int> Interactions = new List<int>();
            foreach (KeyValuePair<int, Monkey> monkey in Monkeys)
            {
                Interactions.Add(monkey.Value.Interactions);
            }
            Interactions.Sort();
            ReturnValue = Interactions[Interactions.Count - 1] * Interactions[Interactions.Count - 2];
            return ReturnValue.ToString();
        }
        public string GetPartTwo()
        {
            long ReturnValue = 0;
            Dictionary<int, Monkey> Monkeys = new Dictionary<int, Monkey>();
            int i = 0;
            int AllTheDivide = 1;
            foreach (string[] instruction in Instructions)
            {
                Monkeys.Add(i, new Monkey(instruction, true));
                AllTheDivide *= Monkeys[i].Test;
                i++;
            }
            foreach(KeyValuePair<int, Monkey> monkey in Monkeys)
            {
                monkey.Value.AllTheDivide = AllTheDivide;
            }
            for (i = 0; i < 10000; i++)
            {
                for (int monkey = 0; monkey < Monkeys.Count(); monkey++)
                {
                    while (Monkeys[monkey].Items.Count() > 0)
                    {
                        (int Monkey, long Item) kast = Monkeys[monkey].Throw();
                        Monkeys[kast.Monkey].Items.Enqueue(kast.Item);
                    }
                }
            }
            List<int> Interactions = new List<int>();
            foreach (KeyValuePair<int, Monkey> monkey in Monkeys)
            {
                Interactions.Add(monkey.Value.Interactions);
            }
            Interactions.Sort();
            ReturnValue = (long)Interactions[Interactions.Count - 1] * (long)Interactions[Interactions.Count - 2];
            return ReturnValue.ToString();
        }
        public class Monkey
        {
            public Queue<long> Items;
            List<string> Operation;
            public int Test;
            int TrueMonkey;
            int FalseMonkey;
            public int Interactions;
            public bool Part2;
            public int AllTheDivide;
            public Monkey(string[] constructor, bool part2 = false)
            {
                Items = new Queue<long>();
                MatchCollection Matches = Regex.Matches(constructor[1], @"-?\d+");
                foreach (Match m in Matches)
                {
                    Items.Enqueue((int)Int32.Parse(m.Value));
                }
                string[] split = constructor[2].Split(' ');
                Operation = new List<string>();
                Operation.Add(split[split.Length - 3]);
                Operation.Add(split[split.Length - 2]);
                Operation.Add(split[split.Length - 1]);
                split = constructor[3].Split(" ");
                Test = Int32.Parse(split.Last());
                split = constructor[4].Split(" ");
                TrueMonkey = Int32.Parse(split.Last());
                split = constructor[5].Split(" ");
                FalseMonkey = Int32.Parse(split.Last());
                Interactions = 0;
                Part2 = part2;
                AllTheDivide=0;
            }
            public (int Monkey, long Item) Throw()
            {
                Interactions++;
                long operator1 = Items.Dequeue();
                long operator2;
                if (Operation[2] == "old")
                    operator2 = operator1;
                else
                    operator2 = Int32.Parse(Operation[2]);
                switch (Operation[1])
                {
                    case "+":
                        operator1 += operator2;
                        break;
                    case "*":
                        operator1 *= operator2;
                        break;
                    case "-":
                        operator1 -= operator2;
                        break;
                    case "/":
                        operator1 /= operator2;
                        break;
                    default:
                        break;
                }
                if (!Part2)
                    operator1 /= 3;
                else
                    operator1 %= AllTheDivide;
                (int Monkey, long Item) Returnvalue;
                if (operator1 % Test == 0)
                    Returnvalue = (Monkey: TrueMonkey, Item: operator1);
                else
                    Returnvalue = (Monkey: FalseMonkey, Item: operator1);
                return Returnvalue;
            }
        }
    }
}
