using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Net.Mail;

namespace Advent2022
{
    public class Day10 : Day
    {
        string[] Instructions;
        public Day10(string _input) : base(_input)
        {
            string Input = this.CheckFile(_input);
            Instructions = this.ParseStringArray(Input);
        }
        public override Tuple<string, string> GetResult()
        {
            return Tuple.Create(GetPartOne(), GetPartTwo());
        }
        public string GetPartOne()
        {
            int ReturnValue = 0;
            int Cycle = 1;
            int x = 1;
            foreach (string s in Instructions)
            {
                if (Cycle > 224)
                    break;
                string[] Instruction = s.Split(" ");
                switch (Instruction[0])
                {
                    case "noop":
                        Cycle++;
                        break;
                    case "addx":
                        Cycle++;
                        if (Cycle % 40 == 20)
                            ReturnValue += Cycle * x;
                        Cycle++;
                        x += Int32.Parse(Instruction[1]);
                        break;
                    default:
                        break;
                }
                if (Cycle % 40 == 20)
                    ReturnValue += Cycle * x;
            }
            return ReturnValue.ToString();
        }
        public string GetPartTwo()
        {
            int ReturnValue = 0;
            string Emptyrow = "";
            for (int i = 0; i < 40; i++)
                Emptyrow += ".";
            StringBuilder[] Screen = new StringBuilder[6];
            for (int i = 0; i < 6; i++)
            {
                Screen[i] = new StringBuilder(Emptyrow);
            }
            DrawScreen(Screen);

            int Pixel = 0;
            int Row = 0;
            int x = 1;
            foreach (string s in Instructions)
            {
                string[] Instruction = s.Split(" ");
                switch (Instruction[0])
                {
                    case "noop":
                        Pixel++;
                        break;
                    case "addx":
                        Pixel++;
                        if (Pixel % 40 == 0)
                        {
                            Pixel = 0;
                            Row++;
                            if (Row > 5)
                                break;
                        }
                        if (x - 1 == Pixel || x == Pixel || x + 1 == Pixel)
                            Screen[Row][Pixel] = '#';
                        else
                            Screen[Row][Pixel] = '.';
                        Pixel++;
                        x += Int32.Parse(Instruction[1]);
                        break;
                    default:
                        break;
                }
                if (Pixel % 40 == 0)
                {
                    Pixel = 0;
                    Row++;
                    if (Row > 5)
                        break;
                }
                if (x - 1 == Pixel || x == Pixel || x + 1 == Pixel)
                    Screen[Row][Pixel] = '#';
                else
                    Screen[Row][Pixel] = '.';
            }
            return "\r\n" + DrawScreen(Screen);
        }
        public string DrawScreen(StringBuilder[] screen)
        {
            string s = "";
            foreach (StringBuilder ss in screen)
                s += ss.ToString() + "\r\n";
            _mainView.OutText = s;
            return s;
        }
    }
}
