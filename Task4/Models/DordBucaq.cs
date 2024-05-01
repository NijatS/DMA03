using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4.Models
{
	internal class DordBucaq : Figure
	{
		private double _en;

		public double GetEn() {
			return _en;
		}

		public void SetEn(double en) {
			_en = en;
		}
		public double CalculatePerimeter() {
			double teref = GetTeref();
			return (teref + _en) * 2;
		}
	}
}
