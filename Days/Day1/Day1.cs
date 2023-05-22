using System.IO;

namespace AdventOfCode2016.Days
{
    public static class Day1
    {
        public class Walker{
            public int X {get;set;} // East is increasing
            public int Y {get;set;} // North is increasing
            public char Facing {get;set;}

            /// <summary>
            /// Turn the walker either left or right.
            /// </summary>
            /// <param name="direction">Either L (left) or R (right)</param>
            public void turn(char direction){
                // A switch statement + ternary operator to determine the
                // new direction based on which way we're turning.
                switch (Facing) {
                    case 'N':
                        Facing = direction == 'L' ? 'W' : 'E';
                        break;
                    case 'E':
                        Facing = direction == 'L' ? 'N' : 'S';
                        break;
                    case 'S':
                        Facing = direction == 'L' ? 'E' : 'W';
                        break;
                    case 'W':
                        Facing = direction == 'L' ? 'S' : 'N';
                        break;
                }
            }

            /// <summary>
            /// Move the walker forward in the faced direction.
            /// </summary>
            /// <param name="blocks"></param>
            public void move(int blocks){
                switch (Facing) {
                    case 'N':
                        Y += blocks;
                        break;
                    case 'E':
                        X += blocks;
                        break;
                    case 'S':
                        Y -= blocks;
                        break;
                    case 'W':
                        X -= blocks;
                        break;
                }
            }
        }
        
        public static void Solution(string[] input)
        {
            // This problem only has one line of input
            string inputLine = input[0];
            string[] instructions = inputLine.Split(", ");

            // Track visited positions
            HashSet<(int X, int Y)> visited = new HashSet<(int X, int Y)>();
            visited.Add((0, 0)); // Add starting position
            (int X, int Y)? location = null;

            // Initialize the walker
            Walker walker = new Walker { X=0, Y=0, Facing='N' };
            foreach(string instruction in instructions){
                walker.turn(instruction[0]);

                // Take 1 step at a time to track each visited location
                int distance = int.Parse(instruction.Substring(1));
                while (distance > 0)
                {
                    walker.move(1);
                    // Update visited list
                    if (location == null && visited.Contains((walker.X, walker.Y))){
                        location = (walker.X, walker.Y);
                    }
                    visited.Add((walker.X, walker.Y));
                    distance--;
                }
            }

            if (location is null){
                throw new Exception("No location found.");
            }

            int distance1 = Math.Abs(walker.X) + Math.Abs(walker.Y);
            Console.WriteLine($"Easter Bunny HQ is {distance1} blocks away.");

            int distance2 = Math.Abs(location.Value.X) + Math.Abs(location.Value.Y);
            Console.WriteLine($"Part 2 HQ is {distance2} blocks away.");
        }
    }
}