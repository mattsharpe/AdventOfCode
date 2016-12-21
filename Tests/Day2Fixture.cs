using System;
using System.Linq;
using AdventOfCode.Solutions;
using AdventOfCode.Utilities;
using NUnit.Framework;

namespace AdventOfCode.Tests
{
    [TestFixture]
    public class Day2Fixture
    {
        private Day2 _day2;

        [SetUp]
        public void Setup()
        {
            _day2 = new Day2 { CurrentKey = 5 };
        }

        [Test]
        public void Part1()
        {
            var input =@"ULUULLUULUUUUDURUUULLDLDDRDRDULULRULLRLULRUDRRLDDLRULLLDRDRRDDLLLLDURUURDUDUUURDRLRLLURUDRDULURRUDLRDRRLLRDULLDURURLLLULLRLUDDLRRURRLDULRDDULDLRLURDUDRLLRUDDRLRDLLDDUURLRUDDURRLRURLDDDURRDLLDUUDLLLDUDURLUDURLRDLURURRLRLDDRURRLRRDURLURURRRULRRDLDDDDLLRDLDDDRDDRLUUDDLDUURUULDLUULUURRDRLDDDULRRRRULULLRLLDDUDRLRRLLLLLDRULURLLDULULLUULDDRURUDULDRDRRURLDRDDLULRDDRDLRLUDLLLDUDULUUUUDRDRURDDULLRDRLRRURLRDLRRRRUDDLRDDUDLDLUUDLDDRRRDRLLRLUURUDRUUULUDDDLDUULULLRUDULULLLDRLDDLLUUDRDDDDRUDURDRRUUDDLRRRRURLURLD
LDLUDDLLDDRLLDLDRDDDDDUURUDDDUURLRLRLDULLLDLUDDDULLDUDLRUUDDLUULLDRLDDUDLUDDLURRRLDUURDDRULLURLLRLLUUDRLDDDLDLDRDUDLRDURULDLDRRDRLDLUURRRRLUDDULDULUUUDULDDRLLDDRRUULURRUURRLDUUUDDDDRUURUDRRRDDDDLRLURRRRUUDDDULRRURRDLULRURDDRDRLUDLURDDRDURRUURDUDUDRRDDURRRDURDLUUUURRUDULLDDRLLLURLDUDRRLDDLULUDUDDDDUDLUUULUURUDRURUUDUUURRLDUUDRDRURLLDLLLLLRLLUDURDRRLULRRDDDRLDRDDURLRDULULLDDURURLRRDRULDULUUUURLDURUDUDUDDLUDRRDURULRDULLLDRRDLDLUDURDULULLDDURDDUDRUUUDUDRLDUURDUUUDUURURUDRULRURLDLRDDURDLUU
DDLDRLLDRRDRRLLUUURDDULRDUDRDRUDULURLLDDLRRRUDRDLDLURRRULUDRDLULLULLDUUDRLRUDDLRRURRUULRLDLLLDLRLLLURLLLURLLRDDLULLDUURLURDLLDLDUDLDRUUUDDLLDRRRRRUDRURUURRRDRUURDRDDRLDUUULUDUDRUDLLLLDRDRURRRDUUURLDLRLRDDDRLUDULDRLLULRDLDURDLDURUUDDULLULRDDRLRUURLLLURDRUURUUDUUULRDUDDRDURRRDUUDRRRUDRDLRURDLLDDDURLLRRDDDDLDULULDRLDRULDDLRRRLUDLLLLUDURRRUURUUULRRLDUURDLURRLRLLRDLRDDRDDLRDLULRUUUDDDUDRRURDDURURDDUDLURUUURUUUUDURDDLDRDULDRLDRLLRLRRRLDRLLDDRDLDLUDDLUDLULDLLDRDLLRDULDUDDULRRRUUDULDULRRURLRDRUDLDUDLURRRDDULRDDRULDLUUDDLRDUURDRDR
URDURRRRUURULDLRUUDURDLLDUULULDURUDULLUDULRUDUUURLDRRULRRLLRDUURDDDLRDDRULUUURRRRDLLDLRLRULDLRRRRUDULDDURDLDUUULDURLLUDLURULLURRRDRLLDRRDULUDDURLDULLDURLUDUULRRLLURURLDLLLURDUDRLDDDRDULLUDDRLDDRRRLDULLLLDUURULUDDDURUULUUUDURUDURDURULLLDRULULDRRLDRLDLRLRUDUDURRLURLRUUDRRDULULDLLDRDRRRDUDUURLDULLLURRDLUDDLDDRDDUDLDDRRRUDRULLURDDULRLDUDDDRULURLLUDLLRLRRDRDRRURUUUURDLUURRDULLRDLDLRDDRDRLLLRRDDLDDDDLUDLRLULRRDDRDLDLUUUDLDURURLULLLDDDULURLRRURLDDRDDLD
UDUULLRLUDLLUULRURRUUDDLLLDUURRURURDDRDLRRURLLRURLDDDRRDDUDRLLDRRUDRDRDDRURLULDDLDLRRUDDULLRLDDLRURLUURUURURDLDUDRLUUURRRLUURUDUDUUDDLDULUULRLDLLURLDRUDRLLRULURDLDDLLULLDRRUUDDLRRRUDDLRDRRRULDRDDRRULLLUDRUULURDUDRDLRRLDLRLRLDDULRRLULUUDDULDUDDULRRURLRDRDURUDDDLLRLDRDRULDDLLRLLRDUDDDDDDRLRLLDURUULDUUUDRURRLLRLDDDDRDRDUURRURDRDLLLUDDRDRRRDLUDLUUDRULURDLLLLLRDUDLLRULUULRLULRURULRLRRULUURLUDLDLLUURDLLULLLDDLRUDDRULRDLULRUURLDRULRRLULRLRULRDLURLLRURULRDRDLRRLRRDRUUURURULLLDDUURLDUDLLRRLRLRULLDUUUULDDUUU";

            var result = _day2.CalculateDoorCode(input);

            Assert.AreEqual(52981, result);
        }

        [Test]
        public void SampleTest()
        {
            string input = @"ULL
RRDDD
LURDL
UUUUD
";
            var result = _day2.CalculateDoorCode(input);

            Assert.AreEqual(1985, result);
        }

        [Test]
        public void Test_ModuloArithmetic()
        {
            foreach (var key in Enumerable.Range(1, 9))
            {
                Console.WriteLine("Keypad Number {0}", key);
                Console.WriteLine(key / 4);
                Console.WriteLine(key % 4);
                Console.WriteLine("-----------");
            }
        }

        [Test]
        public void TestLine1()
        {
            string input = "ULL";
            int result = _day2.ProcessLine(input);
            Assert.AreEqual(1, result);
        }

        [Test]
        public void TestLine2()
        {
            string input = "RRDDD";
            int result = _day2.ProcessLine(input);
            Assert.AreEqual(9, result);
        }

        [Test]
        public void TestLine3()
        {
            string input = "LURDL";
            int result = _day2.ProcessLine(input);
            Assert.AreEqual(4, result);
        }

        [Test]
        public void TestLine4()
        {
            string input = "UUUUD";
            int result = _day2.ProcessLine(input);
            Assert.AreEqual(5, result);
        }

        [Test]
        public void TestDirectionUp()
        {
            _day2.ProcessInstruction('U');
            Assert.AreEqual(1, _day2.CurrentLocation.X);
            Assert.AreEqual(0, _day2.CurrentLocation.Y);
        }

        [Test]
        public void TestDirectionDown()
        {
            _day2.ProcessInstruction('D');
            Assert.AreEqual(1, _day2.CurrentLocation.X);
            Assert.AreEqual(2, _day2.CurrentLocation.Y);
        }

        [Test]
        public void TestDirectionLeft()
        {
            _day2.ProcessInstruction('L');
            Assert.AreEqual(0, _day2.CurrentLocation.X);
            Assert.AreEqual(1, _day2.CurrentLocation.Y);
        }

        [Test]
        public void TestDirectionRight()
        {
            _day2.ProcessInstruction('R');
            Assert.AreEqual(2, _day2.CurrentLocation.X);
            Assert.AreEqual(1, _day2.CurrentLocation.Y);
        }

        [Test, Sequential]
        public void LocationMapsToKey(
            [Values(0, 0, 0, 1, 1, 1, 2, 2, 2)] int x,
            [Values(0, 1, 2, 0, 1, 2, 0, 1, 2)] int y, 
            [Values(1, 4, 7, 2, 5, 8, 3, 6, 9)] int expected)
        {
            _day2.CurrentLocation = new Location(x,y);
            var result = _day2.GetCurrentKeyPadNumber();
            Assert.AreEqual(expected, result);
        }
    }
}
