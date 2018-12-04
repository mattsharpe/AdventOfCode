using Advent2016.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2016.Tests
{
    [TestClass]
    public class Day12Fixture
    {
        private Day12 _day12;

        [TestInitialize]
        public void Setup()
        {
            _day12 = new Day12();
        }

        [TestMethod]
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

            _day12.ProcessInstructions(instructions);

            Assert.AreEqual(42, _day12.A);
        }

        [TestMethod]
        public void Increment()
        {
            Assert.AreEqual(0, _day12.A);
            _day12.ProcessInstructions(new []{"inc a"});
            Assert.AreEqual(1, _day12.A);

            Assert.AreEqual(0, _day12.B);
            _day12.ProcessInstructions(new[] { "inc b"});
            Assert.AreEqual(1, _day12.B);

            Assert.AreEqual(0, _day12.C);
            _day12.ProcessInstructions(new[] { "inc c"});
            Assert.AreEqual(1, _day12.C);

            Assert.AreEqual(0, _day12.D);
            _day12.ProcessInstructions(new[] { "inc d"});
            Assert.AreEqual(1, _day12.D);
        }

        [TestMethod]
        public void Decrement()
        {
            _day12.A = _day12.B = _day12.C = _day12.D = 10;
            Assert.AreEqual(10, _day12.A);
            _day12.ProcessInstructions(new[] { "dec a"});

            Assert.AreEqual(9, _day12.A);

            Assert.AreEqual(10, _day12.B);
            _day12.ProcessInstructions(new[] { "dec b"});
            Assert.AreEqual(9, _day12.B);

            Assert.AreEqual(10, _day12.C);
            _day12.ProcessInstructions(new[] { "dec c"});
            Assert.AreEqual(9, _day12.C);

            Assert.AreEqual(10, _day12.D);
            _day12.ProcessInstructions(new[] { "dec d"});
            Assert.AreEqual(9, _day12.D);
        }

        [TestMethod]
        public void CopyValueToRegister()
        {
            Assert.AreEqual(0, _day12.A);
            _day12.ProcessInstructions(new[] { "cpy 41 a"});

            Assert.AreEqual(41, _day12.A);
        }

        [TestMethod]
        public void CopyRegisterToRegister()
        {
            _day12.A = 123;
            
            _day12.ProcessInstructions(new[] { "cpy a b"});

            Assert.AreEqual(123,_day12.B);
        }

        [TestMethod]
        public void Part1()
        {
            _day12.Part1();
            Assert.AreEqual(317993, _day12.A);
        }

        [TestMethod]
        public void Part2()
        {
            _day12.Part2();
            Assert.AreEqual(9227647, _day12.A);
        }
    }
}
