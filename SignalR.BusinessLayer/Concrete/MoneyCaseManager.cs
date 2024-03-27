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
	public class MoneyCaseManager : IMoneyCaseService
	{
		private readonly IMoneyCaseDal _moneyCaseDal;

		public MoneyCaseManager(IMoneyCaseDal moneyCaseDal)
		{
			_moneyCaseDal = moneyCaseDal;
		}

		public void TAdd(MoneyCase entity)
		{
			_moneyCaseDal.Add(entity);
		}

		public void TDelete(MoneyCase entity)
		{
			_moneyCaseDal.Delete(entity);
		}

		public MoneyCase TGetByID(int id)
		{
			return _moneyCaseDal.GetByID(id);
		}

		public List<MoneyCase> TGetListAll()
		{
			return _moneyCaseDal.GetListAll();
		}

		public decimal TTotalMoneyCaseAmount()
		{
			return _moneyCaseDal.TotalMoneyCaseAmount();
		}

		public void TUpdate(MoneyCase entity)
		{
			_moneyCaseDal.Update(entity);
		}
	}
}
