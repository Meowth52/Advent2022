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
    public class Day12Tests
    {
        [TestMethod()]
        public void GetPartOneTest()
        {
            Day12 day = new Day12("Sabqponm\r\nabcryxxl\r\naccszExk\r\nacctuvwj\r\nabdefghi");
            Assert.AreEqual("31", day.GetPartOne());
        }

        [TestMethod()]
        public void GetPartTwoTest()
        {
            Day12 day = new Day12("Sabqponm\r\nabcryxxl\r\naccszExk\r\nacctuvwj\r\nabdefghi");
            Assert.Fail();
        }
    }
}