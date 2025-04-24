namespace Lab11
{
    // Represents a circular shape that can be rendered on a 2D console grid.
    // Inherits from AbstractGraphic2D to support display properties and bounding box logic.
    public class Circle : AbstractGraphic2D
    {
        // X-coordinate of the circle's center.
        public decimal CenterX;

        // Y-coordinate of the circle's center.
        public decimal CenterY;

        // Radius of the circle.
        public decimal Radius;

        // The smallest X value that may be occupied by the circle.
        public override decimal LowerBoundX { get; protected set; }

        // The largest X value that may be occupied by the circle.
        public override decimal UpperBoundX { get; protected set; }

        // The smallest Y value that may be occupied by the circle.
        public override decimal LowerBoundY { get; protected set; }

        // The largest Y value that may be occupied by the circle.
        public override decimal UpperBoundY { get; protected set; }

        // Constructs a new circle centered at (x, y) with the given radius.
        // Computes a bounding box around the circle for efficient rendering.
        public Circle(decimal x, decimal y, decimal radius)
        {
            CenterX = x;
            CenterY = y;
            Radius = radius;

            // Ensure bounding box doesn't go below zero on the grid.
            LowerBoundX = CenterX - Radius < 0 ? 0 : CenterX - Radius;
            UpperBoundX = CenterX + Radius;

            LowerBoundY = CenterY - Radius < 0 ? 0 : CenterY - Radius;
            UpperBoundY = CenterY + Radius;
        }

        // Determines whether a given point (x, y) is inside the circle,
        // using the distance formula: √[(x−h)² + (y−k)²] ≤ r
        public override bool ContainsPoint(decimal x, decimal y)
        {
            return Math.Sqrt((double)((x - CenterX) * (x - CenterX) + (y - CenterY) * (y - CenterY))) 
                   <= (double)Radius;
        }
    }
}
