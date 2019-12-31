using System.Collections.Generic;
using System.Linq;

namespace Advent2019.Solutions
{
    class Day13
    {
        private readonly IntCodeComputer _computer =new IntCodeComputer();
        public Dictionary<(long x, long y), long> Grid { get; } = new Dictionary<(long x, long y), long>();
        public (long x, long y) Paddle { get; set; }
        public (long x, long y) Ball { get; set; }
        public long Score { get; set; }

        public int CountNumberOfBlocks(string program)
        {
            _computer.InitializePositions(program);
            _computer.RunProgram();
            
            UpdateScreen();
            return Grid.Count(x=> x.Value.Equals(2));
        }


        private void UpdateScreen()
        {
            while (_computer.Outputs.Count >= 3)
            {
                var x = _computer.Outputs.Take();
                var y = _computer.Outputs.Take();
                var cell = _computer.Outputs.Take();

                switch (cell)
                {
                    case 0:
                    case 1:
                    case 2:
                        Grid[(x, y)] = cell;
                        break;
                    case 3:
                        Paddle = (x, y);
                        Grid[(x, y)] = cell;
                        break;
                    case 4:
                        Ball = (x, y);
                        Grid[(x, y)] = cell;
                        break;
                }

                if (x == -1 && y == 0)
                {
                    Score = cell;
                }
            }
        }
        
        public long PlayBreakout(string program)
        {
            _computer.InitializePositions(program);
            //insert a quarter
            _computer.Addresses[0] = 2;
            _computer.SupplyInputValue = () =>
            {
                UpdateScreen();

                long joystickDirection = 0;
                if (Ball.x < Paddle.x)
                {
                    joystickDirection = -1;
                }
                else if (Ball.x > Paddle.x)
                {
                    joystickDirection = 1;
                }

                return joystickDirection;
            };

            _computer.RunProgram();
            //Run one last time after the program halts as there's still values on the output queue
            UpdateScreen();

            return Score;
        }
    }
}
