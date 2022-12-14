using Advent2022;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Advent2022
{
    public abstract class Day
    {
        public MainView _mainView;
        public Day(string _input)
        {

        }
        public void SetMainView(MainView mainView)
        {
            this._mainView = mainView;
        }
        public abstract Tuple<string, string> GetResult();
        public string CheckFile(string _input)
        {
            string Input = "";
            if (String.IsNullOrWhiteSpace(_input))
            {
                if (File.Exists("Input.txt"))
                {
                    Input = File.ReadAllText("Input.txt");
                }
            }
            else
            {
                File.WriteAllText("Input.txt", _input);
                Input = _input;
            }
            return Input;
        }

        public string ParseJustOneLine(string input)
        {
            return input.Replace("\r\n", "");
        }
        public string[] ParseStringArray(string input)
        {
            string Input = input.Replace("\r\n", "_");
            return Input.Split(new[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
        }
        public List<string[]> ParseListOfStringArraysLineLine(string input)
        {
            List<string[]> ReturnList = new List<string[]>();
            string[] RawInstructions = input.Split(new[] { "\r\n\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in RawInstructions)
            {
                ReturnList.Add(s.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries));
            }
            return ReturnList;
        }
        public List<string[]> ParseListOfStringArraysLineSpace(string input)
        {
            List<string[]> ReturnList = new List<string[]>();
            string[] RawInstructions = input.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in RawInstructions)
            {
                ReturnList.Add(s.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries));
            }
            return ReturnList;
        }
        public List<List<int>> ParseListOfIntegerLists(string input)
        {
            List<List<int>> ReturnList = new List<List<int>>();
            string Input = input.Replace("\r\n", "_");
            string[] RawInstructions = Input.Split(new[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in RawInstructions)
            {
                MatchCollection Matches = Regex.Matches(s, @"-?\d+");
                List<int> IntList = new List<int>();
                foreach (Match m in Matches)
                {
                    int ParseInt = 0;
                    Int32.TryParse(m.Value, out ParseInt);
                    IntList.Add(ParseInt);
                }
                if (IntList.Count > 0)
                    ReturnList.Add(IntList);
            }
            return ReturnList;
        }
        public List<int> ParseListOfInteger(string input)
        {
            List<int> ReturnList = new List<int>();
            MatchCollection Matches = Regex.Matches(input, @"-?\d+");
            foreach (Match m in Matches)
            {
                ReturnList.Add(Int32.Parse(m.Value));
            }
            return ReturnList;
        }
        public List<long> ParseListOfLong(string input)
        {
            List<long> ReturnList = new List<long>();
            MatchCollection Matches = Regex.Matches(input, @"-?\d+");
            foreach (Match m in Matches)
            {
                ReturnList.Add(Int64.Parse(m.Value));
            }
            return ReturnList;
        }
    }
}
