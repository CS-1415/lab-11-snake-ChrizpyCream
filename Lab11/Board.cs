namespace Lab11
{
    public class Board
    {
        // 2D grid representing the board's cells
        public Cell[,] Grid { get; set; }

        // List of graphical elements to display on the board
        public List<IGraphic2D> Display { get; set; }

        // Dimensions of the board
        public int Height { get; set; }
        public int Width { get; set; }

        // Current apple on the board
        public Cell Apple { get; set; }

        // List of snakes on the board
        public List<Snake> snakes { get; set; }

        // Random number generator for apple placement
        private Random rand = new Random();

        // Constructor initializes the board with given height and width
        public Board(int height, int width)
        {
            Height = height;
            Width = width;
            Grid = new Cell[Height, Width];

            Apple = RandomApple();
            snakes = new List<Snake>();

            Display = new List<IGraphic2D>
            {
                Apple
            };
        }

        // Generates a new apple at a random location that can be placed
        // Ensures apple does not spawn outside the console buffer size
        public Cell RandomApple()
        {
            int maxX = Math.Min(Width, Console.BufferWidth);
            int maxY = Math.Min(Height, Console.BufferHeight);

            int NextX = rand.Next(0, maxX);
            int NextY = rand.Next(0, maxY);

            while (!canBePlaced(NextX, NextY))
            {
                NextX = rand.Next(0, maxX);
                NextY = rand.Next(0, maxY);
            }

            return new Cell(NextX, NextY)
            {
                BackgroundColor = ConsoleColor.Red,
                DisplayChar = 'A'
            };
        }

        // Places a new apple on the board, replacing the old one
        public void NextApple()
        {
            int maxX = Math.Min(Width, Console.BufferWidth);
            int maxY = Math.Min(Height, Console.BufferHeight);

            int NextX = rand.Next(0, maxX);
            int NextY = rand.Next(0, maxY);

            while (!canBePlaced(NextX, NextY))
            {
                NextX = rand.Next(0, maxX);
                NextY = rand.Next(0, maxY);
            }

            Apple = new Cell(NextX, NextY)
            {
                BackgroundColor = ConsoleColor.Red,
                DisplayChar = 'A'
            };

            Display.Clear();
            Display = new List<IGraphic2D> { Apple };
        }

        // Returns true if a cell can be placed at (x, y), ensuring it's within usable bounds
        public bool canBePlaced(int x, int y)
        {
            return x > 1 && x < Width && y > 1 && y < Height;
        }
    }
}
