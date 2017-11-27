using System;
using System.Linq;
using Advent2016.Solutions;
using Advent2016.Utilities.Day11;
using NUnit.Framework;

namespace Advent2016.Tests
{
    [TestFixture]
    public class Day11Fixture
    {
        private Day11 _day11;

        [SetUp]
        public void Setup()
        {
            _day11 = new Day11();
        }

        [Test]
        public void SampleDataTest()
        {
            var result = _day11.CalculateMinimumNumberOfSteps(SampleData);
            
            Assert.AreEqual(11, result);
        }

        [Test]
        public void Part1Test()
        {
            var result = _day11.CalculateMinimumNumberOfSteps(Part1StartState);
            
            Assert.AreEqual(47, result);
        }

        [Test]
        public void Part2Test()
        {
            var result = _day11.CalculateMinimumNumberOfSteps(Part2StartState);
            
            Assert.AreEqual(71, result);
        }


        public static State SampleData
        {
            get
            {
                State.Elements = new[] {"Hy","Li"};
                var state = new State
                {
                    Items = new[]
                    {
                     1, 0, //hydrogen
                     2, 0, //lithium
                    }
                };
                
                return state;
            }
        }

        //The first floor contains a polonium generator, a thulium generator, a thulium-compatible microchip, a promethium generator, a ruthenium generator, a ruthenium-compatible microchip, a cobalt generator, and a cobalt-compatible microchip.
        //The second floor contains a polonium-compatible microchip and a promethium-compatible microchip.
        //The third floor contains nothing relevant.
        //The fourth floor contains nothing relevant.
        public static State Part1StartState
        {
            get
            {
                State.Elements = new[] { "Po", "Th", "Pr", "Ru", "Co" };
                var state = new State
                {
                    Items = new[]
                    {
                        0, 1, // Polonium
                        0, 0, // Thulium
                        0, 1, // Promethium
                        0, 0, // Ruthenium
                        0, 0, // Cobalt
                    }
                };

                return state;
            }
        }
        
        public static State Part2StartState
        {
            get
            {
                State.Elements = new[] { "Po", "Th", "Pr", "Ru", "Co", "El", "Di" };
                var state = new State
                {
                    Items = new[]
                    {
                        0, 1, // Polonium
                        0, 0, // Thulium
                        0, 1, // Promethium
                        0, 0, // Ruthenium
                        0, 0, // Cobalt
                        0, 0, // Elerium
                        0, 0, // Dilithium
                    }
                };

                return state;
            }
        }

        [Test]
        public void SampleDataStartState()
        {
            var state = SampleData;
            state.PrintState();
        }

        [Test]
        public void BuildStartState()
        {
            var state = new State
            {
                Items = new[]
                {
                    0, 1, // Polonium
                    0, 0, // Thulium
                    0, 1, // Promethium
                    0, 0, // Ruthenium
                    0, 0, // Cobalt
                    //0, 0, // Elerium
                    //0, 0, // Dilithium
                }
            };
			
			state.PrintState();
        }

        [Test]
        public void GenerateNextStates()
        {
            var nextMoves = _day11.GenerateNextStates(SampleData);
            foreach (var nextMove in nextMoves)
            {
                Console.WriteLine();
                nextMove.PrintState();
                
            }
			Assert.AreEqual(1, nextMoves.Count());
        }

        [Test]
        public void ValidState()
        {
            Assert.IsTrue(SampleData.Valid);
        }

        [Test]
        public void InvalidState()
        {
            State.Elements = new[] { "Hy", "Li" };
            var invalidState = new State
            {
                Items = new[]
                {
                    0, 1, // Hydrogen
                    1, 1, // Lithium
                }
            };

            Assert.IsFalse(invalidState.Valid);
        }


        [Test]
        public void ValidStateMultipleMatchedPairs()
        {
            State.Elements = new[] { "Hy", "Li" };
            var state = new State
            {
                Items = new[]
                {
                    1, 1, // Hydrogen
                    1, 1, // Lithium
                }
            };

            Assert.IsTrue(state.Valid);
        }

        [Test]
        public void IncompleteState()
        {
            Assert.IsFalse(SampleData.Complete);
        }

        [Test]
        public void CompleteState()
        {
            State.Elements = new[] { "Hy", "Li" };
            var state = new State
            {
                Items = new[]
                {
                    3, 3, // Hydrogen
                    3, 3, // Lithium
                }
            };
            
            Assert.IsTrue(state.Valid);
            Assert.IsTrue(state.Complete);
        }

        [Test]
        public void DontRevisitExploredStates()
        {
            Assert.AreEqual(0, _day11.VisitedStates.Count);
            var first = _day11.GenerateNextStates(SampleData).ToList();
            Assert.AreEqual(1, _day11.VisitedStates.Count);

            var second = first.SelectMany(x => _day11.GenerateNextStates(x)).ToList();
            Assert.AreEqual(2, _day11.VisitedStates.Count);

            var third = second.SelectMany(x => _day11.GenerateNextStates(x)).ToList();
            Assert.AreEqual(4, _day11.VisitedStates.Count);
        }
    }
}

