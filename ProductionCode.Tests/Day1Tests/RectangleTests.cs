using NUnit.Framework;
using ProductionCode.Day1;

namespace ProductionCode.Tests.Day1Tests
{
    [TestFixture]
    public class RectangleTests
    {
        [Test]
        public void ShouldCalculateRectanglePerimeterProvidingWidthAndHeight()
        {
            var width = 5m;
            var height = 4m;
            var expectedPerimeter = 18m;

            var rectangle = new Rectangle(width, height);

            Assert.That(rectangle.Perimeter, Is.EqualTo(expectedPerimeter));
        }


        [Test]
        public void ShouldCalculateSquarePerimeterProvidingOneSide()
        {
            var side = 5m;
            var expectedPerimeter = 20m;

            var square = new Square(side);

            Assert.That(square.Perimeter, Is.EqualTo(expectedPerimeter));
        }

        [Test]
        public void ShouldTheAreaOfARectangle()
        {
            var width = 5m;
            var height = 4m;
            var expectedArea = 20m;

            var rectangle = new Rectangle(width, height);

            Assert.That(rectangle.Area, Is.EqualTo(expectedArea));
        }

        [Test]
        public void ShouldReturnTheAreaOfASquare()
        {
            var side = 5m;
            var expectedArea = 25m;

            var square = new Square(side);

            Assert.That(square.Area, Is.EqualTo(expectedArea));
        }
    }
}
