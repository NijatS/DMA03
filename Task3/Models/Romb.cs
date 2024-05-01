using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Models
{
	public class Romb
	{
		private double _side;
		private double _height;

        public Romb(double side, double height)
        {
            if (side <= 0 || height <= 0) throw new ArgumentException();
            _side = side;
            _height = height;
        }

        public double CalculateArea()
        {
            double area = _side * _height;
            return area;
        }
    }
}
