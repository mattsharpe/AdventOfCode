using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Advent2016.Utilities;

namespace Advent2016.Solutions
{
    /*
--- Day 10: Balance Bots ---

You come upon a factory in which many robots are zooming around handing small microchips to each other.

Upon closer examination, you notice that each bot only proceeds when it has two microchips, and once it does, 
it gives each one to a different bot or puts it in a marked "output" bin. Sometimes, bots take microchips from "input" bins, too.

Inspecting one of the microchips, it seems like they each contain a single number; the bots must use some logic to decide what to do with each chip. 
You access the local control computer and download the bots' instructions (your puzzle input).

Some of the instructions specify that a specific-valued microchip should be given to a specific bot; 
the rest of the instructions indicate what a given bot should do with its lower-value or higher-value chip.

For example, consider the following instructions:

value 5 goes to bot 2
bot 2 gives low to bot 1 and high to bot 0
value 3 goes to bot 1
bot 1 gives low to output 1 and high to bot 0
bot 0 gives low to output 2 and high to output 0
value 2 goes to bot 2
Initially, bot 1 starts with a value-3 chip, and bot 2 starts with a value-2 chip and a value-5 chip.
Because bot 2 has two microchips, it gives its lower one (2) to bot 1 and its higher one (5) to bot 0.
Then, bot 1 has two microchips; it puts the value-2 chip in output 1 and gives the value-3 chip to bot 0.
Finally, bot 0 has two microchips; it puts the 3 in output 2 and the 5 in output 0.
In the end, output bin 0 contains a value-5 microchip, output bin 1 contains a value-2 microchip, 
and output bin 2 contains a value-3 microchip. In this configuration, bot number 2 is responsible for comparing value-5 microchips with value-2 microchips.

Based on your instructions, what is the number of the bot that is responsible for comparing value-61 microchips with value-17 microchips?
    */
    public class Day10
    {
        private Dictionary<int,Bot> _bots = new Dictionary<int, Bot>();
        private Dictionary<int,Bot> _outputs = new Dictionary<int, Bot>();

        private Regex _valueRegex = new Regex(@"value (\d+) goes to bot (\d+)");
        private Regex _botRegex = new Regex(@"bot (\d+) gives low to (bot|output) (\d+) and high to (bot|output) (\d+)");

        public void Part1()
        {
            var input = FileReader.ReadFile("day 10 instructions.txt");
            ProcessInstructions(input);
        }

        public void ProcessInstructions(string[] input)
        {
            //value 67 goes to bot 187
            //bot 150 gives low to output 11 and high to bot 53
            var setup = new Queue<string>();
            var inputValues = new Queue<string>();

            foreach (var instruction in input.Where(x=>_botRegex.IsMatch(x)))
            {
               
                var match = _botRegex.Match(instruction);
                var botId = Convert.ToInt32(match.Groups[1].Value);
                var lowDestinationType = match.Groups[2].Value;
                var lowDestination = Convert.ToInt32(match.Groups[3].Value);
                var highDestinationType = match.Groups[4].Value;
                var highDestination = Convert.ToInt32(match.Groups[5].Value);
                var bot = GetBot(botId);

                bot.LowBotTarget = lowDestinationType == "bot" ? 
                    GetBot(lowDestination) : 
                    GetOutput(lowDestination);

                bot.HighBotTarget = highDestinationType == "bot" ? 
                    GetBot(highDestination) : 
                    GetOutput(highDestination);
                
            }

            foreach (var instruction in input.Where(x=>_valueRegex.IsMatch(x)))
            {
                var inputs = _valueRegex.Match(instruction);
                var chipToAssign = Convert.ToInt32(inputs.Groups[1].Value);
                var botIdToAssignTo = Convert.ToInt32(inputs.Groups[2].Value);

                GetBot(botIdToAssignTo).ReceiveChip(chipToAssign);   
            }
        }

        public Bot FindBotResponsibleFor(int low, int high)
        {
            return _bots.Single(x => x.Value.Low == low && x.Value.High == high).Value;
        }

        private Bot GetOutput(int id)
        {
            if (!_outputs.ContainsKey(id))
            {
                var bot = new Bot { Id = id };
                _outputs.Add(id, bot);
            }

            return _outputs[id];
        }

        private Bot GetBot(int id)
        {
            if (!_bots.ContainsKey(id))
            {
                var bot = new Bot { Id = id };
                _bots.Add(id, bot);
            }
            
            return _bots[id];
        }

        public int ValueOfOutputs()
        {
            return GetOutput(0).ChipValue*GetOutput(1).ChipValue*GetOutput(2).ChipValue;
        }
    }
}
