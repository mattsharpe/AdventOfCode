using System;
using System.Collections.Generic;

namespace Advent2015.Solutions
{
    class Day03
    {
        public Day03()
        {
            SantaX = 0;
            SantaY = 0;
            RobotX = 0;
            RobotY = 0;

            Visited = new HashSet<Tuple<int, int>>
            {
                new Tuple<int, int>(SantaX, SantaY),
                new Tuple<int, int>(RobotX, RobotY)
            };
        }

        public int SantaX { get; set; }
        public int SantaY { get; set; }

        public int RobotX { get; set; }
        public int RobotY { get; set; }

        public HashSet<Tuple<int, int>> Visited;

        public void ProcessInstructions(string input, bool helperRobot = false)
        {
            int index = 0;
            foreach (var instruction in input)
            {
                index++;
                bool santa = index % 2 != 1 || !helperRobot;

                switch (instruction)
                {
                    case '<':
                        if (santa)
                            SantaX--;
                        else
                            RobotX--;
                        break;

                    case '>':
                        if (santa)
                            SantaX++;
                        else
                            RobotX++;
                        break;
                    case '^':
                        if (santa)
                            SantaY--;
                        else
                            RobotY--;
                        break;
                    case 'v':
                        if (santa)
                            SantaY++;
                        else
                            RobotY++;
                        break;
                    default:
                        throw new Exception("Uknown instruction");
                }

                Visited.Add(new Tuple<int,int>(SantaX, SantaY));
                Visited.Add(new Tuple<int,int>(RobotX, RobotY));
            }
        }
    }
}
