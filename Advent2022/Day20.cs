using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Advent2022
{
    public class Day20 : Day
    {
        List<int> Instructions;
        public Day20(string _input) : base(_input)
        {
            string Input = this.CheckFile(_input);
            Instructions = this.ParseListOfInteger(Input);
        }
        public override Tuple<string, string> GetResult()
        {
            return Tuple.Create(GetPartOne(), GetPartTwo());
        }
        public string GetPartOne()
        {
            int ReturnValue = 0;
            //StringBuilder debug = new StringBuilder();
            int count = Instructions.Count - 1;
            Dictionary<int, Schmenum> JävlaOunikaSkitNummer = new Dictionary<int, Schmenum>();
            for (int fi = 0; fi < Instructions.Count(); fi++)
            {
                JävlaOunikaSkitNummer.Add(fi, new Schmenum(fi, Instructions[fi]));
            }
            for (int i = 0; i <= count; i++)
            {
                Schmenum n = JävlaOunikaSkitNummer[i];
                int index = n.CurrentPosition;
                int newIndex = index + n.Value;
                newIndex %= count;
                if (newIndex < 0)
                    newIndex += count;
                if (newIndex >= count)
                    newIndex -= count;
                JävlaOunikaSkitNummer[i].CurrentPosition = -1;
                foreach (KeyValuePair<int, Schmenum> pair in JävlaOunikaSkitNummer)
                    if (pair.Value.CurrentPosition > index)
                        pair.Value.CurrentPosition--;
                if (newIndex == 0)
                    newIndex = count;
                foreach (KeyValuePair<int, Schmenum> pair in JävlaOunikaSkitNummer)
                    if (pair.Value.CurrentPosition >= newIndex)
                        pair.Value.CurrentPosition++;
                JävlaOunikaSkitNummer[i].CurrentPosition = newIndex;
                //StringBuilder row = new StringBuilder();
                //for (int s = 0; s <= count; s++)
                //{
                //    foreach (KeyValuePair<int, Schmenum> e in JävlaOunikaSkitNummer)
                //        if (e.Value.CurrentPosition == s)
                //            row.Append(e.Value.Value.ToString() + ", ");
                //}
                //row.Append("\r\n");
                //debug.Append(row.ToString());
            }
            int schmindex = 0;
            Dictionary<int, Schmenum> Result = new Dictionary<int, Schmenum>();
            foreach (KeyValuePair<int, Schmenum> k in JävlaOunikaSkitNummer)
            {
                Result.Add(k.Value.CurrentPosition, new Schmenum(k.Value));
                if (k.Value.Value == 0)
                    schmindex = k.Value.CurrentPosition;
            }
            ReturnValue += Result[(schmindex + 1000) % Instructions.Count()].Value;
            ReturnValue += Result[(schmindex + 2000) % Instructions.Count()].Value;
            ReturnValue += Result[(schmindex + 3000) % Instructions.Count()].Value;

            //return debug.ToString() + "\r\n" + ReturnValue.ToString();
            return ReturnValue.ToString();
        }
        public string GetPartTwo()
        {
            long ReturnValue = 0;
            int DecryptionKey = 811589153;
            //StringBuilder debug = new StringBuilder();
            int count = Instructions.Count - 1;
            Dictionary<int, Schmenum> JävlaOunikaSkitNummer = new Dictionary<int, Schmenum>();
            for (int fi = 0; fi < Instructions.Count(); fi++)
            {
                JävlaOunikaSkitNummer.Add(fi, new Schmenum(fi, Instructions[fi]));
            }
            for (int b = 0; b < 10; b++)
            {
                for (int i = 0; i <= count; i++)
                {
                    Schmenum n = JävlaOunikaSkitNummer[i];
                    int index = n.CurrentPosition;
                    long longValue = ((long)n.Value * (long)DecryptionKey) % count;
                    int newIndex = index + (int)longValue;
                    newIndex %= count;
                    if (newIndex < 0)
                        newIndex += count;
                    if (newIndex >= count)
                        newIndex -= count;
                    JävlaOunikaSkitNummer[i].CurrentPosition = -1;
                    foreach (KeyValuePair<int, Schmenum> pair in JävlaOunikaSkitNummer)
                        if (pair.Value.CurrentPosition > index)
                            pair.Value.CurrentPosition--;
                    if (newIndex == 0)
                        newIndex = count;
                    foreach (KeyValuePair<int, Schmenum> pair in JävlaOunikaSkitNummer)
                        if (pair.Value.CurrentPosition >= newIndex)
                            pair.Value.CurrentPosition++;
                    JävlaOunikaSkitNummer[i].CurrentPosition = newIndex;
                    //StringBuilder row = new StringBuilder();
                    //for (int s = 0; s <= count; s++)
                    //{
                    //    foreach (KeyValuePair<int, Schmenum> e in JävlaOunikaSkitNummer)
                    //        if (e.Value.CurrentPosition == s)
                    //            row.Append(e.Value.Value.ToString() + ", ");
                    //}
                    //row.Append("\r\n");
                    //debug.Append(row.ToString());
                }
            }
            int schmindex = 0;
            Dictionary<int, Schmenum> Result = new Dictionary<int, Schmenum>();
            foreach (KeyValuePair<int, Schmenum> k in JävlaOunikaSkitNummer)
            {
                Result.Add(k.Value.CurrentPosition, new Schmenum(k.Value));
                if (k.Value.Value == 0)
                    schmindex = k.Value.CurrentPosition;
            }
            ReturnValue += Result[(schmindex + 1000) % Instructions.Count()].Value;
            ReturnValue += Result[(schmindex + 2000) % Instructions.Count()].Value;
            ReturnValue += Result[(schmindex + 3000) % Instructions.Count()].Value;
            ReturnValue *= DecryptionKey;
            //return debug.ToString() + "\r\n" + ReturnValue.ToString();
            return ReturnValue.ToString();
        }
        public class Schmenum
        {
            public int Value;
            public int OriginalPosition;
            public int CurrentPosition;
            public Schmenum(int position, int value)
            {
                Value = value;
                OriginalPosition = position;
                CurrentPosition = position;
            }
            public Schmenum(Schmenum sch)
            {
                Value = sch.Value;
                OriginalPosition = sch.OriginalPosition;
                CurrentPosition = sch.CurrentPosition;
            }
        }
    }
}
