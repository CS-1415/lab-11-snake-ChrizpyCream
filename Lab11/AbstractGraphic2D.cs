namespace Lab11
{
    // Abstract base class for 2D graphical elements with display character and color settings.
    public abstract class AbstractGraphic2D : IGraphic2D
    {
        // Determines whether the specified point (x, y) lies within the shape,
        // including the border. This must be implemented by derived classes.
        public abstract bool ContainsPoint(decimal x, decimal y);

        // Bounding box properties that define the extents of the shape.
        public abstract decimal LowerBoundX { get; protected set; } // Minimum X coordinate of the shape
        public abstract decimal UpperBoundX { get; protected set; } // Maximum X coordinate of the shape
        public abstract decimal LowerBoundY { get; protected set; } // Minimum Y coordinate of the shape
        public abstract decimal UpperBoundY { get; protected set; } // Maximum Y coordinate of the shape

        // Character used to render the shape on the console.
        public char DisplayChar { get; set; }

        // Foreground color of the display character.
        public ConsoleColor ForegroundColor { get; set; }

        // Background color behind the display character.
        public ConsoleColor BackgroundColor { get; set; }

        // Static method to display a list of 2D shapes.
        // Shapes that cannot be fully rendered due to console buffer limitations will be skipped.
        public static void Display(List<IGraphic2D> shapes)
        {
            bool skippedSome = false;
            foreach (IGraphic2D shape in shapes)
            {
                if (!shape.Display())
                {
                    skippedSome = true;
                }
            }

            if (skippedSome)
            {
                Console.WriteLine("Warning: Some shapes were not fully displayed due to buffer size limitations.");
            }
        }

        // Displays the current shape on the console based on its bounding box and properties.
        // Returns true if all parts were displayed successfully; false if any parts were skipped.
        public bool Display()
        {
            Console.ForegroundColor = ForegroundColor;
            Console.BackgroundColor = BackgroundColor;

            int lowX = (int)decimal.Floor(LowerBoundX);
            int lowY = (int)decimal.Floor(LowerBoundY);
            int highX = (int)decimal.Floor(UpperBoundX);
            int highY = (int)decimal.Floor(UpperBoundY);

            bool skippedSome = false;

            for (int row = lowY; row <= highY; row++)
            {
                for (int column = lowX; column <= highX; column++)
                {
                    // Only display if the point is part of the shape.
                    if (ContainsPoint(column, row))
                    {
                        // Ensure we're not writing outside the console buffer limits.
                        if (column < Console.BufferWidth && row < Console.BufferHeight)
                        {
                            Console.SetCursorPosition(column, row);
                            Console.Write(DisplayChar);
                        }
                        else
                        {
                            skippedSome = true;
                        }
                    }
                }
            }

            // Reset console colors and cursor position after drawing.
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(0, 0);

            return !skippedSome;
        }
    }
}
