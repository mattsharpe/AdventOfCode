using Advent2019.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2019.Tests
{
    [TestClass]
    class Day08Tests
    {
        private Day08 _day08;

        [TestInitialize]
        public void TestInitialize() => _day08 = new Day08();

        [TestMethod]
        public void ParseSmallInput()
        {
            var input = "123456789012";
            _day08.ParseLayers(input,3,2);
        }
    }
}
