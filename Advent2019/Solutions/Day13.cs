using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

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

        public void MoveJoystick()
        {
            long joystickDirection = 0;
            if (Ball.x < Paddle.x)
            {
                joystickDirection = -1;
            } 
            else if(Ball.x > Paddle.x)
            {
                joystickDirection = 1;
            }
            _computer.Inputs.Enqueue(joystickDirection);
        }

        private void UpdateScreen()
        {
            while (_computer.Outputs.Count >= 3)
            {
                _computer.Outputs.TryDequeue(out var x);
                _computer.Outputs.TryDequeue(out var y);
                _computer.Outputs.TryDequeue(out var cell);

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
            
            var task = Task.Run(_computer.RunProgram);
            
            while (!task.IsCompleted && !Grid.Any(x=>Equals( x.Value == 2)))
            {
                if (_computer.WaitingForInput)
                {
                    UpdateScreen();
                    MoveJoystick();
                    //Yuck, one to revisit. Potential locking on the input Queue?
                    //Whose idea was it to multithread this?
                    Thread.Sleep(1);
                }
            }

            UpdateScreen();
            return Score;
        }
    }
}
