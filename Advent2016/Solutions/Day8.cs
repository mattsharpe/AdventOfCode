using System;
using System.Linq;
using System.Text;
using System.Threading;
using Advent2016.Utilities;

namespace Advent2016.Solutions
{
    /*
    --- Day 8: Two-Factor Authentication ---

You come across a door implementing what you can only assume is an implementation of two-factor authentication after a long game of requirements telephone.

To get past the door, you first swipe a keycard (no problem; there was one on a nearby desk). Then, it displays a code on a little screen, and you type that code on a keypad. Then, presumably, the door unlocks.

Unfortunately, the screen has been smashed. After a few minutes, you've taken everything apart and figured out how it works. Now you just have to work out what the screen would have displayed.

The magnetic strip on the card you swiped encodes a series of instructions for the screen; these instructions are your puzzle input. The screen is 50 pixels wide and 6 pixels tall, all of which start off, and is capable of three somewhat peculiar operations:

rect AxB turns on all of the pixels in a rectangle at the top-left of the screen which is A wide and B tall.
rotate row y=A by B shifts all of the pixels in row A (0 is the top row) right by B pixels. Pixels that would fall off the right end appear at the left end of the row.
rotate column x=A by B shifts all of the pixels in column A (0 is the left column) down by B pixels. Pixels that would fall off the bottom appear at the top of the column.
For example, here is a simple sequence on a smaller screen:

rect 3x2 creates a small rectangle in the top-left corner:

###....
###....
.......
rotate column x=1 by 1 rotates the second column down by one pixel:

#.#....
###....
.#.....
rotate row y=0 by 4 rotates the top row right by four pixels:

....#.#
###....
.#.....
rotate column x=1 by 1 again rotates the second column down by one pixel, causing the bottom pixel to wrap back to the top:

.#..#.#
#.#....
.#.....
As you can see, this display technology is extremely powerful, and will soon dominate the tiny-code-displaying-screen market. That's what the advertisement on the back of the display tries to convince you, anyway.

There seems to be an intermediate check of the voltage used by the display: after you swipe your card, if the screen did work, how many pixels should be lit?
    */

    class Day8
    {
        //50 pixels wide and 6 tall.
        private bool[,] _display = new bool[50,6];

        public Day8()
        {
            _display.Initialize();
        }

        public void ProcessInstruction(string instruction)
        {
            //rect AxB
            //rotate row y=A by B
            //rotate column y=A by B
            if (instruction.StartsWith("rect"))
            {
                Rectangle(instruction);
            }
            else if (instruction.StartsWith("rotate row"))
            {
                RotateRow(instruction);
            }
            else if (instruction.StartsWith("rotate column"))
            {
                RotateColumn(instruction);
            }

        }

        public void Rectangle(string instruction)
        {
            //rect 3x3
            var data = instruction.Substring(5).Split('x');
            var x = Convert.ToInt32(data[0]);
            var y = Convert.ToInt32(data[1]);

            for (int xLocation= 0; xLocation < x; xLocation++)
            {
                for (int yLocation = 0; yLocation < y; yLocation++)
                {
                    _display[xLocation, yLocation] = true;
                }
            }
        }

        public void RotateRow(string instruction)
        {
            //rotate row y=0 by 36
            var parts = instruction.Replace("rotate row y=", "").Replace(" by ", ",").Split(',');
            var row = Convert.ToInt32(parts[0]);
            var distance = Convert.ToInt32(parts[1]);

            //first read the old data into a list
            var unchanged = Enumerable.Range(0, _display.GetLength(0))
                .Select(x => _display[x, row])
                .ToList();

            for (int x = 0; x < unchanged.Count; x++)
            {
                var targetColumn = (x + distance) % _display.GetLength(0);
                _display[targetColumn, row] = unchanged[x];
            }
        }

        public void RotateColumn(string instruction)
        {
            //rotate column x=1 by 1
            var parts = instruction.Replace("rotate column x=", "").Replace(" by ", ",").Split(',');
            var column = Convert.ToInt32(parts[0]);
            var distance = Convert.ToInt32(parts[1]);

            //first read the old data into a list
            var unchanged = Enumerable.Range(0, _display.GetLength(1))
                .Select(x => _display[column, x])
                .ToList();
            
            for (int y = 0; y < unchanged.Count; y++)
            {
                var targetRow = (y + distance)%_display.GetLength(1);
                _display[column, targetRow] = unchanged[y];
            }
        }

        public int ActivePixels
        {
            get
            {
                int i = 0;
                foreach (var value in _display)
                {
                    if (value)
                    {
                        i++;
                    }
                }
                return i;
            }
        }

        public void PrintArray()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int y = 0; y < _display.GetLength(1); y++)
            {
                for (int x = 0; x < _display.GetLength(0); x++)
                {
                    sb.Append(_display[x, y] ? "#" : ".");
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }

        public void Part1(bool animate = false)
        {
            var input = FileReader.ReadFile("day8 instructions.txt");
            foreach (var instruction in input)
            {
                ProcessInstruction(instruction);
                if (animate)
                {
                    Console.Clear();
                    PrintArray();
                    Thread.Sleep(50);
                }
            }
            
        }
    }
}
