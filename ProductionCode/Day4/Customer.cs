namespace ProductionCode.Day4
{
    public class Customer
    {
        public Car Car { get; set; }

        public Attendant.Ticket Ticket { get; set; }

        public void ParkCar(Attendant attendant)
        {
            Ticket = attendant.IssueTicketAndParkCar(Car);
            Car = null;
        }

        public void CollectCar(Attendant attendant)
        {
            Car = attendant.CollectCar(Ticket);
            Ticket = null;
        }
    }
}