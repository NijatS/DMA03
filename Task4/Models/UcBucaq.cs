using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4.Models
{
	internal class UcBucaq:Figure
	{
		public double CalculatePerimeter() {
			double teref =  GetTeref();
			return teref * 3;
		}
	}
}
