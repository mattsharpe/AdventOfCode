using System.Collections.Generic;
using AdventOfCode.Utilities.Day11;
using NUnit.Framework;

namespace AdventOfCode.Tests
{
    [TestFixture]
    class Day11StateFixture
    {

        [Test]
        public void StateEquality()
        {
            Assert.AreEqual(StateA, StateB);
        }

        [Test]
        public void StateHashCodeEquality()
        {
            Assert.AreEqual(StateA.GetHashCode(), StateB.GetHashCode());
        }

        [Test]
        public void StateSetEquality()
        {
            var set = new HashSet<State> { StateA };
            Assert.That(set.Contains(StateB));
        }

        private State StateA = new State();
        private State StateB = new State();
    }
}
