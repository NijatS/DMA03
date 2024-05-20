using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trendyol.Core.Enums;
using Trendyol.Core.Models.BaseModel;

namespace Trendyol.Core.Models
{
	public class Order : BaseEntity
	{
		public Customer Customer { get; set; }
		public OrderStatus Status { get; set; }
		public List<OrderProduct> OrderProducts = new List<OrderProduct>();
	}
}
