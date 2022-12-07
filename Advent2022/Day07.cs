using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Advent2022
{
    public class Day07 : Day
    {
        Queue<string> Instructions;
        Directory Slash;
        public Day07(string _input) : base(_input)
        {
            string Input = this.CheckFile(_input).Replace("$ ", "");
            string[] strings = this.ParseStringArray(Input);
            Instructions = new Queue<string>(strings);
            Instructions.Dequeue();
            Slash = new Directory("Slash", Instructions);
            Slash.GetSum();
        }
        public override Tuple<string, string> GetResult()
        {
            return Tuple.Create(GetPartOne(), GetPartTwo());
        }
        public string GetPartOne()
        {
            int ReturnValue = 0;
            ReturnValue = Slash.GetPartOne();
            return ReturnValue.ToString();
        }
        public string GetPartTwo()
        {
            int ReturnValue = 0;
            List<int> DirectorySizes = Slash.GetSums();
            int SpaceNeeded = Slash.Sum - 40000000;
            ReturnValue = DirectorySizes.Where(x => x >= SpaceNeeded).Min();
            return ReturnValue.ToString();
        }
        public class Directory
        {
            string Name;
            public List<Directory> Directories;
            public List<int> Files;
            public int Sum;
            Queue<string> Instructions;
            public Directory(string name, Queue<string> instructions)
            {
                Name = name;
                Directories = new List<Directory>();
                Files = new List<int>();
                Sum = 0;
                Instructions = instructions;
                bool getOut = false;
                while (Instructions.Count > 0 && getOut == false)
                {
                    string s = Instructions.Dequeue();
                    string[] instruction = s.Split(' ');
                    switch (instruction[0])
                    {
                        case "dir":
                            ; //will do this on cd
                            break;
                        case "ls": //meh
                            ;
                            break;
                        case "cd":
                            if (instruction[1] == "..")
                            {
                                getOut = true;
                            }
                            else
                            {
                                Directories.Add(new Directory(instruction[1], Instructions));
                            }
                            break;
                        default: //file
                            Files.Add(Int32.Parse(instruction[0]));
                            break;
                    }
                }
                ;
            }
            public int GetSum()
            {
                Sum = Files.Sum();
                foreach (Directory d in Directories)
                {
                    Sum += d.GetSum();
                }
                return Sum;
            }
            public int GetPartOne()
            {
                int returnValue = 0;
                if (Sum <= 100000)
                    returnValue = Sum;

                foreach (Directory d in Directories)
                {
                    returnValue += d.GetPartOne();
                }
                return returnValue;
            }
            public List<int> GetSums()
            {
                List<int> returnValue = new List<int>();
                returnValue.Add(Sum);
                foreach (Directory d in Directories)
                {
                    returnValue.AddRange(d.GetSums());
                }
                return returnValue;
            }
        }
    }
}
