using NUnit.Framework;
using ProductionCode.Day4;

namespace ProductionCode.Tests.Day4Tests
{
    [TestFixture]
    public class CarParkTests
    {
        private CarPark carPark;

        [SetUp]
        public void SetUp()
        {
            const int maximumCapacity = 1;
            const string carParkName = "Hampton";
            carPark = new CarPark(maximumCapacity, carParkName);
        }

        [Test]
        public void HasAMaximumParkingCapacity()
        {
            const int maximumCapacity = 0;
            carPark = new CarPark(maximumCapacity, "Peterborough");

            Assert.That(carPark.IsFull, Is.True);
        }

        [Test]
        public void HasAName()
        {
            const string expectedName = "Hampton";

            Assert.That(carPark.Name, Is.EqualTo(expectedName));
        }

        [Test]
        public void CanReceiveCars()
        {
            carPark.Receive(new Car());

            Assert.That(carPark.IsFull, Is.True);
        }

        [Test]
        public void CanReleaseCars()
        {
            const int parkingSpot = 0;
            var car = new Car();

            carPark.Receive(car);

            Assert.That(carPark.Release(parkingSpot), Is.EqualTo(car));
        }
    }
}
