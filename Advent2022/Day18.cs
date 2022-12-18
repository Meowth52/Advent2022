using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Advent2022
{
    public class Day18 : Day
    {
        List<List<int>> Instructions;
        HashSet<Cooschmoordinate> Schmoshmoordinates;
        public Day18(string _input) : base(_input)
        {
            string Input = this.CheckFile(_input);
            Instructions = this.ParseListOfIntegerLists(Input); Schmoshmoordinates = new HashSet<Cooschmoordinate>();
            foreach (List<int> i in Instructions)
            {
                Schmoshmoordinates.Add(new Cooschmoordinate(i[0], i[1], i[2]));
            }
        }
        public override Tuple<string, string> GetResult()
        {
            return Tuple.Create(GetPartOne(), GetPartTwo());
        }
        public string GetPartOne()
        {
            int ReturnValue = 0;
            foreach (Cooschmoordinate c in Schmoshmoordinates)
            {
                List<Cooschmoordinate> Schneigbours = c.GetNeihbours();
                foreach (Cooschmoordinate sch in Schneigbours)
                    if (!Schmoshmoordinates.Contains(sch))
                        ReturnValue++;
            }
            return ReturnValue.ToString();
        }
        public string GetPartTwo()
        {
            int ReturnValue = 0;
            int MaxX = 0;
            int MaxY = 0;
            int MaxZ = 0;
            foreach (Cooschmoordinate c in Schmoshmoordinates)
            {
                if (c.x > MaxX)
                    MaxX = c.x;
                if (c.y > MaxY)
                    MaxY = c.y;
                if (c.z > MaxZ)
                    MaxZ = c.z;
            }
            HashSet<Cooschmoordinate> Kollat = new HashSet<Cooschmoordinate>();
            Queue<Cooschmoordinate> InteKollat = new Queue<Cooschmoordinate>();
            InteKollat.Enqueue(new Cooschmoordinate(0, 0, 0));
            while (InteKollat.Count() > 0)
            {
                Cooschmoordinate pop = InteKollat.Dequeue();
                List<Cooschmoordinate> Schneigbours = pop.GetNeihbours();
                foreach (Cooschmoordinate schshhsc in Schneigbours)
                {
                    if (schshhsc.IsInPositiveishBounds(MaxX + 1, MaxY + 1, MaxZ + 1) && !Kollat.Contains(schshhsc))
                        if (Schmoshmoordinates.Contains(schshhsc))
                        {
                            ReturnValue++;
                        }
                        else
                        {
                            InteKollat.Enqueue(schshhsc);
                            Kollat.Add(schshhsc);
                        }
                }
            }
            return ReturnValue.ToString();
        }
    }
}
