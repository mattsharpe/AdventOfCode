using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Advent2019.Solutions
{
    class Day13
    {
        private IntCodeComputer _computer =new IntCodeComputer();
        
        public int CountNumberOfBlocks(string program)
        {
            _computer.InitializePositions(program);
            var task = Task.Run(() => _computer.RunProgram());

            task.Wait();
            var blocks = new List<long>();
            var output = new List<long>(_computer.Outputs);
            for(var i=2; i <output.Count; i += 3)
            {
               blocks.Add(output[i]);
            }

            return blocks.Count(x=>x == 2);
            
        }
    }
}
