using System;

namespace AdventOfCode.Solutions
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
        private bool[,] _display = new bool[6,50];

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
            var data = instruction.Substring(5).Split('x');
            var x = Convert.ToInt32(data[0]);
            var y = Convert.ToInt32(data[1]);

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    _display[i, j] = true;
                }
            }
        }

        public void RotateRow(string instruction)
        {
            
        }

        public void RotateColumn(string instruction)
        {
            
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
            for (int i = 0; i < _display.GetLength(0); i++)
            {
                for (int j = 0; j < _display.GetLength(1); j++)
                {
                    Console.Write(_display[i, j] ? "1 " : "0 ");
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
        }
    }
}
