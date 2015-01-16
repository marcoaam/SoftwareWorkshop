using System.Collections.Generic;
using System.Linq;

namespace ProductionCode.Day4
{
    public class CarPark
    {
        private readonly int _maximumParkingSpaces;
        private readonly List<Car> _parkingSpaces;
        public string Name;

        public CarPark(int maximumParkingSpaces, string name)
        {
            _maximumParkingSpaces = maximumParkingSpaces;
            _parkingSpaces = CreateParkingSpaces();
            Name = name;
        }

        private List<Car> CreateParkingSpaces()
        {
            var parkingSpaces = new List<Car>();
            for (var i = 0; i < _maximumParkingSpaces; i++)
            {
                parkingSpaces.Add(null);
            }
            return parkingSpaces;
        }

        public bool IsFull
        {
            get { return NumberOfCarsParked() == _maximumParkingSpaces; }
        }

        public TicketInfo Receive(Car car)
        {
            AddToAvailableSpace(car);
            var ticketNumber = _parkingSpaces.IndexOf(car);
            var location = new TicketInfo { CarParkName = Name, SpaceNumber = ticketNumber };
            return location;
        }

        public Car Release(int parkingSpotNumber)
        {
            var car = _parkingSpaces[parkingSpotNumber];
            _parkingSpaces[parkingSpotNumber] = null;
            return car;
        }

        private void AddToAvailableSpace(Car car)
        {
            var emptySpaceNumber = _parkingSpaces.IndexOf(null);
            _parkingSpaces[emptySpaceNumber] = car;
        }

        private int NumberOfCarsParked()
        {
            return _parkingSpaces.Count(parkingSpace => parkingSpace != null);
        }

        public struct TicketInfo
        {
            public string CarParkName { get; set; }
            public int SpaceNumber { get; set; }
        }
    }
}