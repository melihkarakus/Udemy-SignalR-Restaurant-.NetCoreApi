using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DtoLayer.OrderDetailDto
{
	public class GetOrderDetailDtos
	{
		public int OrderDetailID { get; set; }
		public int ProductID { get; set; }
		public int Count { get; set; }
		public decimal UnitPrice { get; set; }
		public decimal TotalPrice { get; set; }
		public int OrderID { get; set; }
	}
}
