namespace AdventOfCode2016.Days
{
    public static class Day2
    {
        public class KeyPad{
            string[,] Layout { get; set; }

            int X { get; set; }
            int Y { get; set; }

            public KeyPad(int startX, int startY, string[,] layout){
                X = startX;
                Y = startY;
                Layout = layout;
            }

            public string GetCurrentNumber() {
                // The first accessor refers to the vertical rows, so invert
                // the X and Y values here
                return Layout[Y, X];
            }

            public void Move(char direction) {
                switch (direction){
                    // In order to generalize to non rectangular keypads,
                    // we allow padding the sides with -1 and only move if
                    // moving won't take us into a -1 area or out of bounds
                    case 'U':
                        if (Y - 1 >= 0 && Layout[Y - 1, X] != "-1")
                        {
                            Y--; // Up is represented by lower values
                        }
                        break;
                    case 'D':
                        if (Y + 1 < Layout.GetLength(0) && Layout[Y + 1, X] != "-1")
                        {
                            Y++;
                        }
                        break;
                    case 'L':
                        if (X - 1 >= 0 && Layout[Y, X - 1] != "-1")
                        {
                            X--;
                        }
                        break;
                    case 'R':
                        if (X + 1 < Layout.GetLength(1) && Layout[Y, X + 1] != "-1")
                        {
                            X++;
                        }
                        break;
                }
            }

        }

        public static void Solution(string[] input)
        {
            // Initialize keypad for Part 1
            string[,] layout = new string[,] {
                {"1","2","3"},
                {"4","5","6"},
                {"7","8","9"}
            };
            KeyPad keypad = new KeyPad(1, 1, layout);

            // Loop through input, storing value at the end of each command
            string code = "";
            foreach (string command in input) {
                foreach (char movement in command) {
                    keypad.Move(movement);
                }
                code += keypad.GetCurrentNumber();
            }

            Console.WriteLine($"The guessed bathroom code is {code}.");

            // Repeat the same thing for part 2 with a different layout.
            layout = new string[,] {
                {"-1", "-1", "1", "-1", "-1"},
                {"-1", "2", "3", "4", "-1"},
                {"5", "6", "7", "8", "9"},
                {"-1", "A", "B", "C", "-1"},
                {"-1", "-1", "D", "-1", "-1"}
            };
            keypad = new KeyPad(0, 2, layout);

            // Loop through input, storing value at the end of each command
            code = "";
            foreach (string command in input) {
                foreach (char movement in command) {
                    keypad.Move(movement);
                }
                code += keypad.GetCurrentNumber();
            }

            Console.WriteLine($"The actual bathroom code is {code}.");
        }
    }
}