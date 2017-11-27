using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent2016.Utilities
{
    public class Bot
    {
        public int Id { get; set; }
        public Bot LowBotTarget { get; set; }
        public Bot HighBotTarget { get; set; }


        private List<int> _chips = new List<int>();

        public int Low { get; private set; }
        public int High { get; private set; }
        
        public void ReceiveChip(int chip)
        {
            if(_chips.Count == 2)
                throw new Exception("I've already got two chips, I can't hold any more!");

            _chips.Add(chip);
            if (_chips.Count == 2 && LowBotTarget != null && HighBotTarget != null)
            {
                High = _chips.Max();
                Low = _chips.Min();
                
                HighBotTarget.ReceiveChip(High);
                LowBotTarget.ReceiveChip(Low);
            }
        }

        public int ChipValue
        {
            get
            {
                if(_chips.Count!=1)
                    throw new InvalidOperationException("This only works for output containers");
                return _chips.First();
            }
        }
        

    }
}