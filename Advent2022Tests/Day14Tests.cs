using Microsoft.VisualStudio.TestTools.UnitTesting;
using Advent2022;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2022.Tests
{
    [TestClass()]
    public class Day14Tests
    {
        [TestMethod()]
        public void GetPartOneTest()
        {
            Day14 day = new Day14("498,4 -> 498,6 -> 496,6\r\n503,4 -> 502,4 -> 502,9 -> 494,9");
            Assert.AreEqual("24", day.GetPartOne());
        }

        [TestMethod()]
        public void GetPartTwoTest()
        {
            Day14 day = new Day14("498,4 -> 498,6 -> 496,6\r\n503,4 -> 502,4 -> 502,9 -> 494,9");
            Assert.AreEqual("93", day.GetPartTwo());
        }
    }
}