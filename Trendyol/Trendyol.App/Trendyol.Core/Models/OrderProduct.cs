using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trendyol.Core.Models.BaseModel;

namespace Trendyol.Core.Models
{
	public class OrderProduct : BaseEntity
	{
		public int Count { get; set; }
		public Product Product { get; set; }
		public Order Order { get; set; }
	}
}
