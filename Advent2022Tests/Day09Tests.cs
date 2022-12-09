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
    public class Day09Tests
    {
        [TestMethod()]
        public void GetPartOneTest()
        {
            Day09 day = new Day09("R 4\r\nU 4\r\nL 3\r\nD 1\r\nR 4\r\nD 1\r\nL 5\r\nR 2");
            Assert.AreEqual("13", day.GetPartOne());
        }

        [TestMethod()]
        public void GetPartTwoTest()
        {
            Day09 day = new Day09("R 5\r\nU 8\r\nL 8\r\nD 3\r\nR 17\r\nD 10\r\nL 25\r\nU 20");
            Assert.AreEqual("36", day.GetPartTwo());
        }
    }
}