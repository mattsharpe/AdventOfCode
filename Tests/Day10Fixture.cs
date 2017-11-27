using Advent2016.Solutions;
using NUnit.Framework;

namespace Advent2016.Tests
{
    [TestFixture]
    public class Day10Fixture
    {
        private Day10 _day10;

        [SetUp]
        public void Setup()
        {
            _day10 = new Day10();
        }

        [Test]
        public void Part1()
        {
            _day10.Part1();
            var bot = _day10.FindBotResponsibleFor(17, 61);

            Assert.AreEqual(27,bot.Id); // Too High
        }

        [Test]
        public void SampleDataPart1()
        {
            var input = new[]
            {
                "value 5 goes to bot 2",
                "bot 2 gives low to bot 1 and high to bot 0",
                "value 3 goes to bot 1",
                "bot 1 gives low to output 1 and high to bot 0",
                "bot 0 gives low to output 2 and high to output 0",
                "value 2 goes to bot 2"
            };

            _day10.ProcessInstructions(input);

            var bot = _day10.FindBotResponsibleFor(2, 5);

            Assert.AreEqual(2, bot.Id);

        }

        [Test]
        public void Part2()
        {
            _day10.Part1();
            int result  =_day10.ValueOfOutputs();
            Assert.AreEqual(13727, result); //too low
        }
    }
}
