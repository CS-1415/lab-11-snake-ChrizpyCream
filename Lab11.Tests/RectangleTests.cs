using System.Diagnostics;
namespace Lab11.Tests;

public class RectangleTests
{
    Rectangle rectangle;
    AbstractGraphic2D shape;

    [SetUp]
    public void Setup()
    {
        rectangle = new Rectangle(3, 4, 5, 6);
        shape = rectangle;
    }

    [Test]
    public void EnsurePropertiesAreCorrect()
    {
        Assert.That(rectangle.Left, Is.EqualTo(3));
        // Assert.AreEqual(3, rectangle.Left);
        Assert.That(rectangle.Top, Is.EqualTo(4));
        // Assert.AreEqual(4, rectangle.Top);
        Assert.That(rectangle.Width, Is.EqualTo(5));
        // Assert.AreEqual(5, rectangle.Width);
        Assert.That(rectangle.Height, Is.EqualTo(6));
        // Assert.AreEqual(6, rectangle.Height);
    }

    [Test]
    public void CheckLowerBounds()
    {
        // lower bound is the smallest x that needs to be checked when drawing the shape
        Assert.That(shape.LowerBoundX, Is.EqualTo(3));
        //Assert.AreEqual(3, shape.LowerBoundX);
        Assert.That(shape.LowerBoundY, Is.EqualTo(4));
        //Assert.AreEqual(4, shape.LowerBoundY);
    }

    [Test]
    public void CheckUpperBounds()
    {
        // upper bound is the largest x that needs to be checked when drawing the shape
        Assert.That(shape.UpperBoundX, Is.EqualTo(3 + 5));
        //Assert.AreEqual(3 + 5, shape.UpperBoundX);
        Assert.That(shape.UpperBoundY, Is.EqualTo(4 + 6));
        //Assert.AreEqual(4 + 6, shape.UpperBoundY);
    }

    [Test]
    public void MiddleOfShapeIsIncluded()
    {
        Debug.Assert(shape.ContainsPoint(5.5m, 7));
        //Assert.IsTrue(shape.ContainsPoint(5.5m, 7));
    }

    [Test]
    public void CornersIncluded()
    {
        Debug.Assert(shape.ContainsPoint(3, 4));
        // Assert.IsTrue(shape.ContainsPoint(3, 4));
        Debug.Assert(shape.ContainsPoint(8,4));
        // Assert.IsTrue(shape.ContainsPoint(8, 4));
        Debug.Assert(shape.ContainsPoint(3,10));
        // Assert.IsTrue(shape.ContainsPoint(3, 10));
        Debug.Assert(shape.ContainsPoint(8,10));
        // Assert.IsTrue(shape.ContainsPoint(8, 10));
    }

    [Test]
    public void OutsideOfCornersNotIncludedInShape()
    {   Debug.Assert(!shape.ContainsPoint(3 - 0.1m, 4));
        // Assert.IsFalse(shape.ContainsPoint(3 - 0.1m, 4));
        Debug.Assert(!shape.ContainsPoint(8, 4 - 0.1m));
        // Assert.IsFalse(shape.ContainsPoint(8, 4 - 0.1m));
        Debug.Assert(!shape.ContainsPoint(3, 10 + 0.1m));
        // Assert.IsFalse(shape.ContainsPoint(3, 10 + 0.1m));
        Debug.Assert(!shape.ContainsPoint(8 + 0.1m, 10));
        // Assert.IsFalse(shape.ContainsPoint(8 + 0.1m, 10));
    }
}