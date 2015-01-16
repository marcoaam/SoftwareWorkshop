using System;

namespace ProductionCode.Day1
{
    public class Circle
    {
        private decimal _radius;
        private decimal _pi;

        public Circle(decimal radius)
        {
            _radius = radius;
            _pi = (Decimal)Math.PI;
        }

        public decimal Perimeter
        {
            get { return Math.Round(2 * (_radius * _pi), 2); }
        }

        public decimal Area
        {
            get { return Math.Round(_pi * (_radius * _radius), 2); }
        }
    }
}