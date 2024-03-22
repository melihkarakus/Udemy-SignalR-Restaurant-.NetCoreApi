using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.EntityFreamework
{
    //Kendine özgü bir method geçildiğini buraya kolaylıkla sağlayıp içerik kodunu buraya yazacağız.
    public class EfAboutDal : GenericRepository<About>, IAboutDal
    {
        //Constructer oluşturuldu. Çünkü GenericRepository Constructer oluşturulduğu için
        public EfAboutDal(SignalRContext context) : base(context)
        {
        }
    }
}
