namespace Lab11
{
    // Represents a single graphical cell on the board that can be drawn using a character and colors.
    // Inherits from AbstractGraphic2D, which provides properties for rendering in the console.
    public class Cell : AbstractGraphic2D
    {
        // X-coordinate of the cell on the board.
        public decimal X { get; }

        // Y-coordinate of the cell on the board.
        public decimal Y { get; }

        // The cell's horizontal bounds (equal since it's a single point).
        public override decimal LowerBoundX { get; protected set; }

        public override decimal UpperBoundX { get; protected set; }

        // The cell's vertical bounds (equal since it's a single point).
        public override decimal LowerBoundY { get; protected set; }

        public override decimal UpperBoundY { get; protected set; }

        // Constructor initializes the cell at a specific (x, y) location.
        // The bounding box is set to exactly match the cell's coordinates.
        public Cell(decimal x, decimal y)
        {
            X = x;
            Y = y;

            LowerBoundX = UpperBoundX = X;
            LowerBoundY = UpperBoundY = Y;
        }

        // Determines whether the specified point (x, y) is exactly this cell.
        public override bool ContainsPoint(decimal x, decimal y)
        {
            return X == x && Y == y;
        }
    }
}
