using Advent2016.Utilities;
using NUnit.Framework;

namespace Advent2016.Tests
{
    [TestFixture]
    public class TriangleFixture
    {
        [Test]
        public void BuildMeATriangle()
        {
            var input = "  330  143  338";
            var triangle = new Triangle(input);

            Assert.AreEqual(330, triangle.A);
            Assert.AreEqual(143, triangle.B);
            Assert.AreEqual(338, triangle.C);
        }

        [Test]
        public void ValidTriangle()
        {
            var triangle = new Triangle {A = 5, B = 10, C = 7};
            Assert.IsTrue(triangle.IsValid());
        }

        [Test]
        public void InvalidTriangle()
        {
            var triangle = new Triangle {A = 5, B = 10, C = 25};
            Assert.IsFalse(triangle.IsValid());
        }
    }
}
