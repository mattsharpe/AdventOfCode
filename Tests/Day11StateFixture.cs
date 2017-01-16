using System.Collections.Generic;
using AdventOfCode.Utilities.Day11;
using NUnit.Framework;

namespace AdventOfCode.Tests
{
    [TestFixture]
    class Day11StateFixture
    {
        [TestCaseSource(nameof(TestData))]
        public void StateEquality(State a, State b)
        {
            Assert.That(Equals(a, b));
        }

        [TestCaseSource(nameof(TestData))]
        public void StateHashCodeEquality(State a, State b)
        {
            Assert.AreEqual(a.GetHashCode(), b.GetHashCode());
        }
        
        [TestCaseSource(nameof(TestData))]
        public void StateSetEquality(State a, State b)
        {
            var set = new HashSet<State> { a };
            Assert.That(set.Contains(b));
        }
        
        [TestCaseSource(nameof(MismatchedTestCaseData))]
        public void StateInequality(State a, State b)
        {
            Assert.IsFalse(Equals(a,b));
        }

        [TestCaseSource(nameof(MismatchedTestCaseData))]
        public void StateHashCodeInequality(State a, State b)
        {
            Assert.AreNotEqual(a.GetHashCode(), b.GetHashCode());
        }

        [TestCaseSource(nameof(MismatchedTestCaseData))]
        public void StateSetInequality(State a, State b)
        {
            var set = new HashSet<State> { a };
            Assert.IsFalse(set.Contains(b));
        }
        
        public static IEnumerable<TestCaseData> TestData()
        {
            yield return new TestCaseData(new State(), new State()) {TestName = "Empty States"};
            yield return new TestCaseData(new State {CurrentFloor = 1}, new State {CurrentFloor = 1}) {TestName = "Simple Comparison"};
            yield return new TestCaseData(Day11Fixture.SampleData, Day11Fixture.SampleData.Clone(false)){TestName = "Cloned Sample Data"};
            yield return new TestCaseData(Day11Fixture.Part1StartState, Day11Fixture.Part1StartState.Clone(false)){TestName = "Cloned Part 1 Data"};
        }

        public static IEnumerable<TestCaseData> MismatchedTestCaseData()
        {
            yield return new TestCaseData(Day11Fixture.SampleData, Day11Fixture.Part1StartState) {TestName = "Mismatched start state"};
        }

        [Test]
        public void HashCodesAreOrderSensitive()
        {
            var stateA = new State
            {
                ItemsOnFloor =
                {
                    [0] = new List<Item>
                    {
                        new Item("hydrogen", ElementType.MicroChip),
                        new Item("lithium", ElementType.MicroChip),
                    }
                }
            };

            var stateB = new State
            {
                ItemsOnFloor =
                {
                    [0] = new List<Item>
                    {
                        new Item("lithium", ElementType.MicroChip),
                        new Item("hydrogen", ElementType.MicroChip),
                    }
                }
            };
            Assert.That(new HashSet<Item>(stateA.ItemsOnFloor[0]).SetEquals(stateB.ItemsOnFloor[0]));
            
            Assert.IsTrue(Equals(stateA, stateB));
            Assert.AreEqual(stateA.GetHashCode(), stateB.GetHashCode());
        }

        [Test]
        public void VisitedStates()
        {
            var set = new HashSet<State>();

            set.Add(Day11Fixture.SampleData);
            Assert.AreEqual(1, set.Count);

            set.Add(Day11Fixture.SampleData);
            Assert.AreEqual(1, set.Count);

            set.Add(Day11Fixture.SampleData.Clone());
            Assert.AreEqual(1, set.Count);

        }
    }
}
