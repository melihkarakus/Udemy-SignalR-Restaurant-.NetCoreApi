using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using SignalR.DtoLayer.CategoryDto;
using SignalRWebUI.Dtos.ProductDto;
using System.Text;


namespace SignalRWebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7123/api/Product/ProductListWithCategory");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDtos>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            var client = _httpClientFactory.CreateClient();//işlemci oluşturuldu.
            var responseMessage = await client.GetAsync("https://localhost:7123/api/Category");//Eşleştirilmiş apiye istek atıldı.
            var jsonData = await responseMessage.Content.ReadAsStringAsync();//Json formatında okudu
            var values = JsonConvert.DeserializeObject<List<ResultCategoryDtos>>(jsonData);//okunan json formatını liste şeklinde deserilize edildi.
            List<SelectListItem> values2 = (from x in values //selectlistitem ile values içindeki x'e tanımlamalar yapıldı.
                                            select new SelectListItem
                                            {
                                                Text = x.CategoryName,//kategori adı 
                                                Value = x.CategoryID.ToString()//kategori id çağırıldı.
                                            }).ToList();//ve listeleme işlemi yaptı.
            ViewBag.Categoryname = values2;//values2 içine atılan kategorileri viewbag ile view tarafına taşıma işlemi yaptık.
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDtos createProductDtos)
        {
            createProductDtos.ProductStatus = true;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createProductDtos);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7123/api/Product", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7123/api/Product/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            var client1 = _httpClientFactory.CreateClient();//işlemciye istek attık
            var responseMessage2 = await client1.GetAsync("https://localhost:7123/api/Category");//Apiye istek atıyoruz kategoriye
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();//Json formatında okuyoruz.
            var values1 = JsonConvert.DeserializeObject<List<ResultCategoryDtos>>(jsonData2);//Okunan formatı deserilize edip listeleme yapıyoruz.
            List<SelectListItem> values2 = (from x in values1 //listItem çağırarak values2 içine valuesdeki dönülen değeri atıcaz.
                                            select new SelectListItem//select item diyip seçiyoruz
                                            {
                                                Text = x.CategoryName,//x içine kategori adı 
                                                Value = x.CategoryID.ToString()//x içine kategori idsi 
                                            }).ToList();//listeliyoruz
            ViewBag.Categoryname = values2;//values2 içindeki kategorileri viewbag tanımlanan içine atıyoruz.



            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7123/api/Product/{id}");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateProductDtos>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDtos updateProductDtos)
        {
            updateProductDtos.ProductStatus = true;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateProductDtos);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7123/api/Product", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
