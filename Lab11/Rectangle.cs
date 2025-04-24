namespace Lab11;

public class Rectangle : AbstractGraphic2D
{
    public decimal Left;
    public decimal Top;
    public decimal Width;
    public decimal Height;

    public override decimal LowerBoundX { get; protected set;}
    public override decimal UpperBoundX { get; protected set;} // right side
    public override decimal LowerBoundY { get; protected set;}
    public override decimal UpperBoundY { get; protected set;} // bottom side

    public Rectangle(decimal left, decimal top, decimal width, decimal height)
    {
        Left = left;
        Top = top;
        Width = width;
        Height = height;

        LowerBoundX = Left;
        UpperBoundX = Left + Width;
        LowerBoundY = Top;
        UpperBoundY = Top + Height;
    }

    public override bool ContainsPoint(decimal x, decimal y)
    {
        return (x <= UpperBoundX && x >= LowerBoundX && y<= UpperBoundY && y >= LowerBoundY);
    }
}