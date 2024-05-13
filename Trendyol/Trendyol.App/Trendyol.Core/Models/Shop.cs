using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trendyol.Core.Models.BaseModel;

namespace Trendyol.Core.Models
{
	public class Shop :BaseEntity
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public double Rating { get; set; }
	}
}
