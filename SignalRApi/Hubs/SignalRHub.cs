using Microsoft.AspNetCore.SignalR;
using SignalR.DataAccessLayer.Concrete;

namespace SignalRApi.Hubs
{
    //SignalRHub - Hub sınıfına eşleşti.
    public class SignalRHub : Hub
    {
        SignalRContext context = new SignalRContext();

        public async Task SendCategoryCount()//Buraya abone oluncak kategori işlemleri için
        {
            var value = context.Categories.Count();//Kategori toplancak
            await Clients.All.SendAsync("ReceiveCategoryCount", value);//Burada içerik gösterilcek
        }
    }
}
