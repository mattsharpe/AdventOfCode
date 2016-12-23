using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Solutions;
using AdventOfCode.Utilities;
using NUnit.Framework;

namespace AdventOfCode.Tests
{
    [TestFixture]
    public class Day7Fixture
    {
        private Day7 _day7 = new Day7();

        [Test]
        public void Sample1()
        {
            var input = "abba[mnop]qrst";
            var result = _day7.SupportsTLS(input);
            Assert.IsTrue(result);
        }

        [Test]
        public void Sample2()
        {
            var input = "abcd[bddb]xyyx";
            var result = _day7.SupportsTLS(input);
            Assert.IsFalse(result);
        }

        [Test]
        public void Sample3()
        {
            var input = "aaaa[qwer]tyui";
            var result = _day7.SupportsTLS(input);
            Assert.IsFalse(result);
        }

        [Test]
        public void Sample4()
        {
            var input = "ioxxoj[asdfgh]zxcvbn";
            var result = _day7.SupportsTLS(input);
            Assert.IsTrue(result);
        }
        
        [Test]
        public void Part1()
        {
            var result = _day7.Part1();
            Assert.AreEqual(105, result);
        }
    }
}
