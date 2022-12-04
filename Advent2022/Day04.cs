using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Advent2022
{
    public class Day04 : Day
    {
        List<List<int>> Instructions;
        public Day04(string _input) : base(_input)
        {
            string Input = this.CheckFile(_input);
            Input = Input.Replace("-", "#");
            Instructions = this.ParseListOfIntegerLists(Input);
        }
        public override Tuple<string, string> GetResult()
        {
            return Tuple.Create(GetPartOne(), GetPartTwo());
        }
        public string GetPartOne()
        {
            int ReturnValue = 0;
            foreach (List<int> pair in Instructions)
            {
                if ((pair[0] >= pair[2] && pair[1] <= pair[3]) || (pair[2] >= pair[0] && pair[3] <= pair[1]))
                {
                    ReturnValue++;
                }
            }
            return ReturnValue.ToString();
        }
        public string GetPartTwo()
        {
            int ReturnValue = 0;
            foreach (List<int> pair in Instructions)
            {
                if ((pair[0] <= pair[3] && pair[1] >= pair[2]) || (pair[2] >= pair[1] && pair[3] <= pair[0]))
                {
                    ReturnValue++;
                }
            }
            return ReturnValue.ToString();
        }
    }
}
