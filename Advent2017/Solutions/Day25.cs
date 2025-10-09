using System.Text.RegularExpressions;

namespace Advent2017.Solutions
{
    public record State(string Name, StateTransition Transition0, StateTransition Transition1);
    public record StateTransition(int Value, int Direction, string NextState);

    internal class Day25
    {
        public int Part1(string[] input)
        {
            var (startState, steps, states) = ParseInput(input);
            return RunTuringMachine(startState, steps, states);
        }

        public (string startState, int steps, Dictionary<string, State> states) ParseInput(string[] input)
        {
            
            // Parse initial state and step count
            var startState = Regex.Match(input[0], @"Begin in state (\w)\.").Groups[1].Value;
            var steps = int.Parse(Regex.Match(input[1], @"Perform a diagnostic checksum after (\d+) steps\.").Groups[1].Value);

            // Parse all state definitions with a single regex
            var statePattern = @"In state (\w):\s+" +
                              @"If the current value is 0:\s+" +
                              @"- Write the value (\d)\.\s+" +
                              @"- Move one slot to the (\w+)\.\s+" +
                              @"- Continue with state (\w)\.\s+" +
                              @"If the current value is 1:\s+" +
                              @"- Write the value (\d)\.\s+" +
                              @"- Move one slot to the (\w+)\.\s+" +
                              @"- Continue with state (\w)\.";

            var states = new Dictionary<string, State>();
            
            foreach (Match match in Regex.Matches(string.Join(Environment.NewLine, input), statePattern, RegexOptions.Multiline))
            {
                var stateName = match.Groups[1].Value;
                var state = new State(
                    stateName,
                    new StateTransition(
                        int.Parse(match.Groups[2].Value),
                        match.Groups[3].Value == "right" ? 1 : -1,
                        match.Groups[4].Value
                    ),
                    new StateTransition(
                        int.Parse(match.Groups[5].Value),
                        match.Groups[6].Value == "right" ? 1 : -1,
                        match.Groups[7].Value
                    )
                );
                
                states[stateName] = state;
            }

            return (startState, steps, states);
        }

        private int RunTuringMachine(string startState, int steps, Dictionary<string, State> states)
        {
            var tape = new Dictionary<int, int>(); 
            int position = 0;
            string currentState = startState;

            for (int step = 0; step < steps; step++)
            {
                // Read current value (default to 0 if not set)
                int currentValue = tape.GetValueOrDefault(position, 0);

                // Get current state and appropriate transition
                var state = states[currentState];
                var transition = currentValue == 0 ? state.Transition0 : state.Transition1;

                // Execute transition
                tape[position] = transition.Value;
                position += transition.Direction;
                currentState = transition.NextState;
            }

            // Count the number of 1s on the tape
            return tape.Values.Count(x => x == 1);
        }
    }
}
