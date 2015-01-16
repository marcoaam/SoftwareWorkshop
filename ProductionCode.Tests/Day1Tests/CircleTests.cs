using NUnit.Framework;
using ProductionCode.Day1;

namespace ProductionCode.Tests.Day1Tests
{
    [TestFixture]
    public class CircleTests
    {
        [Test]
        public void ShouldReturnPerimeterOfACircle()
        {
            var radius = 5m;
            var circle = new Circle(radius);
            var expectedPerimeter = 31.42m;

            Assert.That(circle.Perimeter, Is.EqualTo(expectedPerimeter));
        }

        [Test]
        public void ShouldReturnAreaOfACircle()
        {
            var radius = 5m;
            var circle = new Circle(radius);
            var expectedArea = 78.54m;

            Assert.That(circle.Area, Is.EqualTo(expectedArea));
        }
    }
}