using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
	public class OrderDetailManager : IOrderDetailService
	{
		private readonly IOrderDetailDal _orderdetailDal;

		public OrderDetailManager(IOrderDetailDal orderdetailDal)
		{
			_orderdetailDal = orderdetailDal;
		}

		public void TAdd(OrderDetail entity)
		{
			_orderdetailDal.Add(entity);
		}

		public void TDelete(OrderDetail entity)
		{
			_orderdetailDal.Delete(entity);
		}

		public OrderDetail TGetByID(int id)
		{
			return _orderdetailDal.GetByID(id);
		}

		public List<OrderDetail> TGetListAll()
		{
			return _orderdetailDal.GetListAll();
		}

		public void TUpdate(OrderDetail entity)
		{
			_orderdetailDal.Update(entity);
		}
	}
}
