using Microsoft.AspNetCore.SignalR;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using System.Configuration;
using System.Runtime.InteropServices;

namespace SignalRApi.Hubs
{
    //SignalRHub - Hub sınıfına eşleşti.
    public class SignalRHub : Hub
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly IMoneyCaseService _moneyCaseService;
        private readonly IMenuTableService _menuTableService;
        private readonly IBookingService _bookingService;
        private readonly INotificationService _notificationService;
        public SignalRHub(ICategoryService categoryService, IProductService productService, IOrderService orderService, IMoneyCaseService moneyCaseService, IMenuTableService menuTableService, IBookingService bookingService, INotificationService notificationService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _orderService = orderService;
            _moneyCaseService = moneyCaseService;
            _menuTableService = menuTableService;
            _bookingService = bookingService;
            _notificationService = notificationService;
        }
        public static int clientCount { get; set; } = 0; //Client sayısı için static olarak verileri tutmamız gerekiyor anlık çekmek için
        public async Task SendStatistic()//Buraya abone oluncak kategori işlemleri için
        {
            var value = _categoryService.TCategoryCount();//Kategori toplancak
            await Clients.All.SendAsync("ReceiveCategoryCount", value);//Burada içerik gösterilcek
           
            var value2 = _productService.TProductCount();//Ürün toplancak
            await Clients.All.SendAsync("ReceiverProductCount", value2);//Burada içerik gösterilcek

            var value3 = _categoryService.TActiveCategoryCount();//Aktif Kategori toplancak
            await Clients.All.SendAsync("ActiveCategoryCount", value3);//Burada içerik gösterilcek

            var value4 = _categoryService.TPassiveCategoryCount();//Pasif Kategori toplancak
            await Clients.All.SendAsync("PassiveCategoryCount", value4);//Burada içerik gösterilcek

            var value5 = _productService.TProductCountByCategoryNameHamburger();
            await Clients.All.SendAsync("HamburgerCategoryName", value5);

            var value6 = _productService.TProductCountByCategoryNameDrink();
            await Clients.All.SendAsync("CategoryNameDrink", value6);

            var value7 = _productService.TProductPriceAvg();
            await Clients.All.SendAsync("ProductPriceAvg", value7.ToString("0.00") + "TL"); //Tostring methodu ile 0.00 attığımızda double olarak gelsede sıfırlar 
            //atacak şekilde geliyor.

            var value8 = _productService.TProductNameByMaxPrice();
            await Clients.All.SendAsync("ProductNameByMaxPrice", value8);

            var value9 = _productService.TProductNameByMinPrice();
            await Clients.All.SendAsync("ProductNameByMinPrice", value9);

            var value10 = _productService.TProductAvgPriceHamburger();
            await Clients.All.SendAsync("ProductAvgPriceHamburger", value10.ToString("0.00") + "TL");

            var value11 = _orderService.TTotalOrderCount();
            await Clients.All.SendAsync("TotalOrderCount", value11);

            var value12 = _orderService.TActiveOrderCount();
            await Clients.All.SendAsync("ActiveOrderCount", value12);

            var value13 = _orderService.TLastOrderPrice();
            await Clients.All.SendAsync("LastOrderPrice", value13.ToString("0.00") + "TL");

            var value14 = _moneyCaseService.TTotalMoneyCaseAmount();
            await Clients.All.SendAsync("TotalMoneyCaseAmount", value14.ToString("0.00000") + "TL");

            var value16 = _menuTableService.TMenuTableCount();
            await Clients.All.SendAsync("MenuTableCount", value16);
        }

        public async Task SendProgress()//Admin Dashboard İstatistik için için ilk başta hup tanımlama yapılıyor.
        {
            var value = _moneyCaseService.TTotalMoneyCaseAmount();
            await Clients.All.SendAsync("TotalCaseMoneyAmount", value.ToString("0.00") + "TL");

            var value1 = _orderService.TActiveOrderCount();
            await Clients.All.SendAsync("ActiveOrderCount", value1);

            var value2 = _menuTableService.TMenuTableCount();
            await Clients.All.SendAsync("MenuTableCount", value2);

            var value3 = _productService.TProductPriceAvg();
            await Clients.All.SendAsync("ReceiveProductPriceAvg", value3);

            var value4 = _productService.TProductAvgPriceHamburger();
            await Clients.All.SendAsync("ReceiveAvgPriceHamburger", value4);

            var value5 = _productService.TProductCountByCategoryNameDrink();
            await Clients.All.SendAsync("ReceiveCountByCategoryNameDrink", value5);

            var value6 = _orderService.TTotalOrderCount();
            await Clients.All.SendAsync("ReceiveTotalOrderCount", value6);

            var value7 = _productService.TProductAvgPriceBySteakBurger();
            await Clients.All.SendAsync("ReceiveProductAvgPriceBySteakBurger", value7);

            var value8 = _categoryService.TPassiveCategoryCount();
            await Clients.All.SendAsync("ReceivePassiveCategoryCount", value8);

            var value9 = _categoryService.TActiveCategoryCount();
            await Clients.All.SendAsync("ReceiveActiveCategoryCount", value9);

            var value10 = _orderService.TTotalOrderCount();
            await Clients.All.SendAsync("ReceiveTotalOrderCount", value10);

            var value11 = _menuTableService.TActiveMenuTableCount();
            await Clients.All.SendAsync("ReceiveActiveMenuTableCount", value11);
        }

        public async Task GetBookingList()
        {
            var values = _bookingService.TGetListAll();
            await Clients.All.SendAsync("GetBookingList", values);
        }//Tablo şeklinde admin booking verileri anlık çekme

        public async Task SendNotification()//SignalR anlık bildirim verileri çekme
        {
            var value = _notificationService.TNotificationCountByStatusFalse();
            await Clients.All.SendAsync("SendNotification", value);

            var notificationListByFalse =_notificationService.TGetAllNotificationsByFalse();
            await Clients.All.SendAsync("GetAllNotificationsByFalse", notificationListByFalse);
        }

        public async Task GetMenuTableStatus()//Masaların boş veya dolu olduğu veriler çekme
        {
            var values = _menuTableService.TGetListAll();
            await Clients.All.SendAsync("GetMenuTableStatus", values);
        }

        public async Task SendMessage(string user, string message)//Anlık mesajlaşma işlemi için yapılan işlem
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);

        }

        public override async Task OnConnectedAsync()//Client bağlı olan sayıyı alıyor
        {
            clientCount++;
            await Clients.All.SendAsync("ReceiveClientCount", clientCount);
            await base.OnConnectedAsync();
        }
        public override async Task OnDisconnectedAsync(Exception? exception)//Client Bağlı olmayan sayıyı alıyor
        {
            clientCount--;
            await Clients.All.SendAsync("ReceiveClientCount", clientCount);
            await base.OnDisconnectedAsync(exception);
        }
    }
}
