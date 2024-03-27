﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DtoLayer.OrderDto
{
	public class CreateOrderDtos
	{
		public string TableNumber { get; set; }
		public string Description { get; set; }
		public DateTime Date { get; set; }
		public Decimal TotalPrice { get; set; }

	}
}
