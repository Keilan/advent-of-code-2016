namespace AdventOfCode2016.Days
{
    public static class Day3
    {
        static int countValidVerticalTriangles(List<List<int>> triangles)
        {
            int validTriangles = 0;
            for (int i = 0; i < 3; i++){
                // Get the triangle from the vertical index
                List<int> triangle = triangles.Select(t => t[i]).ToList();
                triangle.Sort();
                if (triangle[0] + triangle[1] > triangle[2])
                {
                    validTriangles++;
                }
            }
            return validTriangles;
        }
        
        public static void Solution(string[] input)
        {
            // Part 1
            int validTriangles = 0;
            foreach (string triangle in input)
            {
                // Split the triangles, ignore empty strings and convert to integers
                List<int> values = triangle.Split()
                    .Where(t => t != "")
                    .Select(t => int.Parse(t)).ToList();

                // Sort the values - in invalid triangles the sums of the two smallest
                // are not greater than the largest value
                values.Sort();
                if (values[0] + values[1] > values[2])
                {
                    validTriangles++;
                }
            }
            Console.WriteLine($"{validTriangles} of the triangles are valid.");

            // Part 2
            validTriangles = 0;

            // Read the rows 3 at a time, once we have 3, get triangles
            List<List<int>> buffer = new List<List<int>>();
            foreach (string triangle in input)
            {

                // Add the values
                List<int> values = triangle.Split()
                    .Where(t => t != "")
                    .Select(t => int.Parse(t)).ToList();
                buffer.Add(values);

                // Get valid triangles once we have a set of 3
                if (buffer.Count == 3)
                {
                    validTriangles += countValidVerticalTriangles(buffer);
                    buffer.Clear();
                }
            }
            Console.WriteLine($"{validTriangles} of the triangles are actually valid.");
        }
    }
}