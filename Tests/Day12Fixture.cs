using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Solutions;
using NUnit.Framework;

namespace AdventOfCode.Tests
{
    [TestFixture]
    class Day12Fixture
    {
        private Day12 _day12;

        [SetUp]
        public void Setup()
        {
            _day12 = new Day12();
        }

        [Test]
        public void SampleData()
        {
            string[] instructions =
            {
                "cpy 41 a",
                "inc a",
                "inc a",
                "dec a",
                "jnz a 2",
                "dec a"
            };

            foreach (var instruction in instructions)
            {
                _day12.ProcessInstruction(instruction);
            }

            Assert.AreEqual(42, _day12.A);
        }

        [Test]
        public void Increment()
        {
            Assert.AreEqual(0, _day12.A);
            _day12.ProcessInstruction("inc a");
            Assert.AreEqual(1, _day12.A);

            Assert.AreEqual(0, _day12.B);
            _day12.ProcessInstruction("inc b");
            Assert.AreEqual(1, _day12.B);

            Assert.AreEqual(0, _day12.C);
            _day12.ProcessInstruction("inc c");
            Assert.AreEqual(1, _day12.C);

            Assert.AreEqual(0, _day12.D);
            _day12.ProcessInstruction("inc d");
            Assert.AreEqual(1, _day12.D);
        }

        [Test]
        public void Decrement()
        {
            _day12.A = _day12.B = _day12.C = _day12.D = 10;
            Assert.AreEqual(10, _day12.A);
            _day12.ProcessInstruction("dec a");
            Assert.AreEqual(9, _day12.A);

            Assert.AreEqual(10, _day12.B);
            _day12.ProcessInstruction("dec b");
            Assert.AreEqual(9, _day12.B);

            Assert.AreEqual(10, _day12.C);
            _day12.ProcessInstruction("dec c");
            Assert.AreEqual(9, _day12.C);

            Assert.AreEqual(10, _day12.D);
            _day12.ProcessInstruction("dec d");
            Assert.AreEqual(9, _day12.D);
        }
    }
}
