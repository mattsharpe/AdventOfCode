using Advent2017.Solutions;
using Advent2017.Utilities;

namespace Advent2017.Tests
{
    [TestClass]
    public class Day25Fixture
    {
        private readonly string[] _sample = [
            "Begin in state A.",
            "Perform a diagnostic checksum after 6 steps.",
            "",
            "In state A:",
            "  If the current value is 0:",
            "    - Write the value 1.",
            "    - Move one slot to the right.",
            "    - Continue with state B.",
            "  If the current value is 1:",
            "    - Write the value 0.",
            "    - Move one slot to the left.",
            "    - Continue with state B.",
            "",
            "In state B:",
            "  If the current value is 0:",
            "    - Write the value 1.",
            "    - Move one slot to the left.",
            "    - Continue with state A.",
            "  If the current value is 1:",
            "    - Write the value 1.",
            "    - Move one slot to the right.",
            "    - Continue with state A."
        ];

        private string[] _input = FileReader.ReadFile("day25.txt");

        private Day25 _day = new();

        [TestInitialize]
        public void Initialize()
        {
            _day = new Day25();
        }

        [TestMethod]
        public void Part1Sample()
        {
            Assert.AreEqual(3, _day.Part1(_sample));
        }

        [TestMethod]
        public void Part1()
        {
            Assert.AreEqual(2794, _day.Part1(_input));
        }
    }
}
