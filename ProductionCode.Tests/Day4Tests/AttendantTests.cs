using System;
using System.Collections.Generic;
using NUnit.Framework;
using ProductionCode.Day4;
using Rhino.Mocks;

namespace ProductionCode.Tests.Day4Tests
{
    [TestFixture]
    public class AttendantTests
    {
        private Attendant attendant;
        private CarPark carPark;

        [SetUp]
        public void SetUp()
        {
            const int maximumCapacity = 1;
            const string carParkName = "Hampton";

            carPark = new CarPark(maximumCapacity, carParkName);
            var carParks = new List<CarPark> { carPark };
            attendant = new Attendant(carParks);
        }

        [Test]
        public void CanIssueATicket()
        {
            var car = new Car();
            var ticketIssued = attendant.IssueTicketAndParkCar(car);
            const string expectedTicketRegistration = "0-Hampton";

            Assert.That(ticketIssued, Is.TypeOf<Attendant.Ticket>());
            Assert.That(ticketIssued.Registration, Is.EqualTo(expectedTicketRegistration));
        }

        [Test]
        public void CannotIssueTicketsIfCarParkIsFull()
        {
            var car = new Car();
            carPark = new CarPark(0, "Hampton");
            var fullCarPark = new CarPark(0, "Peterborough");
            var carParks = new List<CarPark> { carPark, fullCarPark };
            attendant = new Attendant(carParks);

            var carParkFullResult = attendant.IssueTicketAndParkCar(car);

            Assert.That(carParkFullResult, Is.Null);
        }

        [Test]
        public void CanHandleMoreThanOneCarParks()
        {
            var car = new Car();
            carPark = new CarPark(1, "Hampton");
            var fullCarPark = new CarPark(0, "Peterborough");
            var carParks = new List<CarPark> { carPark, fullCarPark };
            attendant = new Attendant(carParks);
            const string expectedTicketRegistration = "0-Hampton";

            var ticket = attendant.IssueTicketAndParkCar(car);

            Assert.That(ticket.Registration, Is.EqualTo(expectedTicketRegistration));
        }

        [Test] public void ReturnsNullIfCarIsNotFoundInCarPark()
        {
            var car = new Car();
            var ticket = attendant.IssueTicketAndParkCar(car);

            attendant.CollectCar(ticket);

            Assert.That(attendant.CollectCar(ticket), Is.Null);
        }

        [Test]
        public void NotifiesCopWhenCarParkIsFull()
        {
            var car = new Car();
            var cop = MockRepository.GenerateMock<IObserver>();
            attendant.Attach(cop);

            attendant.IssueTicketAndParkCar(car);
            attendant.IssueTicketAndParkCar(car);

            cop.AssertWasCalled(x => x.Update("Car Park Full Come Get 3"));
        }

    }
}
