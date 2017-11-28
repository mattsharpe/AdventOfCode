using System.Linq;
using Advent2015.Solutions;
using Advent2015.Utilities;
using NUnit.Framework;

namespace Advent2015.Tests
{
    [TestFixture]
    public class Day5Fixture
    {
        private Day5 _day5 = new Day5();

        [Test]
        public void Nice_ugknbfddgicrmopn()
        {
            //ugknbfddgicrmopn is nice because it has at least three vowels (u...i...o...), a double letter (...dd...), 
            //and none of the disallowed substrings.
            Assert.That(_day5.IsNice("ugknbfddgicrmopn"));
        }

        [Test]
        public void Nice_aaa()
        {
            //aaa is nice because it has at least three vowels and a double letter, 
            // even though the letters used by different rules overlap.
        Assert.That(_day5.IsNice("aaa"));
        }

        [Test]
        public void Naughty_jchzalrnumimnmhp()
        {
            //jchzalrnumimnmhp is naughty because it has no double letter.
            Assert.False(_day5.IsNice("jchzalrnumimnmhp"));
        }

        [Test]
        public void Naughty_haegwjzuvuyypxyu()
        {
            //haegwjzuvuyypxyu is naughty because it contains the string xy.
            Assert.False(_day5.IsNice("haegwjzuvuyypxyu"));
        }

        [Test]
        public void Naughty_dvszwmarrgswjxmb()
        {
            //dvszwmarrgswjxmb is naughty because it contains only one vowel.
            Assert.False(_day5.IsNice("dvszwmarrgswjxmb"));
        }

        [Test]
        public void Part1()
        {
            var input = FileReader.ReadFile("day5.txt");
            Assert.AreEqual(238, input.Count(x => _day5.IsNice(x)));
        }

        [Test]
        public void Part2()
        {
            var input = FileReader.ReadFile("day5.txt");
            Assert.AreEqual(69, input.Count(x => _day5.IsNice2(x)));
        }

        [Test]
        public void Nice2_qjhvhtzxzqqjkmpb()
        {
            //qjhvhtzxzqqjkmpb is nice because is has a pair that appears twice (qj) and a letter that repeats with exactly one letter between them (zxz).
            Assert.That(_day5.IsNice2("qjhvhtzxzqqjkmpb"));
        }

        [Test]
        public void Nice2_xxyxx()
        {
            //xxyxx is nice because it has a pair that appears twice and a letter that repeats with one between, even though the letters used by each rule overlap.
            Assert.That(_day5.IsNice2("xxyxx"));
        }

        [Test]
        public void Naughty2_uurcxstgmygtbstg()
        {
            //uurcxstgmygtbstg is naughty because it has a pair (tg) but no repeat with a single letter between them.
            Assert.False(_day5.IsNice2("uurcxstgmygtbstg"));
        }

        [Test]
        public void Naughty2_ieodomkazucvgmuy()
        {
            //ieodomkazucvgmuy is naughty because it has a repeating letter with one between (odo), but no pair that appears twice.
            Assert.False(_day5.IsNice2("ieodomkazucvgmuy"));
        }
    }
}
