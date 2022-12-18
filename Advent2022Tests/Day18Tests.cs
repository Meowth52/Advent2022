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
    public class Day18Tests
    {
        [TestMethod()]
        public void GetPartOneTest()
        {
            Day18 day = new Day18("2,2,2\r\n1,2,2\r\n3,2,2\r\n2,1,2\r\n2,3,2\r\n2,2,1\r\n2,2,3\r\n2,2,4\r\n2,2,6\r\n1,2,5\r\n3,2,5\r\n2,1,5\r\n2,3,5");
            Assert.AreEqual("64", day.GetPartOne());
        }

        [TestMethod()]
        public void GetPartTwoTest()
        {
            Day18 day = new Day18("2,2,2\r\n1,2,2\r\n3,2,2\r\n2,1,2\r\n2,3,2\r\n2,2,1\r\n2,2,3\r\n2,2,4\r\n2,2,6\r\n1,2,5\r\n3,2,5\r\n2,1,5\r\n2,3,5");
            Assert.AreEqual("140", day.GetPartTwo());
        }
    }
}