using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductionCode.Day4
{
    public class Attendant : Subject
    {
        private List<CarPark> _carParks;
 
        public Attendant(List<CarPark> carParks)
        {
            _carParks = carParks;
            _message = "Car Park Full Come Get 3";
        }

        public Ticket IssueTicketAndParkCar(Car car)
        {
            foreach (var carPark in _carParks)
            {
                if (!carPark.IsFull)
                {
                    var ticketInfo = carPark.Receive(car);
                    return new Ticket(ticketInfo.SpaceNumber, ticketInfo.CarParkName);
                }

            }
            Notify();
            return null;
        }

        public Car CollectCar(Ticket ticket)
        {
            return _carParks.Where(carPark => carPark.Name == ticket.CarParkName)
                            .Select(carPark => carPark.Release(ticket.Number)).FirstOrDefault();
        }

        public class Ticket
        {
            public int Number { get; private set; }
            public string CarParkName { get; private set; }

            internal Ticket(int number, string carParkName)
            {
                Number = number;
                CarParkName = carParkName;
            }

            public string Registration
            {
                get { return String.Format("{0}-{1}", Number, CarParkName); }
            }
        }

    }
}