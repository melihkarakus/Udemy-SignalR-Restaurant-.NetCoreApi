using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.DiscountDto;

namespace SignalRWebUI.ViewComponents.DefaultComponent
{
    public class _DefaultOfferComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultOfferComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7123/api/Discount/GetListByStatusTrue");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();   
                var values = JsonConvert.DeserializeObject<List<ResultDiscountDtos>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
