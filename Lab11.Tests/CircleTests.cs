using NUnit.Framework;

namespace Lab11.Tests
{
    public class CircleTests
    {
        Circle circle;
        AbstractGraphic2D shape;

        [SetUp]
        public void Setup()
        {
            // should be x, y, and radius
            circle = new Circle(8, 10, 2);

            // should extend the abstract class
            shape = circle;
        }

        [Test]
        public void CircleHasCorrectDimensions()
        {
            Assert.That(circle.CenterX, Is.EqualTo(8));
            Assert.That(circle.CenterY, Is.EqualTo(10));
            Assert.That(circle.Radius, Is.EqualTo(2));
        }

        [Test]
        public void HasCorrectBoundingBox()
        {
            Assert.That(shape.LowerBoundX, Is.EqualTo(6));
            Assert.That(shape.LowerBoundY, Is.EqualTo(8));
            Assert.That(shape.UpperBoundX, Is.EqualTo(10));
            Assert.That(shape.UpperBoundY, Is.EqualTo(12));
        }

        [Test]
        public void CenterIsIncluded()
        {
            Assert.IsTrue(shape.ContainsPoint(8, 10));
        }

        [Test]
        public void ContainsAllFourPointsOfTheCompass()
        {
            Assert.IsTrue(shape.ContainsPoint(6, 10)); // West
            Assert.IsTrue(shape.ContainsPoint(10, 10)); // East
            Assert.IsTrue(shape.ContainsPoint(8, 8)); // North
            Assert.IsTrue(shape.ContainsPoint(8, 12)); // South
        }

        [Test]
        public void ShouldNotContainFourCorners()
        {
            Assert.IsFalse(shape.ContainsPoint(6, 8));
            Assert.IsFalse(shape.ContainsPoint(10, 8));
            Assert.IsFalse(shape.ContainsPoint(6, 12));
            Assert.IsFalse(shape.ContainsPoint(10, 12));
        }
    }
}
