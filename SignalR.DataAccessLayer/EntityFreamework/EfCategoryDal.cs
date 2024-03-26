using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFreamework
{
	//Kendine özgü bir method geçildiğini buraya kolaylıkla sağlayıp içerik kodunu buraya yazacağız.
	public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        //Constructer oluşturuldu. Çünkü GenericRepository Constructer oluşturulduğu için
        public EfCategoryDal(SignalRContext context) : base(context)
        {
        }

		public int ActiveCategoryCount()
		{
			using var context = new SignalRContext();
			return context.Categories.Where(x => x.Status == true).Count();
		}

		public int CategoryCount()
		{
			using var context = new SignalRContext();
			return context.Categories.Count();
		}

		public int PassiveCategoryCount()
		{
			using var context = new SignalRContext();
			return context.Categories.Where(x => x.Status == false).Count();	
		}
	}
}
