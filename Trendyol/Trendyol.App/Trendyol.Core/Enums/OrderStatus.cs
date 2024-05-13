﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trendyol.Core.Enums
{
	public enum OrderStatus
	{
		ProcessingStock = 1,
		ReadyForPacking,
		ReadyToDeliver,
		Delivered,
		Received,
		Returned,
		NotDelivered,
	}
}
