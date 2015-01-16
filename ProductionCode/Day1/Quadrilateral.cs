namespace ProductionCode.Day1
{
    public abstract class Quadrilateral
    {
        private decimal _width;
        private decimal _height;

        protected Quadrilateral(decimal width, decimal height)
        {
            _width = width;
            _height = height;
        }

        public decimal Perimeter
        {
            get { return GetPerimeter(); }
        }

        public decimal Area
        {
            get { return _width * _height; }
        }

        private decimal GetPerimeter()
        {
            return (_width + _height) * 2;
        }
    }
}
