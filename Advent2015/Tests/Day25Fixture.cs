using Advent2015.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2015.Tests
{
    [TestClass]
    public class Day25Fixture
    {
        private Day25 _day25;

        [TestInitialize]
        public void Initialize()
        {
            _day25 = new Day25();
        }

        [TestMethod]
        public void Run()
        {
            //To continue, please consult the code grid in the manual.  Enter the code at row 3010, column 3019.
            var result = _day25.Solve(3010, 3019);
            Assert.AreEqual(8997277, result);
        }
        

    }
}
