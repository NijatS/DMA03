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
		Customer Customer { get; set; }
		OrderStatus Status { get; set; }

	}
}
