using System.Linq;
using Advent2015.Solutions;
using Advent2015.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2015.Tests
{
    [TestClass]
    public class Day5Fixture
    {
        private Day5 _day5 = new Day5();

        [TestMethod]
        public void Nice_ugknbfddgicrmopn()
        {
            //ugknbfddgicrmopn is nice because it has at least three vowels (u...i...o...), a double letter (...dd...), 
            //and none of the disallowed substrings.
            Assert.IsTrue(_day5.IsNice("ugknbfddgicrmopn"));
        }

        [TestMethod]
        public void Nice_aaa()
        {
            //aaa is nice because it has at least three vowels and a double letter, 
            // even though the letters used by different rules overlap.
            Assert.IsTrue(_day5.IsNice("aaa"));
        }

        [TestMethod]
        public void Naughty_jchzalrnumimnmhp()
        {
            //jchzalrnumimnmhp is naughty because it has no double letter.
            Assert.IsFalse(_day5.IsNice("jchzalrnumimnmhp"));
        }

        [TestMethod]
        public void Naughty_haegwjzuvuyypxyu()
        {
            //haegwjzuvuyypxyu is naughty because it contains the string xy.
            Assert.IsFalse(_day5.IsNice("haegwjzuvuyypxyu"));
        }

        [TestMethod]
        public void Naughty_dvszwmarrgswjxmb()
        {
            //dvszwmarrgswjxmb is naughty because it contains only one vowel.
            Assert.IsFalse(_day5.IsNice("dvszwmarrgswjxmb"));
        }

        [TestMethod]
        public void Part1()
        {
            var input = FileReader.ReadFile("day5.txt");
            Assert.AreEqual(238, input.Count(x => _day5.IsNice(x)));
        }

        [TestMethod]
        public void Part2()
        {
            var input = FileReader.ReadFile("day5.txt");
            Assert.AreEqual(69, input.Count(x => _day5.IsNice2(x)));
        }

        [TestMethod]
        public void Nice2_qjhvhtzxzqqjkmpb()
        {
            //qjhvhtzxzqqjkmpb is nice because is has a pair that appears twice (qj) and a letter that repeats with exactly one letter between them (zxz).
            Assert.IsTrue(_day5.IsNice2("qjhvhtzxzqqjkmpb"));
        }

        [TestMethod]
        public void Nice2_xxyxx()
        {
            //xxyxx is nice because it has a pair that appears twice and a letter that repeats with one between, even though the letters used by each rule overlap.
            Assert.IsTrue(_day5.IsNice2("xxyxx"));
        }

        [TestMethod]
        public void Naughty2_uurcxstgmygtbstg()
        {
            //uurcxstgmygtbstg is naughty because it has a pair (tg) but no repeat with a single letter between them.
            Assert.IsFalse(_day5.IsNice2("uurcxstgmygtbstg"));
        }

        [TestMethod]
        public void Naughty2_ieodomkazucvgmuy()
        {
            //ieodomkazucvgmuy is naughty because it has a repeating letter with one between (odo), but no pair that appears twice.
            Assert.IsFalse(_day5.IsNice2("ieodomkazucvgmuy"));
        }
    }
}
