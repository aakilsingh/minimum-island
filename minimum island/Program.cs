namespace minimum_island
{
    public class Program
    {
        public static int minimumIsland(List<List<string>> grid) 
        {
            HashSet<(int,int)> visited = new HashSet<(int,int)> (); // keep track of the visited nodes
            double minSize = double.PositiveInfinity; // setting min size intially to a massive value
            // here we iterate through the grid
            // and then call the recursive traversal

            for (int r = 0; r < grid.Count; r++) { 
            
                for (int c = 0; c < grid[0].Count; c++)
                {
                    double size = explore(r, c, visited, grid);

                    if(size < minSize && size!= 0) // making sure the size is not 0 as this is what we returned when we reached a base case
                    {
                        minSize = size;
                    }
                }
            
            }
        
            return (int) minSize; // casting to an int
        }

        public static double explore(int r, int c, HashSet<(int, int)> visited, List<List<string>> grid)
        {
            bool rowInbounds = r >= 0 && r < grid.Count; // in bound for row: if row is less than the count of rows AND row is greater than equal to 0 then it is inbounds
            bool colInbounds = c >= 0 && c < grid[0].Count; // in bounds for column

            if (!rowInbounds || !colInbounds) // base case 1: check if we are at an out of bounds place
            {
                return 0; // return 0 so we dont mess up the count
            }

            if (grid[r][c] == "W") // base case 2: checks if our current position is water
            {
                return 0;
            }

            if (visited.Contains((r,c))) // base case 3 : check if we have visited the node already
            {
                return 0;
            }

           

            // now we start our traversal

            (int,int) currentNode = (r,c);
            visited.Add(currentNode);
            double totalSize = 1; // track size of the island

            totalSize += explore(r - 1, c, visited, grid); // traverse up
            totalSize += explore(r + 1, c, visited, grid); // traverse down
            totalSize += explore(r , c - 1, visited, grid); // traverse left
            totalSize += explore(r , c + 1, visited, grid); // traverse right

            return totalSize;

        }

       public static void Main(string[] args)
        {
        
            List<List<string>> grid = new List<List<string>>
            {
                new List<string> {"W", "L", "W", "W", "W"},
                new List<string> {"W", "L", "W", "W", "W"},
                new List<string> {"W", "W", "W", "L", "W"},
                new List<string> {"W", "W", "L", "L", "W"},
                new List<string> {"L", "W", "W", "L", "L"},
                new List<string> {"L", "L", "W", "W", "W"},
            };

            
            Console.WriteLine(minimumIsland(grid));
        }
    }
}
