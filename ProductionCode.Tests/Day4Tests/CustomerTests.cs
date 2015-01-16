using System.Collections.Generic;
using NUnit.Framework;
using ProductionCode.Day4;

namespace ProductionCode.Tests.Day4Tests
{
    [TestFixture]
    public class CustomerTests
    {
        private Customer customer;
        private Car car;
        private Attendant attendant;
        private CarPark carPark;

        [SetUp]
        public void SetUp()
        {
            const int maximumCapacity = 2;
            customer = new Customer();
            car = new Car();
            carPark = new CarPark(maximumCapacity, "Hampton");
            var carParks = new List<CarPark> { carPark };
            attendant = new Attendant(carParks);
        }

        [Test]
        public void CanHoldACar()
        {
            customer.Car = car;

            Assert.That(customer.Car, Is.EqualTo(car));
        }

        [Test]
        public void ReceivesATicketWhenCarIsParkedAtCarPark()
        {
            customer.ParkCar(attendant);

            Assert.That(customer.Ticket, Is.TypeOf<Attendant.Ticket>());
        }

        [Test]
        public void DoesNotHaveTheCarWhenCarIsParked()
        {
            customer.Car = car;
            customer.ParkCar(attendant);

            Assert.That(customer.Car, Is.EqualTo(null));
        }

        [Test]
        public void CanCollectCarWithTicket()
        {
            customer.Car = car;
            customer.ParkCar(attendant);
            customer.CollectCar(attendant);

            Assert.That(customer.Car, Is.EqualTo(car));
        }

        [Test]
        public void DoesNotHaveTheTicketAfterCollectingTheCar()
        {
            customer.Car = car;
            customer.ParkCar(attendant);
            customer.CollectCar(attendant);

            Assert.That(customer.Ticket, Is.EqualTo(null));
        }

        [Test]
        public void RetrieveCarFromCarParkAfterOtherCarsHaveBeenRetrieved()
        {
            var car2 = new Car();
            var customer2 = new Customer();

            customer.Car = car;
            customer2.Car = car2;
            customer.ParkCar(attendant);
            customer2.ParkCar(attendant);
            customer.CollectCar(attendant);
            customer2.CollectCar(attendant);

            Assert.That(customer2.Car, Is.EqualTo(car2));
        }
    }
}
