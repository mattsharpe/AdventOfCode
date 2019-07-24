using System.Linq;
using Advent2018.Solutions;
using Advent2018.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2018.Tests
{
    [TestClass]
    public class Day16Tests
    {
        private Day16 _day16;

        [TestInitialize]
        public void TestInitialize()
        {
            _day16 = new Day16();
        }

        [TestMethod]
        public void Addr()
        {
            _day16.Registers[0] = 2;
            _day16.Registers[1] = 2;

            _day16.Operators.Single(x => x.Name == "Addr").Action(0, 1, 2);

            Assert.AreEqual(4, _day16.Registers[2]);
        }

        [TestMethod]
        public void Addi()
        {
            _day16.Registers[0] = 2;
            _day16.Operators.Single(x => x.Name == "Addi").Action(0, 5, 2);

            Assert.AreEqual(7, _day16.Registers[2]);
        }

        [TestMethod]
        public void Mulr()
        {
            _day16.Registers[2] = 10;
            _day16.Registers[3] = 3;
            _day16.Operators.Single(x => x.Name == "Mulr").Action(2, 3, 1);

            Assert.AreEqual(30, _day16.Registers[1]);
        }

        [TestMethod]
        public void Muli()
        {
            _day16.Registers[2] = 10;
            _day16.Operators.Single(x => x.Name == "Muli").Action(2, 2, 1);

            Assert.AreEqual(20, _day16.Registers[1]);
        }

        [TestMethod]
        public void Banr()
        {
            _day16.Registers[0] = 3;
            _day16.Registers[1] = 2;
            _day16.Operators.Single(x => x.Name == "Banr").Action(0, 1, 2);

            Assert.AreEqual(2, _day16.Registers[2]);
        }

        [TestMethod]
        public void Bani()
        {
            _day16.Registers[0] = 3;
            _day16.Operators.Single(x => x.Name == "Bani").Action(0, 2, 2);

            Assert.AreEqual(2, _day16.Registers[2]);
        }

        [TestMethod]
        public void Borr()
        {
            _day16.Registers[0] = 22;
            _day16.Registers[1] = 34;
            _day16.Operators.Single(x => x.Name == "Borr").Action(0, 1, 2);

            Assert.AreEqual(54, _day16.Registers[2]);
        }

        [TestMethod]
        public void Bori()
        {
            _day16.Registers[0] = 22;
            _day16.Operators.Single(x => x.Name == "Bori").Action(0, 34, 2);

            Assert.AreEqual(54, _day16.Registers[2]);
        }

        [TestMethod]
        public void Setr()
        {
            _day16.Registers[0] = 123;
            _day16.Registers[1] = 321;
            _day16.Operators.Single(x => x.Name == "Setr").Action(0, 123, 1);

            Assert.AreEqual(123, _day16.Registers[0]);
        }

        [TestMethod]
        public void Seti()
        {
            _day16.Registers[0] = 123;
            _day16.Operators.Single(x => x.Name == "Seti").Action(456, 123, 0);

            Assert.AreEqual(456, _day16.Registers[0]);
        }

        [TestMethod]
        public void GtirTrue()
        {
            _day16.Registers[0] = 1;
            _day16.Registers[1] = 2;
            _day16.Registers[2] = 3;
            _day16.Operators.Single(x => x.Name == "Gtir").Action(5, 1, 2);

            Assert.AreEqual(1, _day16.Registers[2]);
        }

        [TestMethod]
        public void GtirFalse()
        {
            _day16.Registers[0] = 1;
            _day16.Registers[1] = 2;
            _day16.Registers[2] = 3;
            _day16.Operators.Single(x => x.Name == "Gtir").Action(0, 1, 2);

            Assert.AreEqual(0, _day16.Registers[2]);
        }

        [TestMethod]
        public void GtriTrue()
        {
            _day16.Registers[0] = 5;
            _day16.Registers[2] = 3;
            _day16.Operators.Single(x => x.Name == "Gtri").Action(0, 1, 2);

            Assert.AreEqual(1, _day16.Registers[2]);
        }

        [TestMethod]
        public void GtriFalse()
        {
            _day16.Registers[0] = 1;
            _day16.Registers[1] = 2;
            _day16.Registers[2] = 3;
            _day16.Operators.Single(x => x.Name == "Gtri").Action(0, 2, 2);

            Assert.AreEqual(0, _day16.Registers[2]);
        }

        [TestMethod]
        public void GtrrTrue()
        {
            _day16.Registers[0] = 5;
            _day16.Registers[1] = 2;
            _day16.Registers[2] = 3;
            _day16.Operators.Single(x => x.Name == "Gtrr").Action(0, 1, 2);

            Assert.AreEqual(1, _day16.Registers[2]);
        }

        [TestMethod]
        public void GtrrFalse()
        {
            _day16.Registers[0] = 1;
            _day16.Registers[1] = 2;
            _day16.Registers[2] = 3;
            _day16.Operators.Single(x => x.Name == "Gtrr").Action(0, 1, 2);

            Assert.AreEqual(0, _day16.Registers[2]);
        }

        [TestMethod]
        public void EqirTrue()
        {
            _day16.Registers[1] = 2;
            _day16.Registers[2] = 3;
            _day16.Operators.Single(x => x.Name == "Eqir").Action(2, 1, 2);

            Assert.AreEqual(1, _day16.Registers[2]);
        }

        [TestMethod]
        public void EqirFalse()
        {
            _day16.Registers[1] = 2;
            _day16.Registers[2] = 3;
            _day16.Operators.Single(x => x.Name == "Eqir").Action(123, 1, 2);

            Assert.AreEqual(0, _day16.Registers[2]);
        }

        [TestMethod]
        public void EqriTrue()
        {
            _day16.Registers[1] = 2;
            _day16.Registers[2] = 3;
            _day16.Operators.Single(x => x.Name == "Eqri").Action(1, 2, 2);

            Assert.AreEqual(1, _day16.Registers[2]);
        }

        [TestMethod]
        public void EqriFalse()
        {
            _day16.Registers[1] = 2;
            _day16.Registers[2] = 3;
            _day16.Operators.Single(x => x.Name == "Eqri").Action(1, 123, 2);

            Assert.AreEqual(0, _day16.Registers[2]);
        }

        [TestMethod]
        public void EqrrTrue()
        {
            _day16.Registers[0] = 3;
            _day16.Registers[1] = 3;
            _day16.Operators.Single(x => x.Name == "Eqrr").Action(0, 1, 2);

            Assert.AreEqual(1, _day16.Registers[2]);
        }

        [TestMethod]
        public void EqrrFalse()
        {
            _day16.Registers[0] = 2;
            _day16.Registers[1] = 3;
            _day16.Operators.Single(x => x.Name == "Eqrr").Action(0, 1, 2);

            Assert.AreEqual(0, _day16.Registers[2]);
        }

        [TestMethod]
        public void ParseSampleInput()
        {
            string[] input =
            {
                "Before: [3, 2, 1, 1]",
                "9 2 1 2",
                "After:  [3, 2, 2, 1]"
            };
            var result = _day16.ParseInput(input).ToList();

            Assert.AreEqual(1, result.Count());
            CollectionAssert.AreEqual(result.First().Before, new[] { 3, 2, 1, 1 });
            CollectionAssert.AreEqual(result.First().Instruction, new[] { 9, 2, 1, 2 });
            CollectionAssert.AreEqual(result.First().After, new[] { 3, 2, 2, 1 });
        }

        [TestMethod]
        public void VerifySample()
        {
            string[] input =
            {
                "Before: [3, 2, 1, 1]",
                "9 2 1 2",
                "After:  [3, 2, 2, 1]"
            };
            var registers = new[] { 3, 2, 1, 1 };
            var instruction = new[] { 9, 2, 1, 2 };
            var target = new[] { 3, 2, 2, 1 };

            var result = _day16.TestInput((registers, instruction, target));

            Assert.AreEqual(3, result.Count);
        }

        [TestMethod]
        public void HowManyCommandsHave3OrMoreOperators()
        {
            var input = FileReader.ReadFile("day16-instructions.txt");
            Assert.AreEqual(596, _day16.HowManySamplesMatch3OrMoreOperators(input));
        }

        [TestMethod]
        public void ProcessInput()
        {
            _day16.BuildOperators(FileReader.ReadFile("day16-instructions.txt"));
            var input = FileReader.ReadFile("day16-input.txt");
            _day16.ProcessOperations(input);
            Assert.AreEqual(554, _day16.Registers[0]);
        }
    }
}
